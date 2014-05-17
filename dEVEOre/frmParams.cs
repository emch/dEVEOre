using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace dEVEOre
{
    public partial class frmParams : Form
    {
        // Parameters
        private frmMain parent;

        // Methods
        public frmParams(SettingsManager settings, frmMain parent)
        {
            InitializeComponent();

            this.parent = parent;

            this.cmbTimerSetting.Text = settings.GetUpdateTimer().ToString();
            this.txtCycle.Text = settings.GetCycle().ToString();
            this.txtYield.Text = settings.GetYield().ToString(CultureInfo.InvariantCulture);
            this.txtRefineOutput.Text = settings.GetNetYield().ToString(CultureInfo.InvariantCulture);
            this.txtTaxes.Text = settings.GetTaxes().ToString(CultureInfo.InvariantCulture);
        }

        private void frmParams_Load(object sender, EventArgs e)
        {
            this.Text = Program.PROGRAM_NAME + " - Parameters";
            this.UpdateLists();
        }

        // TODO: update selected ore in parent.DataManager !!
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.parent.GetSettingsManager().UpdateSettings(int.Parse(this.cmbTimerSetting.Text),
                    int.Parse(this.txtCycle.Text),
                    double.Parse(this.txtYield.Text, CultureInfo.InvariantCulture),
                    double.Parse(this.txtRefineOutput.Text, CultureInfo.InvariantCulture),
                    double.Parse(this.txtTaxes.Text, CultureInfo.InvariantCulture),
                    this.parent.GetSettingsManager().GetCurrentSystem(),
                    this.GetSelectedBaseOres());
                this.parent.GetSettingsManager().SaveSettings(SettingsManager.CONFIG_FILE_PATH);

                // resetting update Timer
                this.parent.UpdateTimerInterval(int.Parse(this.cmbTimerSetting.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parsing exception: " + ex.Message, "Exception",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            this.parent.UpdateData(this.parent.GetDataManager().GetEveSystemById(this.parent.GetSettingsManager().GetCurrentSystem()));
            this.Close();
        }

        private void UpdateLists()
        {
            this.lstOre.Items.Clear();
            this.lstOreFollowed.Items.Clear();

            Ore[] tmpOreData = this.parent.GetDataManager().GetOreData();
            for (int k = 0; k < tmpOreData.Length; k++)
            {
                if (tmpOreData[k].IsSelected() > 0 && tmpOreData[k].GetPercentIncreasedYield() == 0) //
                { // this is a base ore and its selected
                    this.lstOreFollowed.Items.Add(tmpOreData[k].GetName());
                }
                else if (tmpOreData[k].GetPercentIncreasedYield() == 0)
                {
                    this.lstOre.Items.Add(tmpOreData[k].GetName());
                }
            }
        }

        private uint GetSelectedBaseOres()
        {
            uint res = 0; uint baseOreCounter = 1;
            Ore[] tmpOreData = this.parent.GetDataManager().GetOreData();
            for (int k = 0; k < this.lstOreFollowed.Items.Count; k++)
            {
                for (int j = 0; j < tmpOreData.Length; j++)
                {
                    if (this.lstOreFollowed.Items[k].ToString() == tmpOreData[j].GetName() && tmpOreData[j].GetPercentIncreasedYield() == 0)
                    {
                        res += baseOreCounter;
                        baseOreCounter *= 2;
                    }
                }
            }
            return res;
        }
    }
}
