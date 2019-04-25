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
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void on_load(object sender, EventArgs e)
        {
            lblName.Text = Application.ProductName;
            lblDesc.Text = "Application to contorl LDG-AT1000ProII and ALS-600";
            lblCpRight.Text = "Released to Public Domain 2019 by WK2X";
            lblVersion.Text = Application.ProductVersion;
        }
    }
}
