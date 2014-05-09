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
    public partial class frmMain : Form
    {
        // Parameters
        private int         updateTimer; // in minutes
        private int         lastUpdate;

        private int         cycle;
        private int         yield;
        private double      refineSkill;

        private int         currentSystem;

        private Form        frmStats;
        private frmPrefs    frmPrefs;

        // Methods
        public frmMain()
        {
            InitializeComponent();

            // Load data files in objects or default config if inexistant
            this.updateTimer = 15; // read in config.cfg
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmPrefs = new frmPrefs(this.updateTimer, this);
            this.frmPrefs.Show();
        }

        public void SetUpdateTimer(int seconds)
        {
            this.updateTimer = seconds;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
