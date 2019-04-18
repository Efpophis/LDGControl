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
        public Main()
        {
            InitializeComponent();
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
            using (AboutBox1 box = new AboutBox1())
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

            double p_refl = meterScale(refl);
            double p_fwd = meterScale(fwd);

            if (refl > 0.0f)
            {
                sqr = Math.Sqrt(p_fwd / p_refl);

                vswr = Math.Abs((1.0f + sqr) / (1.0f - sqr));
            }
            else
                vswr = 1.0f;

            lblFwd.Invoke ((MethodInvoker)delegate 
                {
                    // do all UI updates in here...
                    lblFwd.Text = p_fwd.ToString();
                    fwdMeter.Value = pwrMeterLEDS(p_fwd);
                    
                    lblRef.Text = p_refl.ToString();
                    refMeter.Value = pwrMeterLEDS(p_refl);
                    

                    lblSwr.Text = vswr.ToString() + " : 1";
                    swrMeter.Value = swrMeterLEDS(vswr);

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

            if (pwr > 0.0f) ++result;

            if (pwr > 10.0f) ++result;

            if (pwr > 25.0f) ++result;

            if (pwr > 50.0f) ++result;

            if (pwr > 150.0f) ++result;

            if (pwr > 275.0f) ++result;

            if (pwr > 550.0f) ++result;

            if (pwr > 800.0f) ++result; 

            return result;
        }

        private double meterScale( UInt16 raw )
        {
            double result;
            const UInt16 w100 = 272;

            if ( raw < w100 )
            {
                result = ((double)(raw) / (double)w100) * 100.0f;
            }
            else
            {
                raw -= w100;
                result = 100.0f + (900.0f * ((double)(raw) / (1024-w100)));
            }            

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
