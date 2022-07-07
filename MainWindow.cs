using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace MODBUS_Communicator
{
    public partial class MainWindow : Form
    {
        private SerialPort _serialPort;
        private bool slaveListen = false;
        private Master master;
        private Slave slave;

        public MainWindow()
        {
            _serialPort = new SerialPort
            {
                BaudRate = 9600,
                Parity = Parity.Even,
                StopBits = StopBits.One,
                DataBits = 7,
                ReadTimeout = 500,
                WriteTimeout = 500
            };
            InitializeComponent();
            this.InitValues();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
            this.master = null;
            this.slave = null;
            base.OnClosed(e);
        }

        private void InitValues()
        {
            this.TransmissionType.Items.Add("Unicast");
            this.TransmissionType.Items.Add("Broadcast");
            this.TransmissionType.SelectedIndex = 0;

            this.whichInstruction.Items.Add("1");
            this.whichInstruction.Items.Add("2");
            this.whichInstruction.SelectedIndex = 0;

            this.Master_Port.Items.AddRange(SerialPort.GetPortNames());
            this.Slave_Port.Items.AddRange(SerialPort.GetPortNames());

            this.Timeout_Text.Text = this.Timeout_Bar.Value.ToString();
            this.Retransmissions_Text.Text = this.Retransmissions_Bar.Value.ToString();
            this.Master_Time_Interval_Text.Text = this.Master_Time_Interval_Bar.Value.ToString();
            this.Slave_Time_Interval_Text.Text = this.Slave_Time_Interval_Bar.Value.ToString();
            System.Diagnostics.Debug.WriteLine(this.Master_Port.SelectedIndex);
        }
        private bool CheckSlaveAddress(string text)
        {
            if (text.Length < 1) return false;
            if (int.Parse(text) < 248 && int.Parse(text) > 0) return true;
            return false;
        }

        #region Master Page
        private void Timeout_Bar_Scroll(object sender, EventArgs e)
        {
            this.Timeout_Bar.Value -= this.Timeout_Bar.Value % this.Timeout_Bar.SmallChange;
            this.Timeout_Text.Text = this.Timeout_Bar.Value.ToString();
            _serialPort.WriteTimeout = this.Timeout_Bar.Value;
            _serialPort.ReadTimeout = this.Timeout_Bar.Value;
        }

        private void Master_Time_Interval_Bar_Scroll(object sender, EventArgs e)
        {
            this.Master_Time_Interval_Bar.Value = this.Master_Time_Interval_Bar.Value - this.Master_Time_Interval_Bar.Value % this.Master_Time_Interval_Bar.SmallChange;
            this.Master_Time_Interval_Text.Text = this.Master_Time_Interval_Bar.Value.ToString();
        }

        private void Retransmissions_Bar_Scroll(object sender, EventArgs e)
        {
            this.Retransmissions_Text.Text = this.Retransmissions_Bar.Value.ToString();
        }

        private void Master_SlaveAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue < 48 || e.KeyValue > 57) && e.KeyValue != 8) e.SuppressKeyPress = true;
        }

        private void Master_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Master_Port.SelectedIndex >= 0) this.buttonMasterConnect.Enabled = true;
            _serialPort.PortName = Master_Port.SelectedItem.ToString();
        }
        private void buttonMasterConnect_Click(object sender, EventArgs e)
        {
            if (this.buttonMasterConnect.Text == "Disconnect as Master")
            {
                this.buttonMasterConnect.Text = "Connect as Master";
                this.master = null;
                _serialPort.Close();
                return;
            }
            else
            {
                try
                {
                    _serialPort.Open();
                    if (!_serialPort.IsOpen) throw new Exception("Couldn't connect");
                    else
                    {
                        this.master = new Master(_serialPort);
                        this.buttonMasterConnect.Text = "Disconnect as Master";
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            this.EnablingMasterSend();
        }
        private void TransmissionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Master_SlaveAddress.Enabled = this.TransmissionType.SelectedIndex == 0; //if index == 0 => true
            if(this.TransmissionType.SelectedIndex == 0) // if Address
            {
                this.Master_SlaveAddress.Enabled = true;
                this.whichInstruction.Enabled = true;
            }
            else
            {
                this.Master_SlaveAddress.Enabled = false;
                this.whichInstruction.SelectedIndex = 0;
                this.whichInstruction.Enabled = false;
            }
            this.EnablingMasterSend();
        }
        private void button_Send_Click(object sender, EventArgs e)
        {
            if(this.whichInstruction.SelectedIndex ==0) //Ins 1
            {
                if(this.TransmissionType.SelectedIndex==0) //Address
                    master.Instruction1(this.Master_SlaveAddress.Text, this.Master_Arguments.Text);
                else
                    master.Instruction1("0", this.Master_Arguments.Text);
            }
            else
            {
                string gottenText = master.Instruction2(this.Master_SlaveAddress.Text);
                this.Master_RecievedText.Text += "(" + this.Master_SlaveAddress.Text + ": DEC)" + gottenText + '\n';
                if(!gottenText.StartsWith("Error"))
                    this.Master_RecievedText.Text += "(" + this.Master_SlaveAddress.Text + ": HEX)" +
                    StringToHexConverter(gottenText) + '\n';

            }
        }
        private void Master_Arguments_TextChanged(object sender, EventArgs e)
        {
            this.EnablingMasterSend();
        }
        private void Master_SlaveAddress_TextChanged(object sender, EventArgs e)
        {
            this.EnablingMasterSend();
        }

        private void EnablingMasterSend()
        {
            if ((this.Master_Arguments.Text.Length > 0 || this.whichInstruction.SelectedIndex == 1) &&
                (this.CheckSlaveAddress(this.Master_SlaveAddress.Text) || this.TransmissionType.SelectedIndex == 1) &&
                _serialPort.IsOpen) this.button_Send.Enabled = true;
            else this.button_Send.Enabled = false;
        }

        #endregion



        #region Slave Page
        private void buttonSlaveConnect_Click(object sender, EventArgs e)
        {
            if (this.buttonSlaveConnect.Text == "Disconnect as Slave")
            {
                this.buttonSlaveConnect.Text = "Connect as Slave";
                this.slave = null;
                _serialPort.Close();
                this.buttonStartListening.Enabled = false;
                return;
            }
            else
            {
                try
                {
                    _serialPort.Open();
                    if (!_serialPort.IsOpen) throw new Exception("Couldn't connect");
                    else
                    {
                        this.buttonSlaveConnect.Text = "Disconnect as Slave";
                        this.buttonStartListening.Enabled = true;
                        this.slave = new Slave(_serialPort, this, this.Slave_SlaveAddress.Text);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
        private void Slave_Time_Interval_Bar_Scroll(object sender, EventArgs e)
        {
            this.Slave_Time_Interval_Bar.Value = this.Slave_Time_Interval_Bar.Value - this.Slave_Time_Interval_Bar.Value % this.Slave_Time_Interval_Bar.SmallChange;
            this.Slave_Time_Interval_Text.Text = this.Slave_Time_Interval_Bar.Value.ToString();
        }
        private void Slave_SlaveAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue < 48 || e.KeyValue > 57) && e.KeyValue != 8) e.SuppressKeyPress = true;
        }

        private void Slave_SlaveAddress_TextChanged(object sender, EventArgs e)
        {
            if (this.Slave_Port.SelectedIndex >= 0 && this.CheckSlaveAddress(this.Slave_SlaveAddress.Text)) this.buttonSlaveConnect.Enabled = true;
            else this.buttonSlaveConnect.Enabled = false;
        }
        
        private void Slave_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Slave_Port.SelectedIndex >= 0 && this.CheckSlaveAddress(this.Slave_SlaveAddress.Text)) this.buttonSlaveConnect.Enabled = true;
            _serialPort.PortName = Slave_Port.SelectedItem.ToString();
        }

        public void ChangeRecieved(string message)
        {
            this.Slave_RecievedText.Text += "(Dec): "+ message + '\n';
            if(!message.StartsWith("Error"))
                this.Slave_RecievedText.Text += "(Hex): " + StringToHexConverter(message) + '\n';

        }

        public string StringToHexConverter(string message)
        {
            byte[] ba = Encoding.Default.GetBytes(message);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            string hexString2 = "";
            int i = 0;
            foreach (char letter in hexString)
            {
                string hexOut = String.Format("{0:X}", Convert.ToInt32(letter));
                hexString2 += "0x" + hexOut + " ";
                if (i++ == 1) { hexString2 += "- "; i = 0; }
            }
            return hexString2;
        }

        public string GetArguments()
        {
            if(this.slaveListen)
                return this.Slave_Arguments.Text;
            return "Slave disallowed getting arguments";
        }


        #endregion

        private void buttonStartListening_Click(object sender, EventArgs e)
        {
            if(slaveListen)
            {
                this.slaveListen = false;
                this.Slave_Arguments.Enabled = false;
                this.buttonStartListening.Text = "Allow listening";
            }
            else
            {
                this.slaveListen = true;
                this.Slave_Arguments.Enabled = true;
                this.buttonStartListening.Text = "Disallow listening";
            }

            
        }
    }
}
