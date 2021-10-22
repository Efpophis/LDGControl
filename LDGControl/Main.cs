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
                   lblWtf.Text = wtf.ToString();
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
            double voltage;

            // This is derived from a pretty crazy A/D conversion formula that
            // assumes, among other things, a 13.8V reference voltage
            //
            // raw = (2^16 * (( sqrt( watts * 50 ) * .707 ) / 1000)) / Vref
            //
            // solve for watts in terms of raw and Vref == 13.8, and you
            // boil it down to this.

            //result = 0.001718294 * raw * raw * 0.6f;

            tosquare = (1000.0f * 13.8f * raw) / (65536.0f * 1.414f); //0.707);

            result = (tosquare * tosquare) / 50.0f;

            // un-do ADC assuming 13.8v reference voltage

            // raw = (65536.0f * voltage) / 13.8f;
            // raw * 13.8f = 65536.0f * voltage;
            // (raw * 13.8f) / 65536.0f = voltage;
            // voltage = (raw * 13.8f) / 65536.0f;


            

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
            if (btnBypass.BackColor == Color.Green)
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
                            btnBypass.BackColor = Color.Green;
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

        private void TuneResult( byte[] result )
        {
            if (result != null)
            {
                char status = (char)result[0];
                if (status == 'T')
                {
                    lblTuneStatus.Text = "GOOD";
                    lblTuneStatus.BackColor = Color.Green;
                }
                else if (status == 'M')
                {
                    lblTuneStatus.Text = "OKAY";
                    lblTuneStatus.BackColor = Color.Yellow;
                }
                else if (status == 'F')
                {
                    lblTuneStatus.Text = "FAIL";
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
