using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
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

        public Color Green { get; private set; }

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

        private void btnAmpInit_Click(object sender, EventArgs e)
        {
            string ampPort = ampPortsBox.SelectedItem.ToString();

            m_amp = new AmpCtl(ampPort);

            Properties.Settings.Default["amp_port"] = ampPort;
            Properties.Settings.Default.Save();

            ampOperateBtn.Enabled = true;
            ampStbyBtn.Enabled = true;
            ampResetBtn.Enabled = true;
            btnAmpInit.Enabled = false;
            btnAmpInit.Text = "Connected";
        }

        protected void updateMeter(UInt16 fwd, UInt16 refl, UInt16 wtf)
        {
            double vswr = 0.0f;
            double sqr;

            double p_refl = Math.Round(meterScale(refl), 1);
            double p_fwd = Math.Round(meterScale(fwd), 1);

            if (refl > 0.0f)
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

                       if (fwdMeter.Value < pwrLEDs || m_fwdTicks >= 4 )
                       {
                           tmrFwdPeak.Stop();
                           tmrFwdPeak.Enabled = false;
                           
                           lblFwd.Text = p_fwd.ToString() + "W";
                           fwdMeter.Value = pwrLEDs;

                           m_fwdTicks = 0;
                           tmrFwdPeak.Enabled = true;
                           tmrFwdPeak.Start();
                       }
                       


                       if (refMeter.Value < refLEDs || m_refTicks >= 4)
                       {
                           tmrRefPeak.Enabled = false;
                           tmrRefPeak.Stop();

                           lblRef.Text = p_refl.ToString() + "W";
                           refMeter.Value = refLEDs;

                           m_refTicks = 0;
                           tmrRefPeak.Enabled = true;
                           tmrRefPeak.Start();
                       }
                       

                       if ( swrMeter.Value < swrLEDs || m_swrTicks >= 4 )
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

        private int swrMeterLEDS(double swr)
        {
            int result = 0;

            //if (swr > 1.01f) ++result;

            if (swr >= 1.1f) ++result;

            if (swr > 1.3f) ++result;

            if (swr > 1.5f) ++result;

            if (swr > 1.7f) ++result;

            if (swr > 2.0f) ++result;

            if (swr > 2.5f) ++result;

            if (swr > 3.0f) ++result;

            if (swr > 4.0f) ++result;

            return result;
        }

        private int pwrMeterLEDS( double pwr )
        {
            int result = 0;

            //if (pwr > 0.0f) ++result;

            if (pwr > 5.0f) ++result; // 10w

            if (pwr > 17.5f) ++result; // 25w

            if (pwr > 37.5f) ++result; // 50w 

            if (pwr > 75.0f) ++result; // 100w

            if (pwr > 175.0f) ++result; // 250w

            if (pwr > 375.0f) ++result; // 500 w

            if (pwr > 625.0f) ++result; // 750

            if (pwr > 875.0f) ++result; // 1000

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

        private void btnTunerInit_Click(object sender, EventArgs e)
        {
            string tunerPort = cmbTunerPorts.SelectedItem.ToString();

            m_tuner = new Tuner(tunerPort, updateMeter);
            m_tuner.Init();

            Properties.Settings.Default["tuner_port"] = tunerPort;
            Properties.Settings.Default.Save();

            btnTunerInit.Enabled = false;
            btnTunerInit.Text = "Connected";
            btnTunerInit.BackColor = Color.LimeGreen; 
            btnAntTog.Enabled = true;
            btnBypass.Enabled = true;
            btnMemTune.Enabled = true;
            btnFullTune.Enabled = true;
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

                if (result != null)
                    btnAntTog.Invoke((MethodInvoker)delegate { 
                        btnAntTog.Text = "Antenna " + ((char)result[0]).ToString();
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

                    if (result != null)
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

                    if (result != null)
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

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }
   

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            voltPS =13.8;
            v138.Checked=true;
            v135.Checked = false;          
            v125.Checked = false;
            v120.Checked = false;
            v130.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            voltPS =13.0;
            v135.Checked = false;
            v138.Checked = false;
            v125.Checked = false;
            v120.Checked = false;
            v130.Checked = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            voltPS = 13.5;
            v135.Checked= true;
            v138.Checked = false;
            v125.Checked = false;
            v120.Checked = false;
            v130.Checked = false;


        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            voltPS = 12.5;
            v135.Checked = false;
            v138.Checked = false;
            v125.Checked = true;
            v120.Checked = false;
            v130.Checked = false;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            voltPS = 12.0;
            v135.Checked = false;
            v138.Checked = false;
            v125.Checked = false;
            v120.Checked = true;
            v130.Checked = false;

        }

        private void onFlexHostChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.flex_host = txtFlexHost.Text;
            Properties.Settings.Default.Save();
            m_tuner.FlexHost = txtFlexHost.Text;
        }

        private void onFlexPortChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.flex_port = txtFlexPort.Text;
            Properties.Settings.Default.Save();
            m_tuner.FlexPort = Int32.Parse(txtFlexPort.Text);
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
