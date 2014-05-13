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
            this.txtYield.Text = settings.GetYield().ToString();
            this.txtRefineOutput.Text = settings.GetNetYield().ToString(CultureInfo.InvariantCulture);
            this.txtTaxes.Text = settings.GetTaxes().ToString(CultureInfo.InvariantCulture);
        }

        private void frmParams_Load(object sender, EventArgs e)
        {
            this.Text = Program.PROGRAM_NAME + " - Parameters";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.parent.GetSettingsManager().UpdateSettings(int.Parse(this.cmbTimerSetting.Text),
                    int.Parse(this.txtCycle.Text),
                    int.Parse(this.txtYield.Text),
                    double.Parse(this.txtRefineOutput.Text, CultureInfo.InvariantCulture),
                    double.Parse(this.txtTaxes.Text, CultureInfo.InvariantCulture),
                    this.parent.GetSettingsManager().GetCurrentSystem());
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

        private void cmbTimerSetting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
