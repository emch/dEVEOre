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
        private frmSystems      frmSystems;

        private EveSystem       currentSystem;

        private DataTable       orePricesData;
        private DataTable       mineralPricesData;

        // Methods
        public frmMain()
        {
            InitializeComponent();
        }

        public DataManager GetDataManager()
        {
            return this.data;
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

        private void manageSystemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmSystems = new frmSystems(this, this.data);
            this.frmSystems.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Setup form text
            this.Text = Program.PROGRAM_NAME + " v" + Program.PROGRAM_VERSION.ToString() + "." +
                Program.PROGRAM_VERSION_NEWFEATURE.ToString() + "." +
                Program.PROGRAM_VERSION_BUG.ToString();

            // Initialize Datatables
            this.orePricesData = new DataTable();
            this.orePricesData.Columns.Add("Ore");
            this.orePricesData.Columns.Add("Max buy");

            this.mineralPricesData = new DataTable();
            this.mineralPricesData.Columns.Add("Mineral");
            this.mineralPricesData.Columns.Add("Max buy");

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
            this.UpdateSystemCmb();

            this.currentSystem = this.data.GetEveSystemById(this.settings.GetCurrentSystem());
            this.cmbEveSystem.Text = this.currentSystem.GetName();

            // Update Xml/prices and results
            this.UpdateData(this.currentSystem);
        }

        /**
         * UpdateSystemsCmb
         * 
         * Update combo box listing available systems.
         * */
        public void UpdateSystemCmb()
        {
            this.cmbEveSystem.Items.Clear();
            for (int k = 0; k < this.data.GetEveSystemData().Length; k++)
            {
                this.cmbEveSystem.Items.Add(this.data.GetEveSystemData()[k].GetName());
            }
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

        public void UpdateData(EveSystem currentSystem)
        {
            try
            {
                // Update Xml
                this.data.UpdateXmlData(currentSystem);

                // Update prices
                this.data.UpdatePrices();

                // Update results TODO
                this.data.UpdateProfitData(this.settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception raised while updating prices: " + ex.Message, "Exception",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }

            // Update forms
            this.UpdateDataGridViewPrices();
            this.UpdataDataGridViewProfit();
        }

        private void UpdataDataGridViewProfit()
        {
            this.dataGridViewProfit.DataSource = this.data.GetProfitDataTable();

            for (int k = 1; k < this.dataGridViewProfit.Columns.Count; k++)
            {
                this.dataGridViewProfit.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewProfit.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void UpdateDataGridViewPrices()
        {
            this.orePricesData.Clear();
            this.mineralPricesData.Clear();

            for (int k = 0; k < this.data.GetOreData().Length; k++)
            {
                this.orePricesData.Rows.Add(this.data.GetOreData()[k].GetName(), this.data.GetOreData()[k].GetMaxBuyPrice().ToString("#,##0.00", CultureInfo.InvariantCulture));
            }

            for (int k = 0; k < this.data.GetMineralData().Length; k++)
            {
                this.mineralPricesData.Rows.Add(this.data.GetMineralData()[k].GetName(), this.data.GetMineralData()[k].GetMaxBuyPrice().ToString("#,##0.00", CultureInfo.InvariantCulture));
            }

            this.dataGridViewOrePrices.DataSource = this.orePricesData;
            this.dataGridViewMineralPrices.DataSource = this.mineralPricesData;

            // Aligning on right!
            this.dataGridViewOrePrices.Columns["Max buy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewMineralPrices.Columns["Max buy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Disable sorting
            this.dataGridViewOrePrices.Columns["Max buy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewMineralPrices.Columns["Max buy"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
