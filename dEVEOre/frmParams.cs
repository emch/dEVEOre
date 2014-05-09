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
        private int cycle;
        private int yield;
        private double netYield;
        private double taxes;
        private frmMain parent;

        // Methods
        public frmParams(int cycle, int yield, double netYield, double taxes, frmMain parent)
        {
            InitializeComponent();

            this.parent = parent;

            this.cycle = cycle;
            this.yield = yield;
            this.netYield = netYield;
            this.taxes = taxes;

            this.txtCycle.Text = cycle.ToString();
            this.txtYield.Text = yield.ToString();
            this.txtRefineOutput.Text = netYield.ToString(CultureInfo.InvariantCulture);
            this.txtTaxes.Text = taxes.ToString(CultureInfo.InvariantCulture);
        }

        private void frmParams_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.cycle = int.Parse(this.txtCycle.Text);
                this.yield = int.Parse(this.txtYield.Text);
                this.netYield = double.Parse(this.txtRefineOutput.Text, CultureInfo.InvariantCulture);
                this.taxes = double.Parse(this.txtTaxes.Text, CultureInfo.InvariantCulture);

                this.parent.SetParams(this.cycle, this.yield, this.netYield, this.taxes);
                this.parent.SaveConfig(frmMain.CONFIG_FILE_PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parsing exception: " + ex.Message, "Exception",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
