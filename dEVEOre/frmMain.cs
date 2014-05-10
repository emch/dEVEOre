using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace dEVEOre
{
    public partial class frmMain : Form
    {
        // Parameters
        private SettingsManager settings;
        private DataManager     data;

        private frmParams       frmParams;
        private frmAbout        frmAbout;

        // Methods
        public frmMain()
        {
            InitializeComponent();
        }

        public SettingsManager GetSettingsManager()
        {
            return this.settings;
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmParams = new frmParams(this.settings, this);
            this.frmParams.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmAbout = new frmAbout();
            this.frmAbout.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Initialize settings manager
            this.settings = new SettingsManager();

            // Initialize data manager
            try
            {
                this.data = new DataManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A problem occurred while accessing data files: " + ex.Message, "Exception",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                this.Close();
            }

            this.lblLastUpdate.Text = this.settings.GetLastUpdate().ToString();
            this.UpdateTimerInterval(this.settings.GetUpdateTimer());
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            this.updateTimer.Enabled = false;

            // here, update prices using Xml request and dataManager!

            this.settings.SetUpdated();
            this.lblLastUpdate.Text = this.settings.GetLastUpdate().ToString();

            this.updateTimer.Enabled = true;
        }

        public void UpdateTimerInterval(int minutes)
        {
            this.updateTimer.Enabled = false;
            this.updateTimer.Interval = minutes * 1000 * 60;
            this.updateTimer.Enabled = true;
        }
    }
}
