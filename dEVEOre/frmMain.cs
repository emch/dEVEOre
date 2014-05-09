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
        private int         updateTimer; // in minutes
        private int         lastUpdate;

        private int         cycle; // in seconds
        private int         yield;
        private double      netYield; // in percents
        private double      taxes; // in percents

        private int         currentSystem;

        private frmParams   frmParams;
        private frmPrefs    frmPrefs;
        private frmAbout    frmAbout;

        // Constants
        public static String CONFIG_FILE_PATH = "config.cfg";

        // Methods
        public frmMain()
        {
            InitializeComponent();

            // Load config file
            this.LoadConfig(CONFIG_FILE_PATH);

            // Load data files

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmPrefs = new frmPrefs(this.updateTimer, this);
            this.frmPrefs.Show();
        }

        private void characterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmParams = new frmParams(this.cycle, this.yield, this.netYield, this.taxes, this);
            this.frmParams.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmAbout = new frmAbout();
            this.frmAbout.Show();
        }

        public void SetUpdateTimer(int seconds)
        {
            this.updateTimer = seconds;
        }

        public void SetParams(int cycle, int yield, double netYield, double taxes)
        {
            this.cycle = cycle;
            this.yield = yield;
            this.netYield = netYield;
            this.taxes = taxes;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        ////////////////////// CONFIG FILE MANAGEMENT //////////////////////
        // Loading config file
        private void LoadConfig(String path)
        {
            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadLine();
                    String[] split = line.Split(new Char[] {' '});

                    this.updateTimer = int.Parse(split[0]);
                    this.cycle = int.Parse(split[1]);
                    this.yield = int.Parse(split[2]);
                    this.netYield = double.Parse(split[3], CultureInfo.InvariantCulture);
                    this.taxes = double.Parse(split[4], CultureInfo.InvariantCulture);
                }
            }
            catch //(Exception ex)
            {
                // Loading default values
                this.updateTimer = 30;
                this.cycle = 60;
                this.yield = 202;
                this.netYield = 85.00;
                this.taxes = 4.45;

                // Saving these values to config file
                String saveString = this.updateTimer.ToString() + " " + this.cycle.ToString() + " " + this.yield.ToString() + " " + this.netYield.ToString(CultureInfo.InvariantCulture) + " " + this.taxes.ToString(CultureInfo.InvariantCulture);
                TextWriter tw = new StreamWriter(CONFIG_FILE_PATH);
                tw.WriteLine(saveString);
                tw.Close();
            }
        }

        public void SaveConfig(String path)
        {
            String saveString = this.updateTimer.ToString() + " " + this.cycle.ToString() + " " + this.yield.ToString() + " " + this.netYield.ToString(CultureInfo.InvariantCulture) + " " + this.taxes.ToString(CultureInfo.InvariantCulture);
            TextWriter tw = new StreamWriter(CONFIG_FILE_PATH);
            tw.WriteLine(saveString);
            tw.Close();
        }
        ////////////////////////////////////////////////////////////////////

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
