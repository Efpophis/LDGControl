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
            Settings.Default.flex_discovery = btnDiscoveryEn.Checked;
            Settings.Default.flex_host = txtFlexHost.Text;
            Settings.Default.flex_port = (int)numFlexPort.Value;
            Settings.Default.flex_autoconn = chkFlexAutoConnect.Checked;
            Settings.Default.Save();
        }

        private void chkEnableFlex_CheckStateChanged(object sender, EventArgs e)
        {
            btnDiscoveryEn.Enabled = btnDiscoveryEn.Visible =
            btnFlexManual.Enabled = btnFlexManual.Visible =
            chkFlexAutoConnect.Enabled = chkFlexAutoConnect.Visible = chkEnableFlex.Checked;
            
            label1.Visible = label2.Visible = label3.Visible =
            txtFlexHost.Visible = numFlexPort.Visible = chkEnableFlex.Checked && btnFlexManual.Checked;
        }

        private void FlexConfig_Load(object sender, EventArgs e)
        {
            chkEnableFlex.Checked = Settings.Default.flex_enabled;
            btnDiscoveryEn.Checked = Settings.Default.flex_discovery;
            btnFlexManual.Checked = !btnDiscoveryEn.Checked;            
            txtFlexHost.Text = Settings.Default.flex_host;
            numFlexPort.Value = Settings.Default.flex_port;
            chkFlexAutoConnect.Checked = Settings.Default.flex_autoconn;
            btnFlexManual_CheckedChanged(sender, e);
            chkEnableFlex_CheckStateChanged(sender, e);
        }

        private void btnFlexManual_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = label2.Visible = label3.Visible = 
            txtFlexHost.Visible = numFlexPort.Visible = 
            txtFlexHost.Enabled = numFlexPort.Enabled = btnFlexManual.Checked;            
        }
    }
}
