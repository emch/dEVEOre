using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dEVEOre
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.Text = Program.PROGRAM_NAME + " - About";
            this.labelVersion.Text = Program.PROGRAM_NAME + " v" +
                Program.PROGRAM_VERSION.ToString() + "." +
                Program.PROGRAM_VERSION_NEWFEATURE.ToString() + "." +
                Program.PROGRAM_VERSION_BUG.ToString();
        }
    }
}
