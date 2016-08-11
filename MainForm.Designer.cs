namespace Comport
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.IDC_Input = new System.Windows.Forms.TextBox();
            this.IDC_Send = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IDC_Sent = new System.Windows.Forms.TextBox();
            this.IDC_Search = new System.Windows.Forms.Button();
            this.IDC_Connect = new System.Windows.Forms.Button();
            this.IDC_PortName = new System.Windows.Forms.ComboBox();
            this.IDC_Output = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.IDC_Clear = new System.Windows.Forms.Button();
            this.IDC_BaudRate = new System.Windows.Forms.ComboBox();
            this.IDC_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IDC_ClearInput = new System.Windows.Forms.Button();
            this.IDC_OutputDisplayMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.IDC_InputDisplayMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IDC_Loop = new System.Windows.Forms.CheckBox();
            this.IDC_test = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDC_Input
            // 
            this.IDC_Input.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDC_Input.Location = new System.Drawing.Point(5, 32);
            this.IDC_Input.Multiline = true;
            this.IDC_Input.Name = "IDC_Input";
            this.IDC_Input.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.IDC_Input.Size = new System.Drawing.Size(380, 207);
            this.IDC_Input.TabIndex = 0;
            // 
            // IDC_Send
            // 
            this.IDC_Send.BackColor = System.Drawing.Color.LightSkyBlue;
            this.IDC_Send.Location = new System.Drawing.Point(322, 529);
            this.IDC_Send.Name = "IDC_Send";
            this.IDC_Send.Size = new System.Drawing.Size(75, 48);
            this.IDC_Send.TabIndex = 5;
            this.IDC_Send.Text = "Send";
            this.IDC_Send.UseVisualStyleBackColor = false;
            this.IDC_Send.Click += new System.EventHandler(this.IDC_Send_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.IDC_Sent);
            this.groupBox1.Controls.Add(this.IDC_Input);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 476);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Input";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Sent";
            // 
            // IDC_Sent
            // 
            this.IDC_Sent.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDC_Sent.Location = new System.Drawing.Point(5, 260);
            this.IDC_Sent.Multiline = true;
            this.IDC_Sent.Name = "IDC_Sent";
            this.IDC_Sent.ReadOnly = true;
            this.IDC_Sent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.IDC_Sent.Size = new System.Drawing.Size(380, 210);
            this.IDC_Sent.TabIndex = 0;
            // 
            // IDC_Search
            // 
            this.IDC_Search.Location = new System.Drawing.Point(156, 500);
            this.IDC_Search.Name = "IDC_Search";
            this.IDC_Search.Size = new System.Drawing.Size(75, 23);
            this.IDC_Search.TabIndex = 10;
            this.IDC_Search.Text = "Search";
            this.IDC_Search.UseVisualStyleBackColor = true;
            this.IDC_Search.Click += new System.EventHandler(this.IDC_Search_Click);
            // 
            // IDC_Connect
            // 
            this.IDC_Connect.Location = new System.Drawing.Point(156, 529);
            this.IDC_Connect.Name = "IDC_Connect";
            this.IDC_Connect.Size = new System.Drawing.Size(75, 48);
            this.IDC_Connect.TabIndex = 9;
            this.IDC_Connect.Text = "Connect";
            this.IDC_Connect.UseVisualStyleBackColor = true;
            this.IDC_Connect.Click += new System.EventHandler(this.IDC_Connect_Click);
            // 
            // IDC_PortName
            // 
            this.IDC_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDC_PortName.FormattingEnabled = true;
            this.IDC_PortName.Location = new System.Drawing.Point(72, 501);
            this.IDC_PortName.Name = "IDC_PortName";
            this.IDC_PortName.Size = new System.Drawing.Size(78, 21);
            this.IDC_PortName.TabIndex = 8;
            // 
            // IDC_Output
            // 
            this.IDC_Output.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDC_Output.Location = new System.Drawing.Point(7, 32);
            this.IDC_Output.Multiline = true;
            this.IDC_Output.Name = "IDC_Output";
            this.IDC_Output.ReadOnly = true;
            this.IDC_Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.IDC_Output.Size = new System.Drawing.Size(380, 438);
            this.IDC_Output.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.IDC_Output);
            this.groupBox2.Location = new System.Drawing.Point(413, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 476);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Output";
            // 
            // IDC_Clear
            // 
            this.IDC_Clear.Location = new System.Drawing.Point(725, 529);
            this.IDC_Clear.Name = "IDC_Clear";
            this.IDC_Clear.Size = new System.Drawing.Size(75, 48);
            this.IDC_Clear.TabIndex = 10;
            this.IDC_Clear.Text = "Clear";
            this.IDC_Clear.UseVisualStyleBackColor = true;
            this.IDC_Clear.Click += new System.EventHandler(this.IDC_Clear_Click);
            // 
            // IDC_BaudRate
            // 
            this.IDC_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDC_BaudRate.FormattingEnabled = true;
            this.IDC_BaudRate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.IDC_BaudRate.Location = new System.Drawing.Point(72, 529);
            this.IDC_BaudRate.Name = "IDC_BaudRate";
            this.IDC_BaudRate.Size = new System.Drawing.Size(78, 21);
            this.IDC_BaudRate.TabIndex = 11;
            // 
            // IDC_type
            // 
            this.IDC_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDC_type.FormattingEnabled = true;
            this.IDC_type.Items.AddRange(new object[] {
            "Hex",
            "ASCII"});
            this.IDC_type.Location = new System.Drawing.Point(72, 556);
            this.IDC_type.Name = "IDC_type";
            this.IDC_type.Size = new System.Drawing.Size(78, 21);
            this.IDC_type.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Com Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Baud Rate";
            // 
            // IDC_ClearInput
            // 
            this.IDC_ClearInput.Location = new System.Drawing.Point(241, 529);
            this.IDC_ClearInput.Name = "IDC_ClearInput";
            this.IDC_ClearInput.Size = new System.Drawing.Size(75, 48);
            this.IDC_ClearInput.TabIndex = 15;
            this.IDC_ClearInput.Text = "Clear";
            this.IDC_ClearInput.UseVisualStyleBackColor = true;
            this.IDC_ClearInput.Click += new System.EventHandler(this.IDC_ClearInput_Click);
            // 
            // IDC_OutputDisplayMode
            // 
            this.IDC_OutputDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDC_OutputDisplayMode.FormattingEnabled = true;
            this.IDC_OutputDisplayMode.Items.AddRange(new object[] {
            "NONE",
            "BOTH",
            "HEX",
            "ASCII"});
            this.IDC_OutputDisplayMode.Location = new System.Drawing.Point(726, 499);
            this.IDC_OutputDisplayMode.Name = "IDC_OutputDisplayMode";
            this.IDC_OutputDisplayMode.Size = new System.Drawing.Size(74, 21);
            this.IDC_OutputDisplayMode.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Display Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Display Mode";
            // 
            // IDC_InputDisplayMode
            // 
            this.IDC_InputDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDC_InputDisplayMode.FormattingEnabled = true;
            this.IDC_InputDisplayMode.Items.AddRange(new object[] {
            "NONE",
            "BOTH",
            "HEX",
            "ASCII"});
            this.IDC_InputDisplayMode.Location = new System.Drawing.Point(322, 498);
            this.IDC_InputDisplayMode.Name = "IDC_InputDisplayMode";
            this.IDC_InputDisplayMode.Size = new System.Drawing.Size(74, 21);
            this.IDC_InputDisplayMode.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 557);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Encoding";
            // 
            // IDC_Loop
            // 
            this.IDC_Loop.AutoSize = true;
            this.IDC_Loop.Location = new System.Drawing.Point(413, 500);
            this.IDC_Loop.Name = "IDC_Loop";
            this.IDC_Loop.Size = new System.Drawing.Size(46, 17);
            this.IDC_Loop.TabIndex = 21;
            this.IDC_Loop.Text = "loop";
            this.IDC_Loop.UseVisualStyleBackColor = true;
            // 
            // IDC_test
            // 
            this.IDC_test.Location = new System.Drawing.Point(413, 554);
            this.IDC_test.Name = "IDC_test";
            this.IDC_test.Size = new System.Drawing.Size(75, 23);
            this.IDC_test.TabIndex = 22;
            this.IDC_test.Text = "Test";
            this.IDC_test.UseVisualStyleBackColor = true;
            this.IDC_test.Click += new System.EventHandler(this.IDC_test_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 586);
            this.Controls.Add(this.IDC_test);
            this.Controls.Add(this.IDC_Loop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.IDC_InputDisplayMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IDC_OutputDisplayMode);
            this.Controls.Add(this.IDC_ClearInput);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDC_PortName);
            this.Controls.Add(this.IDC_Clear);
            this.Controls.Add(this.IDC_Send);
            this.Controls.Add(this.IDC_Connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDC_Search);
            this.Controls.Add(this.IDC_type);
            this.Controls.Add(this.IDC_BaudRate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = " ComPort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDC_Input;
        private System.Windows.Forms.Button IDC_Send;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox IDC_PortName;
        private System.Windows.Forms.TextBox IDC_Output;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button IDC_Clear;
        private System.Windows.Forms.Button IDC_Connect;
        private System.Windows.Forms.Button IDC_Search;
        private System.Windows.Forms.TextBox IDC_Sent;
        private System.Windows.Forms.ComboBox IDC_BaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox IDC_type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button IDC_ClearInput;
        private System.Windows.Forms.ComboBox IDC_OutputDisplayMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox IDC_InputDisplayMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox IDC_Loop;
        private System.Windows.Forms.Button IDC_test;
    }
}

