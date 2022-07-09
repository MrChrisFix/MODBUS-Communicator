using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODBUS_Communicator
{
    class Master
    {
        private SerialPort _serialPort;
        public Master(SerialPort serialPort)
        {
            this._serialPort = serialPort;
        }

        //For broadcart set SlaveAddress = 0
        public void Instruction1(string SlaveAddress, string message)
        {
            string dataString = "";
            if (int.Parse(SlaveAddress) < 10) dataString += "0";
            dataString += SlaveAddress + "01";

            if(message.Length > 252)
                throw new Exception("The message is too long!");
            
            dataString += message;

            byte[] lrc = LRC(dataString);

            string frameString = ":" + dataString;

            byte[] frame = new byte[frameString.Length + 4];
            for(int i=0; i< frame.Length-4; i++)
            {
                frame[i] = CodeChar(frameString.ElementAt(i).ToString());
            }
            frame[frame.Length - 4] = lrc[0];
            frame[frame.Length - 3] = lrc[1];
            frame[frame.Length - 2] = 13;
            frame[frame.Length - 1] = 10;
            if (!_serialPort.IsOpen) throw new Exception("Error: Serial port in not open!");
            this._serialPort.Write(frame, 0, frame.Length);
        }

        public string Instruction2(string SlaveAddress)
        {
            string dataString = "";
            if (int.Parse(SlaveAddress) < 10) dataString += "0";
            dataString += SlaveAddress + "02";
            byte[] lrc = LRC(dataString);
            string frameString = ":" + dataString;

            byte[] frame = new byte[frameString.Length + 4];
            for (int i = 0; i < frame.Length - 4; i++)
            {
                frame[i] = CodeChar(frameString.ElementAt(i).ToString());
            }
            frame[frame.Length - 4] = lrc[0];
            frame[frame.Length - 3] = lrc[1];
            frame[frame.Length - 2] = 13;
            frame[frame.Length - 1] = 10;
            if (!_serialPort.IsOpen) throw new Exception("Error: Serial port in not open!");
            try
            {
                this._serialPort.Write(frame, 0, frame.Length);
            }
            catch(TimeoutException)
            {
                return "Error: Write timeout!";
            }
            catch(Exception) { return "Error: Something went wrong!"; }

            string messageBack;
            
            try
            {
                messageBack = _serialPort.ReadLine();
                return CheckAndDecode(messageBack, SlaveAddress);
            }
            catch(TimeoutException)
            {
               return "Error: No message recieved";
            }
            catch (Exception) { return "Error: Something went wrong!"; }
        }

        private byte[] PrepareFrame(string message, string InstructionNumber, string Address)
        {
            if (message.Length > 252)
                throw new Exception("The message is too long!");

            int frameLength = 5 + message.Length * 2 + 4;
            byte[] frame = new byte[frameLength];
            frame[0] = this.StringToHex(":")[0];
           /* if (int.Parse(Address) < 10) Address = "0" + Address;
            if (int.Parse(Address) < 100) Address = "0" + Address;*/
            byte[] addr = this.StringToHex(int.Parse(Address).ToString("X"));
            if(addr.Length == 1)
            {
                frame[1] = StringToHex("0")[0];
                frame[2] = addr[0];
            }
            else
            {
                frame[1] = addr[0];
                frame[2] = addr[1];
            }
            byte[] instr = StringToHex(int.Parse(InstructionNumber).ToString("X"));
            frame[3] = instr[0]; //Instrution is 1 or 2
            frame[4] = instr[1];


            return null;

        }

        private byte[] StringToHex(string data)
        {
            return Encoding.Default.GetBytes(data);
        }

        private byte[] CodeString(string message)
        {
            return ASCIIEncoding.ASCII.GetBytes(message);
        }
        private byte CodeChar(string message)
        {
            return ASCIIEncoding.ASCII.GetBytes(message)[0];
        }

        private byte[] LRC(string data)
        {
            byte uchLRC = 0;
            int length = data.Length;

            for(int i=0; i< data.Length; i++)
            {
                uchLRC += CodeChar(data.ElementAt(i).ToString());
            }
            if (uchLRC < 15)
            {
                byte[] returnVal = new byte[2];
                returnVal[1] = 0;
                returnVal[0] = CodeString(uchLRC.ToString())[0];
                return returnVal;
            }
            else
                return CodeString(uchLRC.ToString());

        }
        private string CheckAndDecode(string message, string SlaveAddress)
        {
            if (message.StartsWith(":"))
            {
                if (int.Parse(message.Substring(1, 2)) == int.Parse(SlaveAddress))
                {
                    if (message.Substring(3, 2).Equals("02")) //Instruction 1
                    {
                        return message.Substring(5, message.Length - 8);
                    }
                    else return "No such instruction";
                }
                else System.Diagnostics.Debug.WriteLine(message.Substring(1, 2));
            }
            else
            {
                return "An error occured in message transmission";
            }

            return "";
        }


        private void Write(int restransmissions, byte[] message)
        {
            if (!_serialPort.IsOpen) return;


            int loopNr = 0;
            while(restransmissions >= loopNr && _serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Write(message, 0, message.Length);
                    string confirmation = _serialPort.ReadLine();
                    return;
                }
                catch(TimeoutException)
                {
                    loopNr++;
                }
                catch(Exception)
                {

                }
            }
            //Couldn't send
        }
    }
}
