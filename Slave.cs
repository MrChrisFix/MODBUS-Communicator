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
                        parent.GetArguments();
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



    }
}
