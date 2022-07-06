using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace MODBUS_Communicator
{
    public partial class MainWindow : Form
    {
        private SerialPort _serialPort;
        public MainWindow()
        {
            _serialPort = new SerialPort();
            InitializeComponent();
            this.InitValues();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
            base.OnClosed(e);
        }

        private void InitValues()
        {
            this.TransmissionType.Items.Add("Address");
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
            this.Timeout_Bar.Value = this.Timeout_Bar.Value - this.Timeout_Bar.Value % this.Timeout_Bar.SmallChange;
            this.Timeout_Text.Text = this.Timeout_Bar.Value.ToString();
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
        }
        private void button_Send_Click(object sender, EventArgs e)
        {
            //TODO
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
            if (this.Master_Arguments.Text.Length > 0 &&
                this.CheckSlaveAddress(this.Master_SlaveAddress.Text) &&
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


        #endregion

        
    }
}
