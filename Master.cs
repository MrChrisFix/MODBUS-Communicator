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
            if (int.Parse(SlaveAddress) < 16) dataString += "0";
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
            if (int.Parse(SlaveAddress) < 16) dataString += "0";
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
            this._serialPort.Write(frame, 0, frame.Length);
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
    }
}
