using LDGControl.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDGControl
{
    public partial class Main : Form
    {
        private int m_fwdTicks, m_swrTicks, m_refTicks;
        public Main()
        {
            InitializeComponent();
            m_fwdTicks = m_swrTicks = m_refTicks = 0;

            string[] ampPorts = System.IO.Ports.SerialPort.GetPortNames();
            string[] tunerPorts = System.IO.Ports.SerialPort.GetPortNames();

            ampPortsBox.DataSource = ampPorts;
            cmbTunerPorts.DataSource = tunerPorts;

            int index = -1;
            try
            {

                string saved_amp_port = Properties.Settings.Default["amp_port"].ToString();
                index = Array.IndexOf(ampPorts, saved_amp_port);

                if (index != -1)
                {
                    ampPortsBox.SelectedIndex = index;
                }
            }
            catch (Exception)
            {
                // don't care
            }

            try
            {
                string saved_tuner_port = Properties.Settings.Default["tuner_port"].ToString();
                index = Array.IndexOf(tunerPorts, saved_tuner_port);

                if (index != -1)
                {
                    cmbTunerPorts.SelectedIndex = index;
                }
            }
            catch (Exception)
            { 
                // don't care 
            }

            try
            {
                chkPeak.Checked = Properties.Settings.Default.peak_hold;
                //tsFlexEnabled.Checked = Properties.Settings.Default.flex_enabled;
                txtAmpHost.Text = Properties.Settings.Default["amp_host"].ToString();
                numAmpPort.Value = Properties.Settings.Default.amp_tcp_port;
                txtTunerHost.Text = Properties.Settings.Default.tuner_host;
                numTunerPort.Value = Properties.Settings.Default.tuner_tcp_port;
                
                string whichTab = Properties.Settings.Default.tuner_tab;

                if ( whichTab == "remote" )
                {
                    tabTuner.SelectedTab = tabTunerRemote;
                }
                else
                {
                    tabTuner.SelectedTab = tabTunerLocal;
                }

                whichTab = Properties.Settings.Default.amp_tab;

                if (whichTab == "remote")
                {
                    tabAmp.SelectedTab = tabAmpRemote;
                }
                else
                {
                    tabAmp.SelectedTab = tabAmpLocal;
                }
                int psudVolts = Properties.Settings.Default.psu_dvolts;

                switch ( psudVolts )
                {
                    case 120:
                        toolStripMenuItem6_Click(null, null);
                        break;
                    case 125:
                        toolStripMenuItem5_Click(null, null);
                        break;
                    case 130:
                        toolStripMenuItem4_Click(null, null);
                        break;
                    case 135:
                        toolStripMenuItem3_Click(null, null);
                        break;
                    case 138:
                    default:
                        toolStripMenuItem2_Click(null, null);
                        break;
                    case 143:
                        toolStripMenuItem1_Click(null, null);
                        break;
                }
            }
            catch (Exception)
            {
                // dont care
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();            
            Close();
        }

        private void mnuAbout_onClick(object sender, EventArgs e)
        {
            using (AboutBox box = new AboutBox())
            {
                box.ShowDialog(this);
            }
        }       

        private AmpCtl m_amp;
        private Tuner m_tuner;
        private double voltPS =13.8;

        //public Color Green { get; private set; }

        private void on_ampOpCheckedChanged(object sender, EventArgs e)
        {
            if ( ampOperateBtn.Checked == true )
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(delegate {
                    m_amp.ampOn();
                });
                worker.RunWorkerAsync();
            }
        }

        private void on_AmpStbyCheckChanged(object sender, EventArgs e)
        {
            if ( ampStbyBtn.Checked == true )
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(delegate {
                    m_amp.ampOff();
                });
                worker.RunWorkerAsync();
            }
        }

        private void on_AmpResetClick(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            ampStbyBtn.Checked = true;

            worker.DoWork += new DoWorkEventHandler(delegate
            {
                System.Threading.Thread.Sleep(1000);
                ampOperateBtn.Invoke((MethodInvoker)delegate
                {
                   ampOperateBtn.Checked = true;
                });
            });

            worker.RunWorkerAsync();
            
        }

        private void Initialize_Amp()
        {
            if (ampPortsBox.Visible == false)
            {
                string host = txtAmpHost.Text;
                int port = (int)numAmpPort.Value;

                m_amp = new AmpCtl(host, port);
                Properties.Settings.Default["amp_host"] = host;
                Properties.Settings.Default["amp_tcp_port"] = port;
                Properties.Settings.Default.amp_tab = "remote";
                Properties.Settings.Default.amp_autoconn = chkAmpAuto.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                string ampPort = ampPortsBox.SelectedItem.ToString();

                m_amp = new AmpCtl(ampPort);

                Properties.Settings.Default["amp_port"] = ampPort;
                Properties.Settings.Default.amp_tab = "local";
                Properties.Settings.Default.amp_autoconn = chkAmpAuto.Checked;
                Properties.Settings.Default.Save();
            }

            ampOperateBtn.Enabled = true;
            ampStbyBtn.Enabled = true;
            ampResetBtn.Enabled = true;
            btnAmpInit.Enabled = false;
            btnAmpInit.BackColor = Color.LimeGreen;
            btnAmpInit.Text = "Connected";
        }

        private void btnAmpInit_Click(object sender, EventArgs e)
        {
            Initialize_Amp();   
        }

        protected void updateMeter(UInt16 fwd, UInt16 refl, UInt16 wtf)
        {
            double vswr = 0.0f;
            double sqr;

            double p_refl = Math.Round(meterScale(refl), 1);
            double p_fwd = Math.Round(meterScale(fwd), 1);

            if (p_refl > 0.0f)
            {
                sqr = Math.Sqrt(p_fwd / p_refl);

                vswr = Math.Round(Math.Abs((1.0f + sqr) / (1.0f - sqr)), 1);
            }
            else
                vswr = 1.0f;

            lblFwd.Invoke((MethodInvoker)delegate
               {
                   // do all UI updates in here...
                   if (chkPeak.Checked == false)
                   {
                       lblFwd.Text = p_fwd.ToString();
                       fwdMeter.Value = pwrMeterLEDS(p_fwd);

                       lblRef.Text = p_refl.ToString();
                       refMeter.Value = pwrMeterLEDS(p_refl);

                       lblSwr.Text = vswr.ToString() + " : 1";
                       swrMeter.Value = swrMeterLEDS(vswr);
                   }
                   else
                   {
                       int pwrLEDs = pwrMeterLEDS(p_fwd);
                       int refLEDs = pwrMeterLEDS(p_refl);
                       int swrLEDs = swrMeterLEDS(vswr);

                       if (fwdMeter.Value < pwrLEDs || m_fwdTicks >= 4 || pwrLEDs == 0)
                       {
                           tmrFwdPeak.Stop();
                           tmrFwdPeak.Enabled = false;
                           
                           lblFwd.Text = p_fwd.ToString() + "W";
                           fwdMeter.Value = pwrLEDs;

                           m_fwdTicks = 0;
                           tmrFwdPeak.Enabled = true;
                           tmrFwdPeak.Start();
                       }
                       


                       if (refMeter.Value < refLEDs || m_refTicks >= 4 || (pwrLEDs == 0 && refLEDs == 0))
                       {
                           tmrRefPeak.Enabled = false;
                           tmrRefPeak.Stop();

                           lblRef.Text = p_refl.ToString() + "W";
                           refMeter.Value = refLEDs;

                           m_refTicks = 0;
                           tmrRefPeak.Enabled = true;
                           tmrRefPeak.Start();
                       }
                       

                       if ( swrMeter.Value < swrLEDs || m_swrTicks >= 4 || (pwrLEDs == 0 && swrLEDs == 0))
                       {
                           tmrSwrPeak.Enabled = false;
                           tmrSwrPeak.Stop();

                           lblSwr.Text = vswr.ToString() + " : 1";
                           swrMeter.Value = swrLEDs;

                           m_swrTicks = 0;
                           tmrSwrPeak.Enabled = true;
                           tmrSwrPeak.Start();
                       }                      
                   }

                   if (vswr <= 1.7) swrMeter.ForeColor = Color.LimeGreen;

                   if (vswr > 1.7 && vswr <= 2.0) swrMeter.ForeColor = Color.Orange;

                   if (vswr > 2.0) swrMeter.ForeColor = Color.Red;

                   WTF.Text = wtf.ToString();

                   if ((wtf >= 8230) && (wtf <= 9145))
                   {
                       lblBand.Text = "160m";
                       b160.BackColor = Color.Lime;
                       b80.BackColor=Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 4110) && (wtf <= 4710))
                   {
                       lblBand.Text = "80m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Lime;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   //placeholder for 60mnby
                   else if ((wtf >= 3060) && (wtf <= 3080))
                   {
                       lblBand.Text = "60m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Lime;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 2250) && (wtf <= 2355))
                   {
                       lblBand.Text = "40m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Lime;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 1600) && (wtf <= 1630))
                   {
                       lblBand.Text = "30m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Lime;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 1140) && (wtf <= 1180))
                   {
                       lblBand.Text = "20m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Lime;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 900) && (wtf <= 915))
                   {
                       lblBand.Text = "17m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Lime;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 766) && (wtf <= 782))
                   {
                       lblBand.Text = "15m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Lime;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 655) && (wtf <= 662))
                   {
                       lblBand.Text = "12m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Lime;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Transparent;
                   }
                   else if ((wtf >= 550) && (wtf <= 590))
                   {
                       lblBand.Text = "10m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Lime;
                       b6.BackColor = Color.Transparent;
                   }
                   //placeholder for 6m
                   else if ((wtf >= 320) && (wtf <= 360))
                   {
                       lblBand.Text = "6m";
                       b160.BackColor = Color.Transparent;
                       b80.BackColor = Color.Transparent;
                       b60.BackColor = Color.Transparent;
                       b40.BackColor = Color.Transparent;
                       b30.BackColor = Color.Transparent;
                       b20.BackColor = Color.Transparent;
                       b17.BackColor = Color.Transparent;
                       b15.BackColor = Color.Transparent;
                       b12.BackColor = Color.Transparent;
                       b10.BackColor = Color.Transparent;
                       b6.BackColor = Color.Lime;
                   }
                   else
                       lblBand.Text = "Unknown"; 

               }
            );

        }

        private int Map(double val, double frLow,double frHigh, double toLow, double toHigh)
        {
            return (int)((val - frLow) * (toHigh - toLow) / (frHigh - frLow) + toLow);
        }

        private int swrMeterLEDS(double swr)
        {
            //if (swr > 1.01f) ++result;
#if EFPOPHIS_ORIG_SCALE
            if (swr >= 1.1f) ++result;

            if (swr > 1.3f) ++result;

            if (swr > 1.5f) ++result;

            if (swr > 1.7f) ++result;

            if (swr > 2.0f) ++result;

            if (swr > 2.5f) ++result;

            if (swr > 3.0f) ++result;

            if (swr > 4.0f) ++result;
#endif
            if (swr <= 1.1f) return Map(swr, 1.0, 1.1, 0, 100);

            if (swr <= 1.3f) return Map(swr, 1.1, 1.3, 100, 250);

            if (swr <= 1.5f) return Map(swr, 1.3, 1.5, 250, 375);

            if (swr <= 1.7f) return Map(swr, 1.5, 1.7, 375, 500);

            if (swr <= 2.0f) return Map(swr, 1.7, 2.0, 500, 625);

            if (swr <= 2.5f) return Map(swr, 2.0, 2.5, 625, 750);

            if (swr <= 3.0f) return Map(swr, 2.5, 3.0, 750, 900);

            if (swr <= 4.0f) return Map(swr, 3.0, 4.0, 900, 1000);

            return 1000;
        }

        private int pwrMeterLEDS( double pwr )
        {
            int result = 0;
#if EFPOPHIS_ORIG_SCALE
            //if (pwr > 0.0f) ++result;

            if (pwr > 5.0f) ++result; // 10w

            if (pwr > 17.5f) ++result; // 25w

            if (pwr > 37.5f) ++result; // 50w 

            if (pwr > 75.0f) ++result; // 100w

            if (pwr > 175.0f) ++result; // 250w

            if (pwr > 375.0f) ++result; // 500 w

            if (pwr > 625.0f) ++result; // 750

            if (pwr > 875.0f) ++result; // 1000
#endif
#if EFPOPIS_LINEAR_SCALING
            if ( pwr <= 100 )
            {
                result = pwrMap((int)pwr,0,100,0,500);
            }
            else
            {
                result = pwrMap((int)pwr,101,1000,500,1000);
            }

#endif
            double scale = fwdMeter.Maximum;

            if (pwr > 0)
            {
                result = (int)((Math.Sqrt(1 + pwr) / Math.Sqrt(1 + scale)) * scale);
            }
            
            return result;
        }

        private double meterScale( UInt16 raw )
        {
            double result;
            double tosquare;
           
            // LOTS of people contributed to this formula, and it
            // seems to be pretty accurate. PLEASE don't mess with it.

            tosquare = (1000.0f * voltPS * raw) / (65536.0f * 0.707);

            result = (tosquare * tosquare) / 50.0f;

            return result;

        }

        private void Initialize_Tuner()
        {
            if (cmbTunerPorts.Visible == false)
            {
                string tunerHost = txtTunerHost.Text;
                int tunerTcpPort = (int)numTunerPort.Value;
                Properties.Settings.Default.tuner_host = tunerHost;
                Properties.Settings.Default.tuner_tcp_port = tunerTcpPort;
                Properties.Settings.Default.tuner_tab = "remote";
                m_tuner = new Tuner(tunerHost, tunerTcpPort, updateMeter);
            }
            else
            {
                string tunerPort = cmbTunerPorts.SelectedItem.ToString();
                Properties.Settings.Default["tuner_port"] = tunerPort;
                //Properties.Settings.Default.flex_host = txtFlexHost.Text;
                //Properties.Settings.Default.flex_port = Int32.Parse(txtFlexPort.Text);
                //Properties.Settings.Default.flex_enabled = tsFlexEnabled.Checked;
                Properties.Settings.Default.tuner_tab = "local";
                m_tuner = new Tuner(tunerPort, updateMeter);
            }
            Properties.Settings.Default.tuner_autoconn = chkTunerAutoInit.Checked;
            Properties.Settings.Default.Save();

            btnTunerInit.Text = "Connecting";
            btnTunerInit.BackColor = Color.Yellow;
            btnTunerInit.Enabled = false;

            m_tuner.Init();

            btnTunerInit.Enabled = false;
            btnTunerInit.Text = "Connected";
            btnTunerInit.BackColor = Color.LimeGreen;
            btnAntTog.Enabled = true;
            btnBypass.Enabled = true;
            btnMemTune.Enabled = true;
            btnFullTune.Enabled = true;
        }

        private void btnTunerInit_Click(object sender, EventArgs e)
        {
            Initialize_Tuner();
        }

        void FwdTick( Object o, EventArgs arg )
        {
            ++m_fwdTicks;
        }

        void ReflTick( Object o, EventArgs arg )
        {
            ++m_refTicks;
        }

        void swrTick( Object o, EventArgs arg)
        {
            ++m_swrTicks;
        }

        private void btnAntTog_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(delegate {
                byte[] result = m_tuner.Toggle();

                if (result != null && result[0] != 'E')
                    btnAntTog.Invoke((MethodInvoker)delegate { 
                        btnAntTog.Text = "Antenna " + ((char)result[0]).ToString();
                    });
                else
                    btnAntTog.Invoke((MethodInvoker)delegate {
                        btnAntTog.Text = "Antenna ERROR";
                    });
            });

            worker.RunWorkerAsync();
        }

        private void btnBypass_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            if (btnBypass.BackColor == Color.LimeGreen)
            {
                worker.DoWork += new DoWorkEventHandler(delegate 
                {
                    byte[] result = m_tuner.Bypass();

                    if (result != null && result[0] == 'P')
                    {
                        btnBypass.Invoke((MethodInvoker)delegate { 
                            btnBypass.Text = "Tune";
                            btnBypass.BackColor = Color.Red;
                        });
                    }
                });                
            }
            else
            {
                worker.DoWork += new DoWorkEventHandler(delegate
                {
                    byte[] result = m_tuner.AutoTuneMode();

                    if (result != null && result[0] == 'A')
                    {
                        btnBypass.Invoke((MethodInvoker)delegate 
                        { 
                            btnBypass.Text = "Bypass";
                            btnBypass.BackColor = Color.LimeGreen;
                        });
                    }
                });
            }
            worker.RunWorkerAsync();          
        }

        private void btnMemTune_Click(object sender, EventArgs e)
        {
            
            lblTuneStatus.Text = "Tuning...";
            lblTuneStatus.BackColor = SystemColors.Control;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(delegate {
                byte[] result = m_tuner.MemoryTune();

                lblTuneStatus.Invoke((MethodInvoker)delegate { TuneResult(result); });                
            });

            worker.RunWorkerAsync();            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.RestoreWindowPosition();
            this.Refresh();
            //chkAmpAuto.Checked = Properties.Settings.Default.amp_autoconn;
            //chkTunerAutoInit.Checked = Properties.Settings.Default.tuner_autoconn;
            
        }
        

        private void RestoreWindowPosition()
        {
            if (Settings.Default.HasSetDefaults)
            {
                this.WindowState = Settings.Default.WindowState;
                this.Location = Settings.Default.Location;
                this.Size = Settings.Default.Size;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            voltPS =13.8;
            v138.Checked=true;
            v135.Checked = false;          
            v125.Checked = false;
            v120.Checked = false;
            v130.Checked = false;
            v143.Checked = false;
            Properties.Settings.Default.psu_dvolts = 138;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            voltPS =13.0;
            v135.Checked = false;
            v138.Checked = false;
            v125.Checked = false;
            v120.Checked = false;
            v130.Checked = true;
            v143.Checked = false;
            Properties.Settings.Default.psu_dvolts = 130;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            voltPS = 13.5;
            v135.Checked= true;
            v138.Checked = false;
            v125.Checked = false;
            v120.Checked = false;
            v130.Checked = false;
            v143.Checked = false;
            Properties.Settings.Default.psu_dvolts = 135;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            voltPS = 12.5;
            v135.Checked = false;
            v138.Checked = false;
            v125.Checked = true;
            v120.Checked = false;
            v130.Checked = false;
            v143.Checked = false;
            Properties.Settings.Default.psu_dvolts = 125;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            voltPS = 12.0;
            v135.Checked = false;
            v138.Checked = false;
            v125.Checked = false;
            v120.Checked = true;
            v130.Checked = false;
            v143.Checked = false;
            Properties.Settings.Default.psu_dvolts = 120;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            voltPS = 14.3;
            v135.Checked = false;
            v138.Checked = false;
            v125.Checked = false;
            v120.Checked = false;
            v130.Checked = false;
            v143.Checked = true;
            Properties.Settings.Default.psu_dvolts = 143;
            Properties.Settings.Default.Save();
        }
       
        private void chkPeak_CheckedChanged(object sender, EventArgs e)
        {            
            Properties.Settings.Default.peak_hold = chkPeak.Checked;
            Properties.Settings.Default.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveWindowPosition();
        }

        private void SaveWindowPosition()
        {
            Settings.Default.WindowState = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.Location = this.Location;
                Settings.Default.Size = this.Size;
            }
            else
            {
                Settings.Default.Location = this.RestoreBounds.Location;
                Settings.Default.Size = this.RestoreBounds.Size;
            }

            Settings.Default.HasSetDefaults = true;

            Settings.Default.Save();
        }

      
        private void flexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FlexConfig box = new FlexConfig())
            {
                box.ShowDialog(this);
            }
        }

        private void chkAmpAuto_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.amp_autoconn = chkAmpAuto.Checked;
            this.Refresh();
            if (chkAmpAuto.Checked)
            {            
                Initialize_Amp();
            }
        }

        private void chkTunerAutoInit_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.tuner_autoconn = chkTunerAutoInit.Checked;
            this.Refresh();       
            if (chkTunerAutoInit.Checked)
            {             
                Initialize_Tuner();
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            chkAmpAuto.Checked = Settings.Default.amp_autoconn;
            chkTunerAutoInit.Checked = Settings.Default.tuner_autoconn;                       
        }

        private void TuneResult( byte[] result )
        {
            if (result != null)
            {
                char status = (char)result[0];
                if (status == 'T')
                {
                    lblTuneStatus.Text = " GOOD ";
                    lblTuneStatus.BackColor = Color.Lime;
                }
                else if (status == 'M')
                {
                    lblTuneStatus.Text = " OKAY ";
                    lblTuneStatus.BackColor = Color.Yellow;
                }
                else if (status == 'F')
                {
                    lblTuneStatus.Text = " FAIL ";
                    lblTuneStatus.BackColor = Color.Red;
                }
                else if (status == 'E')
                {
                    lblTuneStatus.Text = " ERROR ";
                    lblTuneStatus.BackColor = Color.MediumVioletRed;
                }    
            }
        }

        private void btnFullTune_Click(object sender, EventArgs e)
        {
            lblTuneStatus.Text = "Tuning...";
            lblTuneStatus.BackColor = SystemColors.Control;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(delegate {
                byte[] result = m_tuner.ForceFullTune();

                lblTuneStatus.Invoke((MethodInvoker)delegate { TuneResult(result); });
            });

            worker.RunWorkerAsync();
        }
    }
}
