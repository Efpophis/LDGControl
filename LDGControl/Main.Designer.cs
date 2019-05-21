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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ampOperateBtn = new System.Windows.Forms.RadioButton();
            this.ampStbyBtn = new System.Windows.Forms.RadioButton();
            this.ampResetBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAmpInit = new System.Windows.Forms.Button();
            this.ampPortsBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTuneStatus = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnFullTune = new System.Windows.Forms.Button();
            this.btnMemTune = new System.Windows.Forms.Button();
            this.btnBypass = new System.Windows.Forms.Button();
            this.btnAntTog = new System.Windows.Forms.Button();
            this.btnTunerInit = new System.Windows.Forms.Button();
            this.cmbTunerPorts = new System.Windows.Forms.ComboBox();
            this.lblSwr = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblWtf = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkPeak = new System.Windows.Forms.CheckBox();
            this.tmrFwdPeak = new System.Windows.Forms.Timer(this.components);
            this.tmrRefPeak = new System.Windows.Forms.Timer(this.components);
            this.tmrSwrPeak = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(474, 347);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // fwdMeter
            // 
            this.fwdMeter.BackColor = System.Drawing.SystemColors.Control;
            this.fwdMeter.Location = new System.Drawing.Point(99, 58);
            this.fwdMeter.Maximum = 8;
            this.fwdMeter.Name = "fwdMeter";
            this.fwdMeter.Size = new System.Drawing.Size(426, 13);
            this.fwdMeter.Step = 1;
            this.fwdMeter.TabIndex = 1;
            // 
            // refMeter
            // 
            this.refMeter.Location = new System.Drawing.Point(99, 77);
            this.refMeter.Maximum = 8;
            this.refMeter.Name = "refMeter";
            this.refMeter.Size = new System.Drawing.Size(426, 13);
            this.refMeter.Step = 1;
            this.refMeter.TabIndex = 2;
            // 
            // swrMeter
            // 
            this.swrMeter.Location = new System.Drawing.Point(99, 96);
            this.swrMeter.Maximum = 8;
            this.swrMeter.Name = "swrMeter";
            this.swrMeter.Size = new System.Drawing.Size(426, 13);
            this.swrMeter.Step = 1;
            this.swrMeter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Forward Pwr:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reflected Pwr:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "VSWR:";
            // 
            // lblFwd
            // 
            this.lblFwd.AutoSize = true;
            this.lblFwd.Location = new System.Drawing.Point(534, 58);
            this.lblFwd.Name = "lblFwd";
            this.lblFwd.Size = new System.Drawing.Size(18, 13);
            this.lblFwd.TabIndex = 7;
            this.lblFwd.Text = "W";
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Location = new System.Drawing.Point(534, 77);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(18, 13);
            this.lblRef.TabIndex = 8;
            this.lblRef.Text = "W";
            // 
            // lblbad
            // 
            this.lblbad.AutoSize = true;
            this.lblbad.Location = new System.Drawing.Point(510, 112);
            this.lblbad.Name = "lblbad";
            this.lblbad.Size = new System.Drawing.Size(29, 13);
            this.lblbad.TabIndex = 9;
            this.lblbad.Text = "BAD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "25";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "250";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(405, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "500";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(459, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "750";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(139, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "1.1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(193, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "1.3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(245, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "1.5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(298, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "1.7";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(351, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "2.0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(405, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "2.5";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(459, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "3.0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(508, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "1000";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.mnuAbout_onClick);
            // 
            // ampOperateBtn
            // 
            this.ampOperateBtn.AutoSize = true;
            this.ampOperateBtn.Checked = true;
            this.ampOperateBtn.Enabled = false;
            this.ampOperateBtn.Location = new System.Drawing.Point(6, 24);
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
            this.ampStbyBtn.Location = new System.Drawing.Point(6, 47);
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
            this.ampResetBtn.Location = new System.Drawing.Point(6, 70);
            this.ampResetBtn.Name = "ampResetBtn";
            this.ampResetBtn.Size = new System.Drawing.Size(75, 23);
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
            this.groupBox1.Location = new System.Drawing.Point(19, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 100);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amplifier";
            // 
            // btnAmpInit
            // 
            this.btnAmpInit.Location = new System.Drawing.Point(144, 70);
            this.btnAmpInit.Name = "btnAmpInit";
            this.btnAmpInit.Size = new System.Drawing.Size(75, 23);
            this.btnAmpInit.TabIndex = 31;
            this.btnAmpInit.Text = "Initialize";
            this.btnAmpInit.UseVisualStyleBackColor = true;
            this.btnAmpInit.Click += new System.EventHandler(this.btnAmpInit_Click);
            // 
            // ampPortsBox
            // 
            this.ampPortsBox.FormattingEnabled = true;
            this.ampPortsBox.Location = new System.Drawing.Point(144, 24);
            this.ampPortsBox.Name = "ampPortsBox";
            this.ampPortsBox.Size = new System.Drawing.Size(121, 21);
            this.ampPortsBox.TabIndex = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTuneStatus);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.btnFullTune);
            this.groupBox2.Controls.Add(this.btnMemTune);
            this.groupBox2.Controls.Add(this.btnBypass);
            this.groupBox2.Controls.Add(this.btnAntTog);
            this.groupBox2.Controls.Add(this.btnTunerInit);
            this.groupBox2.Controls.Add(this.cmbTunerPorts);
            this.groupBox2.Location = new System.Drawing.Point(19, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 100);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tuner";
            // 
            // lblTuneStatus
            // 
            this.lblTuneStatus.AutoSize = true;
            this.lblTuneStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblTuneStatus.Location = new System.Drawing.Point(460, 30);
            this.lblTuneStatus.Name = "lblTuneStatus";
            this.lblTuneStatus.Size = new System.Drawing.Size(33, 13);
            this.lblTuneStatus.TabIndex = 7;
            this.lblTuneStatus.Text = "None";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(363, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Last Tune Result:";
            // 
            // btnFullTune
            // 
            this.btnFullTune.Enabled = false;
            this.btnFullTune.Location = new System.Drawing.Point(282, 71);
            this.btnFullTune.Name = "btnFullTune";
            this.btnFullTune.Size = new System.Drawing.Size(75, 23);
            this.btnFullTune.TabIndex = 5;
            this.btnFullTune.Text = "Full";
            this.toolTip1.SetToolTip(this.btnFullTune, "Forces a full tune");
            this.btnFullTune.UseVisualStyleBackColor = true;
            this.btnFullTune.Click += new System.EventHandler(this.btnFullTune_Click);
            // 
            // btnMemTune
            // 
            this.btnMemTune.Enabled = false;
            this.btnMemTune.Location = new System.Drawing.Point(282, 20);
            this.btnMemTune.Name = "btnMemTune";
            this.btnMemTune.Size = new System.Drawing.Size(75, 23);
            this.btnMemTune.TabIndex = 4;
            this.btnMemTune.Text = "Memory";
            this.toolTip1.SetToolTip(this.btnMemTune, "Forces a Memory Tune");
            this.btnMemTune.UseVisualStyleBackColor = true;
            this.btnMemTune.Click += new System.EventHandler(this.btnMemTune_Click);
            // 
            // btnBypass
            // 
            this.btnBypass.BackColor = System.Drawing.Color.Green;
            this.btnBypass.Enabled = false;
            this.btnBypass.Location = new System.Drawing.Point(161, 71);
            this.btnBypass.Name = "btnBypass";
            this.btnBypass.Size = new System.Drawing.Size(75, 23);
            this.btnBypass.TabIndex = 3;
            this.btnBypass.Text = "Bypass";
            this.toolTip1.SetToolTip(this.btnBypass, "Toggles between Bypass or Auto Tune");
            this.btnBypass.UseVisualStyleBackColor = false;
            this.btnBypass.Click += new System.EventHandler(this.btnBypass_Click);
            // 
            // btnAntTog
            // 
            this.btnAntTog.Enabled = false;
            this.btnAntTog.Location = new System.Drawing.Point(161, 19);
            this.btnAntTog.Name = "btnAntTog";
            this.btnAntTog.Size = new System.Drawing.Size(75, 23);
            this.btnAntTog.TabIndex = 2;
            this.btnAntTog.Text = "Antenna 1";
            this.toolTip1.SetToolTip(this.btnAntTog, "Toggle selected antenna");
            this.btnAntTog.UseVisualStyleBackColor = true;
            this.btnAntTog.Click += new System.EventHandler(this.btnAntTog_Click);
            // 
            // btnTunerInit
            // 
            this.btnTunerInit.Location = new System.Drawing.Point(7, 71);
            this.btnTunerInit.Name = "btnTunerInit";
            this.btnTunerInit.Size = new System.Drawing.Size(75, 23);
            this.btnTunerInit.TabIndex = 1;
            this.btnTunerInit.Text = "Initialize";
            this.btnTunerInit.UseVisualStyleBackColor = true;
            this.btnTunerInit.Click += new System.EventHandler(this.btnTunerInit_Click);
            // 
            // cmbTunerPorts
            // 
            this.cmbTunerPorts.FormattingEnabled = true;
            this.cmbTunerPorts.Location = new System.Drawing.Point(7, 20);
            this.cmbTunerPorts.Name = "cmbTunerPorts";
            this.cmbTunerPorts.Size = new System.Drawing.Size(121, 21);
            this.cmbTunerPorts.TabIndex = 0;
            // 
            // lblSwr
            // 
            this.lblSwr.AutoSize = true;
            this.lblSwr.Location = new System.Drawing.Point(534, 96);
            this.lblSwr.Name = "lblSwr";
            this.lblSwr.Size = new System.Drawing.Size(22, 13);
            this.lblSwr.TabIndex = 33;
            this.lblSwr.Text = " : 1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "WTF:";
            // 
            // lblWtf
            // 
            this.lblWtf.AutoSize = true;
            this.lblWtf.Location = new System.Drawing.Point(56, 131);
            this.lblWtf.Name = "lblWtf";
            this.lblWtf.Size = new System.Drawing.Size(25, 13);
            this.lblWtf.TabIndex = 35;
            this.lblWtf.Text = "???";
            // 
            // chkPeak
            // 
            this.chkPeak.AutoSize = true;
            this.chkPeak.Checked = true;
            this.chkPeak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPeak.Location = new System.Drawing.Point(469, 141);
            this.chkPeak.Name = "chkPeak";
            this.chkPeak.Size = new System.Drawing.Size(51, 17);
            this.chkPeak.TabIndex = 36;
            this.chkPeak.Text = "Peak";
            this.chkPeak.UseVisualStyleBackColor = true;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 404);
            this.Controls.Add(this.chkPeak);
            this.Controls.Add(this.lblWtf);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblSwr);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblbad);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.lblFwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.swrMeter);
            this.Controls.Add(this.refMeter);
            this.Controls.Add(this.fwdMeter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "LDG Tuner Control";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label lblSwr;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblWtf;
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
    }
}

