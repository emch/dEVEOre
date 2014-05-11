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
using System.Xml;

namespace dEVEOre
{
    public partial class frmMain : Form
    {
        // Parameters
        private SettingsManager settings;
        private DataManager     data;

        private frmParams       frmParams;
        private frmAbout        frmAbout;

        private EveSystem       currentSystem;

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

            // add EveSystem name to cmbEveSystem list
            for (int k = 0; k < this.data.GetEveSystemData().Length; k++)
            {
                this.cmbEveSystem.Items.Add(this.data.GetEveSystemData()[k].GetName());
            }

            this.currentSystem = this.data.GetEveSystemById(this.settings.GetCurrentSystem());
            this.cmbEveSystem.Text = this.currentSystem.GetName();

            // Update Xml/prices and results
            this.UpdateData(this.currentSystem);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateTimerInterval(int minutes)
        {
            this.updateTimer.Enabled = false;
            this.updateTimer.Interval = minutes * 1000 * 60;
            this.updateTimer.Enabled = true;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            this.updateTimer.Enabled = false;

            // Update Xml/prices and results
            this.UpdateData(this.currentSystem);

            this.settings.SetUpdated();
            this.lblLastUpdate.Text = this.settings.GetLastUpdate().ToString();

            this.updateTimer.Enabled = true;
        }

        private void cmbEveSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update label:
            this.lblCurrentSystem.Text = this.cmbEveSystem.SelectedItem.ToString();

            // update SettingsManager with selected system:
            this.currentSystem = this.data.GetEveSystemByName(this.cmbEveSystem.SelectedItem.ToString());
            this.settings.UpdateCurrentSystem(this.currentSystem.GetId());

            // Update Xml/prices and results
            this.UpdateData(this.currentSystem);

            // Update label
            this.lblLastUpdate.Text = DateTime.Now.ToString();

            // Reset Timer?
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Update Xml/prices and results
            this.UpdateData(this.currentSystem);

            // Update label
            this.lblLastUpdate.Text = DateTime.Now.ToString();

            // Reset Timer?
        }

        private void UpdateData(EveSystem currentSystem)
        {
            // Update Xml
            this.data.UpdateXmlData(currentSystem);

            // Update prices
            try
            {
                this.data.UpdatePrices(currentSystem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception raised while updating prices: " + ex.Message, "Exception",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }

            // Update results TODO

            // Debug
            String saveString = this.data.GetOreData()[0].GetMaxBuyPrice().ToString(CultureInfo.InvariantCulture);
            TextWriter tw = new StreamWriter("debug.txt");
            tw.WriteLine(saveString);
            tw.Close();
        }
    }
}
