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
                m_amp.ampOn();
            }
        }

        private void on_AmpStbyCheckChanges(object sender, EventArgs e)
        {
            if ( ampStbyBtn.Checked == true )
            {
                m_amp.ampOff();
            }
        }

        private void on_AmpResetClick(object sender, EventArgs e)
        {
            //m_amp.ampReset();
            ampStbyBtn.Checked = true;
            System.Threading.Thread.Sleep(1000);
            ampOperateBtn.Checked = true;
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

        protected void updateMeter(Int16 fwd, Int16 refl, Int16 wtf)
        {
            double vswr = 0.0f;
            double sqr = Math.Sqrt((((double)fwd) / ((double)refl)));

            vswr = Math.Abs((1.0f + sqr) / (1.0f - sqr));

            lblFwd.Invoke ((MethodInvoker)delegate 
                {
                    // do all UI updates in here...
                    lblFwd.Text = fwd.ToString();
                    lblRef.Text = refl.ToString();                    
                    lblSwr.Text = vswr.ToString() + " : 1";
                    lblWtf.Text = wtf.ToString();
                }
            );

        }

        private void btnTunerInit_Click(object sender, EventArgs e)
        {
            string tunerPort = cmbTunerPorts.SelectedItem.ToString();

            m_tuner = new Tuner(tunerPort, updateMeter);
            m_tuner.Init();

            Properties.Settings.Default["tuner_port"] = tunerPort;
            Properties.Settings.Default.Save();
            btnTunerInit.Enabled = false;
        }
    }
}
