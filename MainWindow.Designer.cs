
namespace MODBUS_Communicator
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.Master_RecievedText = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Master_Port = new System.Windows.Forms.ComboBox();
            this.buttonMasterConnect = new System.Windows.Forms.Button();
            this.Master_Time_Interval_Text = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Master_Time_Interval_Bar = new System.Windows.Forms.TrackBar();
            this.Retransmissions_Text = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Retransmissions_Bar = new System.Windows.Forms.TrackBar();
            this.Timeout_Text = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Timeout_Bar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TransmissionType = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Master_Arguments = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.whichInstruction = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Master_SlaveAddress = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.Slave_RecievedText = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonStartListening = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.Slave_Arguments = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Slave_SlaveAddress = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Slave_Port = new System.Windows.Forms.ComboBox();
            this.buttonSlaveConnect = new System.Windows.Forms.Button();
            this.Slave_Time_Interval_Text = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Slave_Time_Interval_Bar = new System.Windows.Forms.TrackBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Master_Time_Interval_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Retransmissions_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timeout_Bar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slave_Time_Interval_Bar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.Master_RecievedText);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Master";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(564, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Recieved text";
            // 
            // Master_RecievedText
            // 
            this.Master_RecievedText.Location = new System.Drawing.Point(439, 25);
            this.Master_RecievedText.Name = "Master_RecievedText";
            this.Master_RecievedText.Size = new System.Drawing.Size(345, 389);
            this.Master_RecievedText.TabIndex = 6;
            this.Master_RecievedText.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Master_Port);
            this.groupBox2.Controls.Add(this.buttonMasterConnect);
            this.groupBox2.Controls.Add(this.Master_Time_Interval_Text);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Master_Time_Interval_Bar);
            this.groupBox2.Controls.Add(this.Retransmissions_Text);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Retransmissions_Bar);
            this.groupBox2.Controls.Add(this.Timeout_Text);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Timeout_Bar);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 408);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Port";
            // 
            // Master_Port
            // 
            this.Master_Port.FormattingEnabled = true;
            this.Master_Port.Location = new System.Drawing.Point(7, 334);
            this.Master_Port.Name = "Master_Port";
            this.Master_Port.Size = new System.Drawing.Size(155, 23);
            this.Master_Port.TabIndex = 15;
            // 
            // buttonMasterConnect
            // 
            this.buttonMasterConnect.Location = new System.Drawing.Point(7, 363);
            this.buttonMasterConnect.Name = "buttonMasterConnect";
            this.buttonMasterConnect.Size = new System.Drawing.Size(155, 39);
            this.buttonMasterConnect.TabIndex = 14;
            this.buttonMasterConnect.Text = "Connect as Master";
            this.buttonMasterConnect.UseVisualStyleBackColor = true;
            // 
            // Master_Time_Interval_Text
            // 
            this.Master_Time_Interval_Text.Location = new System.Drawing.Point(5, 235);
            this.Master_Time_Interval_Text.Name = "Master_Time_Interval_Text";
            this.Master_Time_Interval_Text.ReadOnly = true;
            this.Master_Time_Interval_Text.Size = new System.Drawing.Size(156, 22);
            this.Master_Time_Interval_Text.TabIndex = 11;
            this.Master_Time_Interval_Text.TabStop = false;
            this.Master_Time_Interval_Text.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Time interval";
            // 
            // Master_Time_Interval_Bar
            // 
            this.Master_Time_Interval_Bar.BackColor = System.Drawing.Color.SteelBlue;
            this.Master_Time_Interval_Bar.LargeChange = 10;
            this.Master_Time_Interval_Bar.Location = new System.Drawing.Point(5, 263);
            this.Master_Time_Interval_Bar.Maximum = 1000;
            this.Master_Time_Interval_Bar.Name = "Master_Time_Interval_Bar";
            this.Master_Time_Interval_Bar.Size = new System.Drawing.Size(156, 45);
            this.Master_Time_Interval_Bar.SmallChange = 10;
            this.Master_Time_Interval_Bar.TabIndex = 13;
            this.Master_Time_Interval_Bar.Value = 500;
            // 
            // Retransmissions_Text
            // 
            this.Retransmissions_Text.Location = new System.Drawing.Point(5, 136);
            this.Retransmissions_Text.Name = "Retransmissions_Text";
            this.Retransmissions_Text.ReadOnly = true;
            this.Retransmissions_Text.Size = new System.Drawing.Size(156, 22);
            this.Retransmissions_Text.TabIndex = 8;
            this.Retransmissions_Text.TabStop = false;
            this.Retransmissions_Text.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Retransmissions";
            // 
            // Retransmissions_Bar
            // 
            this.Retransmissions_Bar.BackColor = System.Drawing.Color.SteelBlue;
            this.Retransmissions_Bar.LargeChange = 1;
            this.Retransmissions_Bar.Location = new System.Drawing.Point(5, 164);
            this.Retransmissions_Bar.Maximum = 5;
            this.Retransmissions_Bar.Name = "Retransmissions_Bar";
            this.Retransmissions_Bar.Size = new System.Drawing.Size(156, 45);
            this.Retransmissions_Bar.TabIndex = 10;
            this.Retransmissions_Bar.Value = 2;
            // 
            // Timeout_Text
            // 
            this.Timeout_Text.Location = new System.Drawing.Point(6, 37);
            this.Timeout_Text.Name = "Timeout_Text";
            this.Timeout_Text.ReadOnly = true;
            this.Timeout_Text.Size = new System.Drawing.Size(156, 22);
            this.Timeout_Text.TabIndex = 6;
            this.Timeout_Text.TabStop = false;
            this.Timeout_Text.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Timeout";
            // 
            // Timeout_Bar
            // 
            this.Timeout_Bar.BackColor = System.Drawing.Color.SteelBlue;
            this.Timeout_Bar.LargeChange = 100;
            this.Timeout_Bar.Location = new System.Drawing.Point(5, 65);
            this.Timeout_Bar.Maximum = 10000;
            this.Timeout_Bar.Name = "Timeout_Bar";
            this.Timeout_Bar.Size = new System.Drawing.Size(157, 45);
            this.Timeout_Bar.SmallChange = 100;
            this.Timeout_Bar.TabIndex = 7;
            this.Timeout_Bar.Value = 500;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TransmissionType);
            this.groupBox1.Controls.Add(this.button_Send);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Master_Arguments);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.whichInstruction);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Master_SlaveAddress);
            this.groupBox1.Location = new System.Drawing.Point(210, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 357);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instruction";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Transmission type";
            // 
            // TransmissionType
            // 
            this.TransmissionType.FormattingEnabled = true;
            this.TransmissionType.Location = new System.Drawing.Point(8, 37);
            this.TransmissionType.Name = "TransmissionType";
            this.TransmissionType.Size = new System.Drawing.Size(186, 23);
            this.TransmissionType.TabIndex = 18;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(71, 323);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(123, 28);
            this.button_Send.TabIndex = 17;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arguments";
            // 
            // Master_Arguments
            // 
            this.Master_Arguments.Location = new System.Drawing.Point(7, 195);
            this.Master_Arguments.Name = "Master_Arguments";
            this.Master_Arguments.Size = new System.Drawing.Size(187, 113);
            this.Master_Arguments.TabIndex = 4;
            this.Master_Arguments.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Instruction number";
            // 
            // whichInstruction
            // 
            this.whichInstruction.FormattingEnabled = true;
            this.whichInstruction.Location = new System.Drawing.Point(122, 138);
            this.whichInstruction.Name = "whichInstruction";
            this.whichInstruction.Size = new System.Drawing.Size(72, 23);
            this.whichInstruction.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Slave address";
            // 
            // Master_SlaveAddress
            // 
            this.Master_SlaveAddress.Location = new System.Drawing.Point(7, 105);
            this.Master_SlaveAddress.Name = "Master_SlaveAddress";
            this.Master_SlaveAddress.Size = new System.Drawing.Size(187, 22);
            this.Master_SlaveAddress.TabIndex = 0;
            this.Master_SlaveAddress.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Beige;
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.Slave_RecievedText);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Slave";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(564, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 15);
            this.label17.TabIndex = 9;
            this.label17.Text = "Recieved text";
            // 
            // Slave_RecievedText
            // 
            this.Slave_RecievedText.Location = new System.Drawing.Point(439, 25);
            this.Slave_RecievedText.Name = "Slave_RecievedText";
            this.Slave_RecievedText.Size = new System.Drawing.Size(345, 389);
            this.Slave_RecievedText.TabIndex = 10;
            this.Slave_RecievedText.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox4.Controls.Add(this.buttonStartListening);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.Slave_Arguments);
            this.groupBox4.Location = new System.Drawing.Point(210, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 357);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Instruction";
            // 
            // buttonStartListening
            // 
            this.buttonStartListening.Location = new System.Drawing.Point(71, 323);
            this.buttonStartListening.Name = "buttonStartListening";
            this.buttonStartListening.Size = new System.Drawing.Size(123, 28);
            this.buttonStartListening.TabIndex = 17;
            this.buttonStartListening.Text = "Start listening";
            this.buttonStartListening.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "Arguments for instruction 2";
            // 
            // Slave_Arguments
            // 
            this.Slave_Arguments.Location = new System.Drawing.Point(6, 40);
            this.Slave_Arguments.Name = "Slave_Arguments";
            this.Slave_Arguments.Size = new System.Drawing.Size(187, 175);
            this.Slave_Arguments.TabIndex = 4;
            this.Slave_Arguments.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.Slave_SlaveAddress);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Slave_Port);
            this.groupBox3.Controls.Add(this.buttonSlaveConnect);
            this.groupBox3.Controls.Add(this.Slave_Time_Interval_Text);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Slave_Time_Interval_Bar);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 408);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Slave station address";
            // 
            // Slave_SlaveAddress
            // 
            this.Slave_SlaveAddress.Location = new System.Drawing.Point(5, 41);
            this.Slave_SlaveAddress.Name = "Slave_SlaveAddress";
            this.Slave_SlaveAddress.ReadOnly = true;
            this.Slave_SlaveAddress.Size = new System.Drawing.Size(156, 22);
            this.Slave_SlaveAddress.TabIndex = 17;
            this.Slave_SlaveAddress.TabStop = false;
            this.Slave_SlaveAddress.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Port";
            // 
            // Slave_Port
            // 
            this.Slave_Port.FormattingEnabled = true;
            this.Slave_Port.Location = new System.Drawing.Point(7, 205);
            this.Slave_Port.Name = "Slave_Port";
            this.Slave_Port.Size = new System.Drawing.Size(155, 23);
            this.Slave_Port.TabIndex = 15;
            // 
            // buttonSlaveConnect
            // 
            this.buttonSlaveConnect.Location = new System.Drawing.Point(7, 363);
            this.buttonSlaveConnect.Name = "buttonSlaveConnect";
            this.buttonSlaveConnect.Size = new System.Drawing.Size(155, 39);
            this.buttonSlaveConnect.TabIndex = 14;
            this.buttonSlaveConnect.Text = "Connect as Slave";
            this.buttonSlaveConnect.UseVisualStyleBackColor = true;
            // 
            // Slave_Time_Interval_Text
            // 
            this.Slave_Time_Interval_Text.Location = new System.Drawing.Point(5, 100);
            this.Slave_Time_Interval_Text.Name = "Slave_Time_Interval_Text";
            this.Slave_Time_Interval_Text.ReadOnly = true;
            this.Slave_Time_Interval_Text.Size = new System.Drawing.Size(156, 22);
            this.Slave_Time_Interval_Text.TabIndex = 11;
            this.Slave_Time_Interval_Text.TabStop = false;
            this.Slave_Time_Interval_Text.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Time interval";
            // 
            // Slave_Time_Interval_Bar
            // 
            this.Slave_Time_Interval_Bar.BackColor = System.Drawing.Color.SteelBlue;
            this.Slave_Time_Interval_Bar.LargeChange = 10;
            this.Slave_Time_Interval_Bar.Location = new System.Drawing.Point(5, 128);
            this.Slave_Time_Interval_Bar.Maximum = 1000;
            this.Slave_Time_Interval_Bar.Name = "Slave_Time_Interval_Bar";
            this.Slave_Time_Interval_Bar.Size = new System.Drawing.Size(156, 45);
            this.Slave_Time_Interval_Bar.SmallChange = 10;
            this.Slave_Time_Interval_Bar.TabIndex = 13;
            this.Slave_Time_Interval_Bar.Value = 500;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainWindow";
            this.Text = "Modbus communicator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Master_Time_Interval_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Retransmissions_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timeout_Bar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slave_Time_Interval_Bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar Timeout_Bar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox Master_Arguments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox whichInstruction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Master_SlaveAddress;
        private System.Windows.Forms.RichTextBox Timeout_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox Retransmissions_Text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar Retransmissions_Bar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox Master_RecievedText;
        private System.Windows.Forms.RichTextBox Master_Time_Interval_Text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar Master_Time_Interval_Bar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Master_Port;
        private System.Windows.Forms.Button buttonMasterConnect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox TransmissionType;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonStartListening;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox Slave_Arguments;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox Slave_SlaveAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Slave_Port;
        private System.Windows.Forms.Button buttonSlaveConnect;
        private System.Windows.Forms.RichTextBox Slave_Time_Interval_Text;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar Slave_Time_Interval_Bar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox Slave_RecievedText;
    }
}

