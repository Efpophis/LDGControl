using LDGControl.Properties;
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
    public partial class FlexConfig : Form
    {
        public FlexConfig()
        {
            InitializeComponent();
        }

        private void btnFlexCfgApply_Click(object sender, EventArgs e)
        {
            Settings.Default.flex_enabled = chkEnableFlex.Checked;
            Settings.Default.flex_discovery = chkFlexDiscovery.Checked;
            Settings.Default.flex_host = txtFlexHost.Text;
            Settings.Default.flex_port = (int)numFlexPort.Value;
            Settings.Default.Save();
        }

        private void chkEnableFlex_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEnableFlex.Checked == true)
            {
                chkFlexDiscovery.Enabled = true;

                if (chkFlexDiscovery.Checked == false)
                {
                    txtFlexHost.Enabled = true;
                    numFlexPort.Enabled = true;
                }
                else
                {
                    txtFlexHost.Enabled = false;
                    numFlexPort.Enabled = false;
                }
            }
            else
            {
                chkFlexDiscovery.Enabled = false;
                txtFlexHost.Enabled = false;
                numFlexPort.Enabled = false;
            }
        }

        private void chkFlexDiscovery_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkFlexDiscovery.Checked == true)
            {
                txtFlexHost.Enabled = false;
                numFlexPort.Enabled = false;
            }
            else
            {
                txtFlexHost.Enabled = true;
                numFlexPort.Enabled = true;
            }

        }

        private void FlexConfig_Load(object sender, EventArgs e)
        {
            chkEnableFlex.Checked = Settings.Default.flex_enabled;        
            chkFlexDiscovery.Checked = Settings.Default.flex_discovery;                
            txtFlexHost.Text = Settings.Default.flex_host;
            numFlexPort.Value = Settings.Default.flex_port;
        }
    }
}
