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
    public partial class frmPrefs : Form
    {
        // Parameters
        private frmMain parent;
        private int updateTimerSetting;

        // Methods
        public frmPrefs(int updateTimer, frmMain parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.updateTimerSetting = updateTimer;
            this.cmbTimerSetting.Text = updateTimer.ToString();
        }

        private void frmPrefs_Load(object sender, EventArgs e)
        {

        }
        
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                this.updateTimerSetting = int.Parse(this.cmbTimerSetting.Text);
                this.parent.SetUpdateTimer(this.updateTimerSetting);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Parsing exception: "+ex.Message, "Exception",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
