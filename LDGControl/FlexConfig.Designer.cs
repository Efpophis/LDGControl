namespace LDGControl
{
    partial class FlexConfig
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
            this.btnFlexCfgApply = new System.Windows.Forms.Button();
            this.btnFlexConfigCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFlexHost = new System.Windows.Forms.TextBox();
            this.numFlexPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEnableFlex = new System.Windows.Forms.CheckBox();
            this.btnDiscoveryEn = new System.Windows.Forms.RadioButton();
            this.btnFlexManual = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkFlexAutoConnect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numFlexPort)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFlexCfgApply
            // 
            this.btnFlexCfgApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFlexCfgApply.Location = new System.Drawing.Point(44, 219);
            this.btnFlexCfgApply.Name = "btnFlexCfgApply";
            this.btnFlexCfgApply.Size = new System.Drawing.Size(75, 23);
            this.btnFlexCfgApply.TabIndex = 0;
            this.btnFlexCfgApply.Text = "Apply";
            this.btnFlexCfgApply.UseVisualStyleBackColor = true;
            this.btnFlexCfgApply.Click += new System.EventHandler(this.btnFlexCfgApply_Click);
            // 
            // btnFlexConfigCancel
            // 
            this.btnFlexConfigCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFlexConfigCancel.Location = new System.Drawing.Point(341, 219);
            this.btnFlexConfigCancel.Name = "btnFlexConfigCancel";
            this.btnFlexConfigCancel.Size = new System.Drawing.Size(75, 23);
            this.btnFlexConfigCancel.TabIndex = 1;
            this.btnFlexConfigCancel.Text = "Cancel";
            this.btnFlexConfigCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Radio Host or IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:*";
            // 
            // txtFlexHost
            // 
            this.txtFlexHost.Enabled = false;
            this.txtFlexHost.Location = new System.Drawing.Point(176, 143);
            this.txtFlexHost.Name = "txtFlexHost";
            this.txtFlexHost.Size = new System.Drawing.Size(240, 20);
            this.txtFlexHost.TabIndex = 5;
            // 
            // numFlexPort
            // 
            this.numFlexPort.Enabled = false;
            this.numFlexPort.Location = new System.Drawing.Point(176, 169);
            this.numFlexPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numFlexPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFlexPort.Name = "numFlexPort";
            this.numFlexPort.Size = new System.Drawing.Size(120, 20);
            this.numFlexPort.TabIndex = 6;
            this.numFlexPort.Value = new decimal(new int[] {
            4992,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "*Don\'t change unless you know what you\'re doing";
            // 
            // chkEnableFlex
            // 
            this.chkEnableFlex.AutoSize = true;
            this.chkEnableFlex.Location = new System.Drawing.Point(47, 38);
            this.chkEnableFlex.Name = "chkEnableFlex";
            this.chkEnableFlex.Size = new System.Drawing.Size(134, 17);
            this.chkEnableFlex.TabIndex = 8;
            this.chkEnableFlex.Text = "Enable Flex Integration";
            this.chkEnableFlex.UseVisualStyleBackColor = true;
            this.chkEnableFlex.CheckStateChanged += new System.EventHandler(this.chkEnableFlex_CheckStateChanged);
            // 
            // btnDiscoveryEn
            // 
            this.btnDiscoveryEn.AutoSize = true;
            this.btnDiscoveryEn.Location = new System.Drawing.Point(3, 3);
            this.btnDiscoveryEn.Name = "btnDiscoveryEn";
            this.btnDiscoveryEn.Size = new System.Drawing.Size(158, 17);
            this.btnDiscoveryEn.TabIndex = 9;
            this.btnDiscoveryEn.TabStop = true;
            this.btnDiscoveryEn.Text = "Use Flex Discovery Protocol";
            this.btnDiscoveryEn.UseVisualStyleBackColor = true;
            // 
            // btnFlexManual
            // 
            this.btnFlexManual.AutoSize = true;
            this.btnFlexManual.Location = new System.Drawing.Point(3, 26);
            this.btnFlexManual.Name = "btnFlexManual";
            this.btnFlexManual.Size = new System.Drawing.Size(128, 17);
            this.btnFlexManual.TabIndex = 10;
            this.btnFlexManual.TabStop = true;
            this.btnFlexManual.Text = "Manual Configuration:";
            this.btnFlexManual.UseVisualStyleBackColor = true;
            this.btnFlexManual.CheckedChanged += new System.EventHandler(this.btnFlexManual_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDiscoveryEn);
            this.panel1.Controls.Add(this.btnFlexManual);
            this.panel1.Location = new System.Drawing.Point(44, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 50);
            this.panel1.TabIndex = 11;
            // 
            // chkFlexAutoConnect
            // 
            this.chkFlexAutoConnect.AutoSize = true;
            this.chkFlexAutoConnect.Location = new System.Drawing.Point(47, 62);
            this.chkFlexAutoConnect.Name = "chkFlexAutoConnect";
            this.chkFlexAutoConnect.Size = new System.Drawing.Size(131, 17);
            this.chkFlexAutoConnect.TabIndex = 12;
            this.chkFlexAutoConnect.Text = "Automatically Connect";
            this.chkFlexAutoConnect.UseVisualStyleBackColor = true;
            // 
            // FlexConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 254);
            this.Controls.Add(this.chkFlexAutoConnect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkEnableFlex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numFlexPort);
            this.Controls.Add(this.txtFlexHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFlexConfigCancel);
            this.Controls.Add(this.btnFlexCfgApply);
            this.Name = "FlexConfig";
            this.Text = "Flex Config";
            this.Load += new System.EventHandler(this.FlexConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFlexPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFlexCfgApply;
        private System.Windows.Forms.Button btnFlexConfigCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFlexHost;
        private System.Windows.Forms.NumericUpDown numFlexPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEnableFlex;
        private System.Windows.Forms.RadioButton btnDiscoveryEn;
        private System.Windows.Forms.RadioButton btnFlexManual;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkFlexAutoConnect;
    }
}