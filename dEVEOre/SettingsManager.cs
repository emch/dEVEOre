﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace dEVEOre
{
    public class SettingsManager
    {
        // Parameters
        private int updateTimer; // in minutes
        private DateTime lastUpdate;

        private int cycle; // in seconds
        private int yield;
        private double netYield; // in percents
        private double taxes; // in percents

        private EveSystem currentSystem;

        // Constants
        public static String CONFIG_FILE_PATH = "config.cfg";

        // Methods
        public SettingsManager()
        {
            this.LoadSettings(CONFIG_FILE_PATH);
            this.lastUpdate = DateTime.Now;
        }

        public int GetUpdateTimer() { return this.updateTimer; }
        public int GetCycle() { return this.cycle; }
        public int GetYield() { return this.yield; }
        public double GetNetYield() { return this.netYield; }
        public double GetTaxes() { return this.taxes; }
        public DateTime GetLastUpdate() { return this.lastUpdate; }

        public void SetUpdated()
        {
            this.lastUpdate = DateTime.Now;
        }

        public void UpdateSettings(int seconds, int cycle, int yield, double netYield, double taxes)
        {
            this.updateTimer = seconds;
            this.cycle = cycle;
            this.yield = yield;
            this.netYield = netYield;
            this.taxes = taxes;
        }

        private void LoadSettings(String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadLine();
                    String[] split = line.Split(new Char[] { ' ' });

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

        public void SaveSettings(String path)
        {
            String saveString = this.updateTimer.ToString() + " " + this.cycle.ToString() + " " + this.yield.ToString() + " " + this.netYield.ToString(CultureInfo.InvariantCulture) + " " + this.taxes.ToString(CultureInfo.InvariantCulture);
            TextWriter tw = new StreamWriter(CONFIG_FILE_PATH);
            tw.WriteLine(saveString);
            tw.Close();
        }
    }
}