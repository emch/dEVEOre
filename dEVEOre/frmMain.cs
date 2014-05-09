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
        private int     updateTimer;
        private int     cycle;
        private int     yield;
        private double  refineSkill;

        private Form    frmOre;
        private Form    frmStats;
        private Form    frmPrefs;

        // Methods
        public frmMain()
        {
            InitializeComponent();

            // Load data files in objects or default config if inexistant
            this.updateTimer = 60; // read in config.cfg
        }

        private void oreTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmOre = new frmOre();
            this.frmOre.Show();
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
    }
}
