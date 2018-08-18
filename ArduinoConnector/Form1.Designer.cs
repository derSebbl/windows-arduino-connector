namespace ArduinoConnector
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.buttonConnection = new System.Windows.Forms.Button();
            this.textBoxBaudRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.textBoxSerialData = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxKeystrokeLeft = new System.Windows.Forms.TextBox();
            this.textBoxKeystrokeRight = new System.Windows.Forms.TextBox();
            this.labelKeystrokeRight = new System.Windows.Forms.Label();
            this.labelKeystrokeLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(16, 31);
            this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSerialPort.TabIndex = 0;
            // 
            // buttonConnection
            // 
            this.buttonConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConnection.Location = new System.Drawing.Point(16, 511);
            this.buttonConnection.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(100, 28);
            this.buttonConnection.TabIndex = 1;
            this.buttonConnection.Text = "Connect";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxBaudRate
            // 
            this.textBoxBaudRate.Location = new System.Drawing.Point(16, 80);
            this.textBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBaudRate.Name = "textBoxBaudRate";
            this.textBoxBaudRate.Size = new System.Drawing.Size(76, 22);
            this.textBoxBaudRate.TabIndex = 2;
            this.textBoxBaudRate.Text = "115200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(20, 487);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(102, 17);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Not Connected";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(185, 28);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 28);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(557, 467);
            this.checkBoxAutoScroll.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(98, 21);
            this.checkBoxAutoScroll.TabIndex = 8;
            this.checkBoxAutoScroll.Text = "Auto Scroll";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            this.checkBoxAutoScroll.CheckedChanged += new System.EventHandler(this.checkBoxAutoScroll_CheckedChanged);
            // 
            // textBoxSerialData
            // 
            this.textBoxSerialData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSerialData.HideSelection = false;
            this.textBoxSerialData.Location = new System.Drawing.Point(16, 113);
            this.textBoxSerialData.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSerialData.MaxLength = 0;
            this.textBoxSerialData.Name = "textBoxSerialData";
            this.textBoxSerialData.ReadOnly = true;
            this.textBoxSerialData.Size = new System.Drawing.Size(747, 341);
            this.textBoxSerialData.TabIndex = 7;
            this.textBoxSerialData.Text = "";
            this.textBoxSerialData.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 462);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Clear Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(439, 462);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxKeystrokeLeft
            // 
            this.textBoxKeystrokeLeft.Location = new System.Drawing.Point(557, 80);
            this.textBoxKeystrokeLeft.Name = "textBoxKeystrokeLeft";
            this.textBoxKeystrokeLeft.Size = new System.Drawing.Size(100, 22);
            this.textBoxKeystrokeLeft.TabIndex = 11;
            // 
            // textBoxKeystrokeRight
            // 
            this.textBoxKeystrokeRight.Location = new System.Drawing.Point(663, 80);
            this.textBoxKeystrokeRight.Name = "textBoxKeystrokeRight";
            this.textBoxKeystrokeRight.Size = new System.Drawing.Size(100, 22);
            this.textBoxKeystrokeRight.TabIndex = 12;
            // 
            // labelKeystrokeRight
            // 
            this.labelKeystrokeRight.AutoSize = true;
            this.labelKeystrokeRight.Location = new System.Drawing.Point(660, 61);
            this.labelKeystrokeRight.Name = "labelKeystrokeRight";
            this.labelKeystrokeRight.Size = new System.Drawing.Size(108, 17);
            this.labelKeystrokeRight.TabIndex = 13;
            this.labelKeystrokeRight.Text = "Keystroke Right";
            // 
            // labelKeystrokeLeft
            // 
            this.labelKeystrokeLeft.AutoSize = true;
            this.labelKeystrokeLeft.Location = new System.Drawing.Point(554, 61);
            this.labelKeystrokeLeft.Name = "labelKeystrokeLeft";
            this.labelKeystrokeLeft.Size = new System.Drawing.Size(99, 17);
            this.labelKeystrokeLeft.TabIndex = 14;
            this.labelKeystrokeLeft.Text = "Keystroke Left";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 554);
            this.Controls.Add(this.labelKeystrokeLeft);
            this.Controls.Add(this.labelKeystrokeRight);
            this.Controls.Add(this.textBoxKeystrokeRight);
            this.Controls.Add(this.textBoxKeystrokeLeft);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSerialData);
            this.Controls.Add(this.checkBoxAutoScroll);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBaudRate);
            this.Controls.Add(this.buttonConnection);
            this.Controls.Add(this.comboBoxSerialPort);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Arduino Connector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.TextBox textBoxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.CheckBox checkBoxAutoScroll;
        private System.Windows.Forms.RichTextBox textBoxSerialData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxKeystrokeLeft;
        private System.Windows.Forms.TextBox textBoxKeystrokeRight;
        private System.Windows.Forms.Label labelKeystrokeRight;
        private System.Windows.Forms.Label labelKeystrokeLeft;
    }
}

