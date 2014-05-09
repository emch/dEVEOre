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
        private double refineOutput;
        private frmMain parent;

        // Methods
        public frmParams(int cycle, int yield, double refineOutput, frmMain parent)
        {
            InitializeComponent();

            this.parent = parent;

            this.cycle = cycle;
            this.yield = yield;
            this.refineOutput = refineOutput;

            this.txtCycle.Text = cycle.ToString();
            this.txtYield.Text = yield.ToString();
            this.txtRefineOutput.Text = refineOutput.ToString(CultureInfo.InvariantCulture);
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
                this.refineOutput = double.Parse(this.txtRefineOutput.Text, CultureInfo.InvariantCulture);

                this.parent.SetParams(this.cycle, this.yield, this.refineOutput);
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
