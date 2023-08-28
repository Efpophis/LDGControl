namespace LDGControl
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnExit = new System.Windows.Forms.Button();
            this.fwdMeter = new System.Windows.Forms.ProgressBar();
            this.refMeter = new System.Windows.Forms.ProgressBar();
            this.swrMeter = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFwd = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.Label();
            this.lblbad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voltageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v138 = new System.Windows.Forms.ToolStripMenuItem();
            this.v135 = new System.Windows.Forms.ToolStripMenuItem();
            this.v130 = new System.Windows.Forms.ToolStripMenuItem();
            this.v125 = new System.Windows.Forms.ToolStripMenuItem();
            this.v120 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFlexHost = new System.Windows.Forms.ToolStripTextBox();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFlexPort = new System.Windows.Forms.ToolStripTextBox();
            this.ampOperateBtn = new System.Windows.Forms.RadioButton();
            this.ampStbyBtn = new System.Windows.Forms.RadioButton();
            this.ampResetBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAmpInit = new System.Windows.Forms.Button();
            this.ampPortsBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nameBand = new System.Windows.Forms.Label();
            this.lblBand = new System.Windows.Forms.Label();
            this.lblWtf = new System.Windows.Forms.Label();
            this.lblTuneStatus = new System.Windows.Forms.Label();
            this.WTF = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnFullTune = new System.Windows.Forms.Button();
            this.btnMemTune = new System.Windows.Forms.Button();
            this.btnBypass = new System.Windows.Forms.Button();
            this.btnAntTog = new System.Windows.Forms.Button();
            this.btnTunerInit = new System.Windows.Forms.Button();
            this.cmbTunerPorts = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkPeak = new System.Windows.Forms.CheckBox();
            this.tmrFwdPeak = new System.Windows.Forms.Timer(this.components);
            this.tmrRefPeak = new System.Windows.Forms.Timer(this.components);
            this.tmrSwrPeak = new System.Windows.Forms.Timer(this.components);
            this.b160 = new System.Windows.Forms.Button();
            this.b80 = new System.Windows.Forms.Button();
            this.b40 = new System.Windows.Forms.Button();
            this.b30 = new System.Windows.Forms.Button();
            this.b20 = new System.Windows.Forms.Button();
            this.b17 = new System.Windows.Forms.Button();
            this.b15 = new System.Windows.Forms.Button();
            this.b12 = new System.Windows.Forms.Button();
            this.b10 = new System.Windows.Forms.Button();
            this.b60 = new System.Windows.Forms.Button();
            this.b6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblSwr = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnExit.Location = new System.Drawing.Point(454, 308);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 34);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // fwdMeter
            // 
            this.fwdMeter.BackColor = System.Drawing.SystemColors.Control;
            this.fwdMeter.Location = new System.Drawing.Point(80, 25);
            this.fwdMeter.Maximum = 8;
            this.fwdMeter.Name = "fwdMeter";
            this.fwdMeter.Size = new System.Drawing.Size(410, 13);
            this.fwdMeter.Step = 1;
            this.fwdMeter.TabIndex = 1;
            // 
            // refMeter
            // 
            this.refMeter.Location = new System.Drawing.Point(80, 44);
            this.refMeter.Maximum = 8;
            this.refMeter.Name = "refMeter";
            this.refMeter.Size = new System.Drawing.Size(410, 13);
            this.refMeter.Step = 1;
            this.refMeter.TabIndex = 2;
            // 
            // swrMeter
            // 
            this.swrMeter.Location = new System.Drawing.Point(80, 63);
            this.swrMeter.Maximum = 8;
            this.swrMeter.Name = "swrMeter";
            this.swrMeter.Size = new System.Drawing.Size(410, 13);
            this.swrMeter.Step = 1;
            this.swrMeter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FWD Pwr:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "REF Pwr:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(5, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "VSWR:";
            // 
            // lblFwd
            // 
            this.lblFwd.AutoSize = true;
            this.lblFwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFwd.Location = new System.Drawing.Point(513, 27);
            this.lblFwd.Name = "lblFwd";
            this.lblFwd.Size = new System.Drawing.Size(18, 13);
            this.lblFwd.TabIndex = 7;
            this.lblFwd.Text = "W";
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRef.Location = new System.Drawing.Point(513, 46);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(18, 13);
            this.lblRef.TabIndex = 8;
            this.lblRef.Text = "W";
            // 
            // lblbad
            // 
            this.lblbad.AutoSize = true;
            this.lblbad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblbad.Location = new System.Drawing.Point(484, 79);
            this.lblbad.Name = "lblbad";
            this.lblbad.Size = new System.Drawing.Size(29, 13);
            this.lblbad.TabIndex = 9;
            this.lblbad.Text = "BAD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(120, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(177, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "25";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(229, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(279, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(332, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "250";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(386, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "500";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(440, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "750";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(113, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "1.1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.Location = new System.Drawing.Point(167, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "1.3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.Location = new System.Drawing.Point(219, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "1.5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.Location = new System.Drawing.Point(272, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "1.7";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.Location = new System.Drawing.Point(325, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "2.0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label16.Location = new System.Drawing.Point(379, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "2.5";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label17.Location = new System.Drawing.Point(433, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "3.0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label18.Location = new System.Drawing.Point(489, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 15);
            this.label18.TabIndex = 24;
            this.label18.Text = "1000";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.flexToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voltageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // voltageToolStripMenuItem
            // 
            this.voltageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.v138,
            this.v135,
            this.v130,
            this.v125,
            this.v120});
            this.voltageToolStripMenuItem.Name = "voltageToolStripMenuItem";
            this.voltageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.voltageToolStripMenuItem.Text = "Tuner PS Voltage";
            // 
            // v138
            // 
            this.v138.Checked = true;
            this.v138.CheckState = System.Windows.Forms.CheckState.Checked;
            this.v138.Name = "v138";
            this.v138.Size = new System.Drawing.Size(180, 22);
            this.v138.Text = "13.8";
            this.v138.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // v135
            // 
            this.v135.Name = "v135";
            this.v135.Size = new System.Drawing.Size(180, 22);
            this.v135.Text = "13.5";
            this.v135.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // v130
            // 
            this.v130.Name = "v130";
            this.v130.Size = new System.Drawing.Size(180, 22);
            this.v130.Text = "13.0";
            this.v130.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // v125
            // 
            this.v125.Name = "v125";
            this.v125.Size = new System.Drawing.Size(180, 22);
            this.v125.Text = "12.5";
            this.v125.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // v120
            // 
            this.v120.Name = "v120";
            this.v120.Size = new System.Drawing.Size(180, 22);
            this.v120.Text = "12.0";
            this.v120.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.mnuAbout_onClick);
            // 
            // flexToolStripMenuItem
            // 
            this.flexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.portToolStripMenuItem});
            this.flexToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flexToolStripMenuItem.Name = "flexToolStripMenuItem";
            this.flexToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.flexToolStripMenuItem.Text = "Fle&x";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtFlexHost});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Host";
            // 
            // txtFlexHost
            // 
            this.txtFlexHost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFlexHost.Name = "txtFlexHost";
            this.txtFlexHost.Size = new System.Drawing.Size(100, 23);
            this.txtFlexHost.TextChanged += new System.EventHandler(this.onFlexHostChanged);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtFlexPort});
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // txtFlexPort
            // 
            this.txtFlexPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFlexPort.Name = "txtFlexPort";
            this.txtFlexPort.Size = new System.Drawing.Size(100, 23);
            this.txtFlexPort.TextChanged += new System.EventHandler(this.onFlexPortChanged);
            // 
            // ampOperateBtn
            // 
            this.ampOperateBtn.AutoSize = true;
            this.ampOperateBtn.Checked = true;
            this.ampOperateBtn.Enabled = false;
            this.ampOperateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ampOperateBtn.Location = new System.Drawing.Point(240, 32);
            this.ampOperateBtn.Name = "ampOperateBtn";
            this.ampOperateBtn.Size = new System.Drawing.Size(63, 17);
            this.ampOperateBtn.TabIndex = 27;
            this.ampOperateBtn.TabStop = true;
            this.ampOperateBtn.Text = "Operate";
            this.ampOperateBtn.UseVisualStyleBackColor = true;
            this.ampOperateBtn.CheckedChanged += new System.EventHandler(this.on_ampOpCheckedChanged);
            // 
            // ampStbyBtn
            // 
            this.ampStbyBtn.AutoSize = true;
            this.ampStbyBtn.Enabled = false;
            this.ampStbyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ampStbyBtn.Location = new System.Drawing.Point(240, 12);
            this.ampStbyBtn.Name = "ampStbyBtn";
            this.ampStbyBtn.Size = new System.Drawing.Size(64, 17);
            this.ampStbyBtn.TabIndex = 28;
            this.ampStbyBtn.Text = "Standby";
            this.ampStbyBtn.UseVisualStyleBackColor = true;
            this.ampStbyBtn.CheckedChanged += new System.EventHandler(this.on_AmpStbyCheckChanged);
            // 
            // ampResetBtn
            // 
            this.ampResetBtn.Enabled = false;
            this.ampResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ampResetBtn.Location = new System.Drawing.Point(345, 19);
            this.ampResetBtn.Name = "ampResetBtn";
            this.ampResetBtn.Size = new System.Drawing.Size(75, 22);
            this.ampResetBtn.TabIndex = 29;
            this.ampResetBtn.Text = "Reset";
            this.ampResetBtn.UseVisualStyleBackColor = true;
            this.ampResetBtn.Click += new System.EventHandler(this.on_AmpResetClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAmpInit);
            this.groupBox1.Controls.Add(this.ampPortsBox);
            this.groupBox1.Controls.Add(this.ampOperateBtn);
            this.groupBox1.Controls.Add(this.ampResetBtn);
            this.groupBox1.Controls.Add(this.ampStbyBtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 58);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amplifier";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAmpInit
            // 
            this.btnAmpInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAmpInit.Location = new System.Drawing.Point(115, 19);
            this.btnAmpInit.Name = "btnAmpInit";
            this.btnAmpInit.Padding = new System.Windows.Forms.Padding(1);
            this.btnAmpInit.Size = new System.Drawing.Size(95, 22);
            this.btnAmpInit.TabIndex = 31;
            this.btnAmpInit.Text = "Initialize";
            this.btnAmpInit.UseVisualStyleBackColor = true;
            this.btnAmpInit.Click += new System.EventHandler(this.btnAmpInit_Click);
            // 
            // ampPortsBox
            // 
            this.ampPortsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ampPortsBox.FormattingEnabled = true;
            this.ampPortsBox.Location = new System.Drawing.Point(7, 19);
            this.ampPortsBox.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.ampPortsBox.Name = "ampPortsBox";
            this.ampPortsBox.Size = new System.Drawing.Size(99, 21);
            this.ampPortsBox.TabIndex = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nameBand);
            this.groupBox2.Controls.Add(this.lblBand);
            this.groupBox2.Controls.Add(this.lblWtf);
            this.groupBox2.Controls.Add(this.lblTuneStatus);
            this.groupBox2.Controls.Add(this.WTF);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.btnFullTune);
            this.groupBox2.Controls.Add(this.btnMemTune);
            this.groupBox2.Controls.Add(this.btnBypass);
            this.groupBox2.Controls.Add(this.btnAntTog);
            this.groupBox2.Controls.Add(this.btnTunerInit);
            this.groupBox2.Controls.Add(this.cmbTunerPorts);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 106);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tuner";
            // 
            // nameBand
            // 
            this.nameBand.AutoSize = true;
            this.nameBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nameBand.Location = new System.Drawing.Point(120, 54);
            this.nameBand.Name = "nameBand";
            this.nameBand.Size = new System.Drawing.Size(35, 13);
            this.nameBand.TabIndex = 38;
            this.nameBand.Text = "Band:";
            // 
            // lblBand
            // 
            this.lblBand.AutoSize = true;
            this.lblBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblBand.Location = new System.Drawing.Point(178, 54);
            this.lblBand.Name = "lblBand";
            this.lblBand.Size = new System.Drawing.Size(53, 13);
            this.lblBand.TabIndex = 26;
            this.lblBand.Text = "Unknown";
            // 
            // lblWtf
            // 
            this.lblWtf.AutoSize = true;
            this.lblWtf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblWtf.Location = new System.Drawing.Point(120, 79);
            this.lblWtf.Name = "lblWtf";
            this.lblWtf.Size = new System.Drawing.Size(34, 13);
            this.lblWtf.TabIndex = 28;
            this.lblWtf.Text = "WTF:";
            // 
            // lblTuneStatus
            // 
            this.lblTuneStatus.AutoSize = true;
            this.lblTuneStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblTuneStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTuneStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTuneStatus.Location = new System.Drawing.Point(484, 22);
            this.lblTuneStatus.Name = "lblTuneStatus";
            this.lblTuneStatus.Padding = new System.Windows.Forms.Padding(2);
            this.lblTuneStatus.Size = new System.Drawing.Size(37, 17);
            this.lblTuneStatus.TabIndex = 7;
            this.lblTuneStatus.Text = "None";
            // 
            // WTF
            // 
            this.WTF.AutoSize = true;
            this.WTF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.WTF.Location = new System.Drawing.Point(181, 79);
            this.WTF.Name = "WTF";
            this.WTF.Size = new System.Drawing.Size(25, 13);
            this.WTF.TabIndex = 27;
            this.WTF.Text = "???";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label20.Location = new System.Drawing.Point(343, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Last Tune Result:";
            // 
            // btnFullTune
            // 
            this.btnFullTune.Enabled = false;
            this.btnFullTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullTune.Location = new System.Drawing.Point(345, 57);
            this.btnFullTune.Name = "btnFullTune";
            this.btnFullTune.Size = new System.Drawing.Size(84, 39);
            this.btnFullTune.TabIndex = 5;
            this.btnFullTune.Text = "Full Tune";
            this.toolTip1.SetToolTip(this.btnFullTune, "Forces a full tune");
            this.btnFullTune.UseVisualStyleBackColor = true;
            this.btnFullTune.Click += new System.EventHandler(this.btnFullTune_Click);
            // 
            // btnMemTune
            // 
            this.btnMemTune.Enabled = false;
            this.btnMemTune.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemTune.Location = new System.Drawing.Point(463, 57);
            this.btnMemTune.Name = "btnMemTune";
            this.btnMemTune.Size = new System.Drawing.Size(84, 39);
            this.btnMemTune.TabIndex = 4;
            this.btnMemTune.Text = "Memory Tune";
            this.toolTip1.SetToolTip(this.btnMemTune, "Forces a Memory Tune");
            this.btnMemTune.UseVisualStyleBackColor = true;
            this.btnMemTune.Click += new System.EventHandler(this.btnMemTune_Click);
            // 
            // btnBypass
            // 
            this.btnBypass.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBypass.Enabled = false;
            this.btnBypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBypass.Location = new System.Drawing.Point(9, 73);
            this.btnBypass.Name = "btnBypass";
            this.btnBypass.Padding = new System.Windows.Forms.Padding(1);
            this.btnBypass.Size = new System.Drawing.Size(97, 22);
            this.btnBypass.TabIndex = 3;
            this.btnBypass.Text = "Bypass";
            this.toolTip1.SetToolTip(this.btnBypass, "Toggles between Bypass or Auto Tune");
            this.btnBypass.UseVisualStyleBackColor = false;
            this.btnBypass.Click += new System.EventHandler(this.btnBypass_Click);
            // 
            // btnAntTog
            // 
            this.btnAntTog.Enabled = false;
            this.btnAntTog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAntTog.Location = new System.Drawing.Point(8, 44);
            this.btnAntTog.Name = "btnAntTog";
            this.btnAntTog.Size = new System.Drawing.Size(98, 22);
            this.btnAntTog.TabIndex = 2;
            this.btnAntTog.Text = "Antenna 1";
            this.toolTip1.SetToolTip(this.btnAntTog, "Toggle selected antenna");
            this.btnAntTog.UseVisualStyleBackColor = true;
            this.btnAntTog.Click += new System.EventHandler(this.btnAntTog_Click);
            // 
            // btnTunerInit
            // 
            this.btnTunerInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTunerInit.Location = new System.Drawing.Point(115, 20);
            this.btnTunerInit.Name = "btnTunerInit";
            this.btnTunerInit.Padding = new System.Windows.Forms.Padding(1);
            this.btnTunerInit.Size = new System.Drawing.Size(95, 22);
            this.btnTunerInit.TabIndex = 1;
            this.btnTunerInit.Text = "Initialize";
            this.btnTunerInit.UseVisualStyleBackColor = true;
            this.btnTunerInit.Click += new System.EventHandler(this.btnTunerInit_Click);
            // 
            // cmbTunerPorts
            // 
            this.cmbTunerPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbTunerPorts.FormattingEnabled = true;
            this.cmbTunerPorts.Location = new System.Drawing.Point(7, 20);
            this.cmbTunerPorts.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.cmbTunerPorts.Name = "cmbTunerPorts";
            this.cmbTunerPorts.Size = new System.Drawing.Size(99, 21);
            this.cmbTunerPorts.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(3, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(544, 124);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Meter";
            // 
            // chkPeak
            // 
            this.chkPeak.AutoSize = true;
            this.chkPeak.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.chkPeak.Location = new System.Drawing.Point(8, 91);
            this.chkPeak.Margin = new System.Windows.Forms.Padding(0);
            this.chkPeak.Name = "chkPeak";
            this.chkPeak.Size = new System.Drawing.Size(74, 17);
            this.chkPeak.TabIndex = 36;
            this.chkPeak.Text = "Peak Hold";
            this.chkPeak.UseVisualStyleBackColor = false;
            // 
            // tmrFwdPeak
            // 
            this.tmrFwdPeak.Interval = 250;
            this.tmrFwdPeak.Tick += new System.EventHandler(this.FwdTick);
            // 
            // tmrRefPeak
            // 
            this.tmrRefPeak.Interval = 250;
            this.tmrRefPeak.Tick += new System.EventHandler(this.ReflTick);
            // 
            // tmrSwrPeak
            // 
            this.tmrSwrPeak.Interval = 750;
            this.tmrSwrPeak.Tick += new System.EventHandler(this.swrTick);
            // 
            // b160
            // 
            this.b160.BackColor = System.Drawing.Color.Transparent;
            this.b160.CausesValidation = false;
            this.b160.Enabled = false;
            this.b160.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b160.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.b160.ForeColor = System.Drawing.Color.Black;
            this.b160.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b160.Location = new System.Drawing.Point(9, 17);
            this.b160.Name = "b160";
            this.b160.Size = new System.Drawing.Size(43, 19);
            this.b160.TabIndex = 42;
            this.b160.Text = "160";
            this.b160.UseVisualStyleBackColor = false;
            // 
            // b80
            // 
            this.b80.BackColor = System.Drawing.Color.Transparent;
            this.b80.Enabled = false;
            this.b80.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.b80.ForeColor = System.Drawing.Color.Black;
            this.b80.Location = new System.Drawing.Point(61, 17);
            this.b80.Name = "b80";
            this.b80.Size = new System.Drawing.Size(43, 19);
            this.b80.TabIndex = 43;
            this.b80.Text = "80";
            this.b80.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b80.UseVisualStyleBackColor = false;
            // 
            // b40
            // 
            this.b40.BackColor = System.Drawing.Color.Transparent;
            this.b40.Enabled = false;
            this.b40.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.b40.ForeColor = System.Drawing.Color.Black;
            this.b40.Location = new System.Drawing.Point(165, 17);
            this.b40.Name = "b40";
            this.b40.Size = new System.Drawing.Size(43, 19);
            this.b40.TabIndex = 44;
            this.b40.Text = "40";
            this.b40.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b40.UseVisualStyleBackColor = false;
            // 
            // b30
            // 
            this.b30.BackColor = System.Drawing.Color.Transparent;
            this.b30.Enabled = false;
            this.b30.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.b30.ForeColor = System.Drawing.Color.Black;
            this.b30.Location = new System.Drawing.Point(215, 17);
            this.b30.Name = "b30";
            this.b30.Size = new System.Drawing.Size(43, 19);
            this.b30.TabIndex = 45;
            this.b30.Text = "30";
            this.b30.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b30.UseVisualStyleBackColor = false;
            // 
            // b20
            // 
            this.b20.BackColor = System.Drawing.Color.Transparent;
            this.b20.Enabled = false;
            this.b20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.b20.ForeColor = System.Drawing.Color.Black;
            this.b20.Location = new System.Drawing.Point(265, 17);
            this.b20.Name = "b20";
            this.b20.Size = new System.Drawing.Size(43, 19);
            this.b20.TabIndex = 46;
            this.b20.Text = "20";
            this.b20.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b20.UseVisualStyleBackColor = false;
            // 
            // b17
            // 
            this.b17.BackColor = System.Drawing.Color.Transparent;
            this.b17.Enabled = false;
            this.b17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b17.ForeColor = System.Drawing.Color.Black;
            this.b17.Location = new System.Drawing.Point(315, 17);
            this.b17.Name = "b17";
            this.b17.Size = new System.Drawing.Size(43, 19);
            this.b17.TabIndex = 47;
            this.b17.Text = "17";
            this.b17.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b17.UseVisualStyleBackColor = false;
            // 
            // b15
            // 
            this.b15.BackColor = System.Drawing.Color.Transparent;
            this.b15.Enabled = false;
            this.b15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b15.ForeColor = System.Drawing.Color.Black;
            this.b15.Location = new System.Drawing.Point(366, 17);
            this.b15.Name = "b15";
            this.b15.Size = new System.Drawing.Size(43, 19);
            this.b15.TabIndex = 48;
            this.b15.Text = "15";
            this.b15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b15.UseVisualStyleBackColor = false;
            // 
            // b12
            // 
            this.b12.BackColor = System.Drawing.Color.Transparent;
            this.b12.Enabled = false;
            this.b12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b12.ForeColor = System.Drawing.Color.Black;
            this.b12.Location = new System.Drawing.Point(416, 17);
            this.b12.Name = "b12";
            this.b12.Size = new System.Drawing.Size(43, 19);
            this.b12.TabIndex = 49;
            this.b12.Text = "12";
            this.b12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b12.UseVisualStyleBackColor = false;
            // 
            // b10
            // 
            this.b10.BackColor = System.Drawing.Color.Transparent;
            this.b10.Enabled = false;
            this.b10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b10.ForeColor = System.Drawing.Color.Black;
            this.b10.Location = new System.Drawing.Point(468, 17);
            this.b10.Name = "b10";
            this.b10.Size = new System.Drawing.Size(43, 19);
            this.b10.TabIndex = 50;
            this.b10.Text = "10";
            this.b10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b10.UseVisualStyleBackColor = false;
            // 
            // b60
            // 
            this.b60.BackColor = System.Drawing.Color.Transparent;
            this.b60.Enabled = false;
            this.b60.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.b60.ForeColor = System.Drawing.Color.Black;
            this.b60.Location = new System.Drawing.Point(113, 17);
            this.b60.Name = "b60";
            this.b60.Size = new System.Drawing.Size(43, 19);
            this.b60.TabIndex = 51;
            this.b60.Text = "60";
            this.b60.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b60.UseVisualStyleBackColor = false;
            // 
            // b6
            // 
            this.b6.BackColor = System.Drawing.Color.Transparent;
            this.b6.Enabled = false;
            this.b6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.b6.ForeColor = System.Drawing.Color.Black;
            this.b6.Location = new System.Drawing.Point(520, 17);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(43, 19);
            this.b6.TabIndex = 52;
            this.b6.Text = "6";
            this.b6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b6.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox3.Controls.Add(this.b6);
            this.groupBox3.Controls.Add(this.b60);
            this.groupBox3.Controls.Add(this.b10);
            this.groupBox3.Controls.Add(this.b12);
            this.groupBox3.Controls.Add(this.b15);
            this.groupBox3.Controls.Add(this.b17);
            this.groupBox3.Controls.Add(this.b20);
            this.groupBox3.Controls.Add(this.b30);
            this.groupBox3.Controls.Add(this.b40);
            this.groupBox3.Controls.Add(this.b80);
            this.groupBox3.Controls.Add(this.b160);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(12, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 44);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Band";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblSwr);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.chkPeak);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.lblbad);
            this.groupBox5.Controls.Add(this.lblRef);
            this.groupBox5.Controls.Add(this.lblFwd);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.swrMeter);
            this.groupBox5.Controls.Add(this.refMeter);
            this.groupBox5.Controls.Add(this.fwdMeter);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox5.Size = new System.Drawing.Size(570, 110);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Metering";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // lblSwr
            // 
            this.lblSwr.AutoSize = true;
            this.lblSwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSwr.Location = new System.Drawing.Point(512, 66);
            this.lblSwr.Name = "lblSwr";
            this.lblSwr.Size = new System.Drawing.Size(22, 13);
            this.lblSwr.TabIndex = 25;
            this.lblSwr.Text = "1:1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(591, 362);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "LDG Tuner Control";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ProgressBar fwdMeter;
        private System.Windows.Forms.ProgressBar refMeter;
        private System.Windows.Forms.ProgressBar swrMeter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFwd;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Label lblbad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RadioButton ampOperateBtn;
        private System.Windows.Forms.RadioButton ampStbyBtn;
        private System.Windows.Forms.Button ampResetBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAmpInit;
        private System.Windows.Forms.ComboBox ampPortsBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTunerInit;
        private System.Windows.Forms.ComboBox cmbTunerPorts;
        private System.Windows.Forms.Button btnAntTog;
        private System.Windows.Forms.Button btnBypass;
        private System.Windows.Forms.Label lblTuneStatus;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnFullTune;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMemTune;
        private System.Windows.Forms.CheckBox chkPeak;
        private System.Windows.Forms.Timer tmrFwdPeak;
        private System.Windows.Forms.Timer tmrRefPeak;
        private System.Windows.Forms.Timer tmrSwrPeak;
        private System.Windows.Forms.Label nameBand;
        private System.Windows.Forms.Button b160;
        private System.Windows.Forms.Button b80;
        private System.Windows.Forms.Button b40;
        private System.Windows.Forms.Button b30;
        private System.Windows.Forms.Button b20;
        private System.Windows.Forms.Button b17;
        private System.Windows.Forms.Button b15;
        private System.Windows.Forms.Button b12;
        private System.Windows.Forms.Button b10;
        private System.Windows.Forms.Button b60;
        private System.Windows.Forms.Button b6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label WTF;
        private System.Windows.Forms.Label lblBand;
        private System.Windows.Forms.Label lblSwr;
        private System.Windows.Forms.Label lblWtf;
        private System.Windows.Forms.ToolStripMenuItem voltageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v130;
        private System.Windows.Forms.ToolStripMenuItem v125;
        private System.Windows.Forms.ToolStripMenuItem v120;
        private System.Windows.Forms.ToolStripMenuItem v138;
        private System.Windows.Forms.ToolStripMenuItem v135;
        private System.Windows.Forms.ToolStripMenuItem flexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtFlexHost;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtFlexPort;
    }
}

