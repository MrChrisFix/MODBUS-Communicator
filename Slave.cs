using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODBUS_Communicator
{
    class Slave
    {
        private SerialPort _serialPort;
        private bool shuoldRead = false;
        private MainWindow parent;
        private Thread ReadCycle;
        private string Address;
        public Slave(SerialPort serial, MainWindow parent, string SlaveAddress)
        {
            this._serialPort = serial;
            shuoldRead = true;
            this.parent = parent;
            this.ReadCycle = new Thread(Read);
            ReadCycle.Start();
            this.Address = SlaveAddress;
        }
        ~Slave()
        {
            this.shuoldRead = false;
            ReadCycle.Join();
        }

        private void CheckAndDecode(string message)
        {
            if(message.StartsWith(":"))
            {
                if ( int.Parse(message.Substring(1, 2)) == int.Parse(this.Address) || int.Parse(message.Substring(1, 2)) == 0)
                {
                    if (message.Substring(3, 2).Equals("01")) //Instruction 1
                    {
                        parent.ChangeRecieved(message.Substring(5, message.Length - 8));
                    }
                    else if (message.Substring(3, 2).Equals("02"))
                    {
                        byte[] frame = ConvertToFrame(parent.GetArguments());
                        this._serialPort.Write(frame, 0, frame.Length);
                    }
                    else parent.ChangeRecieved("No such instruction");
                }
                else System.Diagnostics.Debug.WriteLine(message.Substring(1, 2));
            }
            else
            {
                parent.ChangeRecieved("An error occured in message transmission");
            }
        }

        private byte[] ConvertToFrame(string message)
        {
            string dataString = "";
            if (int.Parse(this.Address) < 10) dataString += "0";
            dataString += this.Address + "02";

            if (message.Length > 252)
                throw new Exception("The message is too long!");

            dataString += message;

            byte[] lrc = LRC(dataString);

            string frameString = ":" + dataString;

            byte[] frame = new byte[frameString.Length + 4];
            for (int i = 0; i < frame.Length - 4; i++)
            {
                frame[i] = ASCIIEncoding.ASCII.GetBytes(frameString.ElementAt(i).ToString())[0];
            }
            frame[frame.Length - 4] = lrc[0];
            frame[frame.Length - 3] = lrc[1];
            frame[frame.Length - 2] = 13;
            frame[frame.Length - 1] = 10;
            if (!_serialPort.IsOpen) throw new Exception("Error: Serial port in not open!");
            return frame;
        }

        private void Read()
        {
            while(shuoldRead && _serialPort.IsOpen)
            {
                try
                {
                    string message =_serialPort.ReadLine();
                    this.CheckAndDecode(message);
                }
                catch(TimeoutException)
                {  /*Do nothing and wait*/  }
                catch(Exception ex)
                {

                }
            }
        }
        private byte[] LRC(string data)
        {
            byte uchLRC = 0;
            int length = data.Length;

            for (int i = 0; i < data.Length; i++)
            {
                uchLRC += ASCIIEncoding.ASCII.GetBytes(data.ElementAt(i).ToString())[0];
            }
            if (uchLRC < 15)
            {
                byte[] returnVal = new byte[2];
                returnVal[1] = 0;
                returnVal[0] = ASCIIEncoding.ASCII.GetBytes(uchLRC.ToString())[0];
                return returnVal;
            }
            else
                return ASCIIEncoding.ASCII.GetBytes(uchLRC.ToString());

        }



    }
}
