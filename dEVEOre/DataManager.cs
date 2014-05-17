using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Data;
using System.Net;
using System.Xml;

namespace dEVEOre
{
    /**
     * DataManager
     * 
     * DataManager class is used to load (from .dat files) and store data and to retrieve API info about prices (Xml format).
     * */
    public class DataManager
    {
        // Parameters
        private Ore[] OreData;                      // Ore data
        private Mineral[] MineralData;              // Mineral data
        private EveSystem[] EveSystemData;          // Systems data
        private RefineTable RefineData;             // Refine data
        private DataTable profitData;               // Profit data (calculations)

        private XmlDocument ApiXmlData;             // This is used to stroe EVE API server answer to user/program request
        private XmlNamespaceManager ApiXmlDataNS;   // Namespace manager

        // Constants (path to .dat files)
        private const String ORE_DATAFILE_PATH = "data/ore.dat";
        private const String MINERAL_DATAFILE_PATH = "data/minerals.dat";
        private const String REFINE_DATAFILE_PATH = "data/refine.dat";
        public const String EVESYSTEM_DATAFILE_PATH = "data/systems.dat";

        // Methods

        // (Getters)
        public Ore[] GetOreData() { return this.OreData; }
        public Mineral[] GetMineralData() { return this.MineralData; }
        public EveSystem[] GetEveSystemData() { return this.EveSystemData; }
        public XmlDocument GetApiXmlData() { return this.ApiXmlData; }
        public XmlNamespaceManager GetApiXmlDataNamespaceManager() { return this.ApiXmlDataNS; }
        public DataTable GetProfitDataTable() { return this.profitData; }

        /**
         * UpdateProfitData
         * 
         * Using prices data in OreData and MineralData, this method manages to calculate all the data which is shown in the main frame.
         * Produced data is stored in profitData parameter of type DataTable
         * 
         * Settings are used as input to provide info like player's yield/cycle/...
         * */
        public void UpdateProfitData(SettingsManager settings)
        {
            this.profitData.Clear();

            double refinedBasePerUnit, refinedPerUnit;
            double notRefinedPerUnit;
            double refinedPerMCube;
            double notRefinedPerMCube;
            double refinedPerCycle;
            double notRefinedPerCycle;
            double refinedPerHour;
            double notRefinedPerHour;

            // For each Mineral
            for (int k = 0; k < this.OreData.Length; k++)
            {
                // Reset
                refinedBasePerUnit = 0; refinedPerUnit = 0; 
                notRefinedPerUnit = 0;
                refinedPerMCube = 0;
                notRefinedPerMCube = 0;
                refinedPerCycle = 0;
                notRefinedPerCycle = 0;
                refinedPerHour = 0;
                notRefinedPerHour = 0;

                // Profit per refined unit of considered ore
                for (int j = 0; j < this.MineralData.Length; j++)
                {
                    refinedBasePerUnit += this.MineralData[j].GetMaxBuyPrice() *
                        this.RefineData.GetRefineQty(this.OreData[k].GetBaseOreId(), this.MineralData[j]) *
                        settings.GetNetYield()/100;
                }
                refinedBasePerUnit /= this.RefineData.GetBatch(this.OreData[k].GetBaseOreId());
                refinedPerUnit = refinedBasePerUnit + refinedBasePerUnit * this.OreData[k].GetPercentIncreasedYield()/100;
                refinedPerUnit -= refinedPerUnit * settings.GetTaxes() / 100;

                // Profit per not refined unit of considered ore
                notRefinedPerUnit = this.OreData[k].GetMaxBuyPrice();

                // Per m3
                refinedPerMCube = refinedPerUnit / this.OreData[k].GetVolumePerUnit();
                notRefinedPerMCube = notRefinedPerUnit / this.OreData[k].GetVolumePerUnit();

                // Per cycle
                refinedPerCycle = refinedPerMCube * settings.GetYield();
                notRefinedPerCycle = notRefinedPerMCube * settings.GetYield();

                // Per hour (warning, GetCycle returns a result in seconds)
                refinedPerHour = 3600 * refinedPerCycle / settings.GetCycle();
                notRefinedPerHour = 3600 * notRefinedPerCycle / settings.GetCycle();

                // Add row
                this.profitData.Rows.Add(this.OreData[k].GetName(),
                    refinedPerUnit.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    notRefinedPerUnit.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    refinedPerMCube.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    notRefinedPerMCube.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    refinedPerCycle.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    notRefinedPerCycle.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    refinedPerHour.ToString("#,##0.00", CultureInfo.InvariantCulture),
                    notRefinedPerHour.ToString("#,##0.00", CultureInfo.InvariantCulture));
            }
        }

        /**
         * Constructor
         * 
         * Also creates Columns in this.profitData (type DataTable)
         * */
        public DataManager(SettingsManager settings)
        {
            try
            {
                this.LoadOreData(ORE_DATAFILE_PATH, settings.GetSelectedOre());
                this.LoadMineralData(MINERAL_DATAFILE_PATH);
                this.LoadEveSystemData(EVESYSTEM_DATAFILE_PATH);
                //this.LoadRefineData(REFINE_DATAFILE_PATH);
                this.ApiXmlData = new XmlDocument();
                this.RefineData = new RefineTable(this.OreData.Length, this.MineralData.Length, REFINE_DATAFILE_PATH);

                // Setting up profit DataTable
                this.profitData = new DataTable();
                this.profitData.Columns.Add("Ore");
                this.profitData.Columns.Add("Ref/u");
                this.profitData.Columns.Add("NotRef/u");
                this.profitData.Columns.Add("Ref/m3");
                this.profitData.Columns.Add("NotRef/m3");
                this.profitData.Columns.Add("Ref/cy");
                this.profitData.Columns.Add("NotRef/cy");
                this.profitData.Columns.Add("Ref/h");
                this.profitData.Columns.Add("NotRef/h");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /**
         * UpdatePrices
         * 
         * Update prices in OreData and MineralData relative parameters.
         * XmlData is updated prior to this using UpdateXmlData (see below).
         * */
        public void UpdatePrices()
        {
            double price = 0;
            for (int k = 0; k < this.OreData.Length; k++)
            {
                try
                {
                    price = double.Parse(this.ApiXmlData.SelectSingleNode("//type[@id=\"" + OreData[k].GetId() + "\"]", this.ApiXmlDataNS).SelectSingleNode("buy").SelectSingleNode("max").InnerText, CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                this.OreData[k].SetMaxBuyPrice(price);
            }
            for (int k = 0; k < this.MineralData.Length; k++)
            {
                try
                {
                    price = double.Parse(this.ApiXmlData.SelectSingleNode("//type[@id=\"" + MineralData[k].GetId() + "\"]", this.ApiXmlDataNS).SelectSingleNode("buy").SelectSingleNode("max").InnerText, CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                this.MineralData[k].SetMaxBuyPrice(price);
            }
        }

        /**
         * UpdateXmlData
         * 
         * Using request from GetXmlRequestString, this updates XmlDocument ApiXmlData from which specific nodes will be read.
         * */
        public void UpdateXmlData(EveSystem currentSystem)
        {
            String requestString = this.GetXmlRequestString(currentSystem);

            try // typical exception: server not found when not connected to the internet!
            {
                this.ApiXmlData.Load(requestString);
                this.ApiXmlDataNS = new XmlNamespaceManager(this.GetApiXmlData().NameTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /**
         * GetXmlRequestString
         * 
         * This creates a request string to send to EVE API server containing info on considered objects (typeid) and system (usesystem).
         * */
        private String GetXmlRequestString(EveSystem currentSystem)
        {
            System.Text.StringBuilder res = new System.Text.StringBuilder();

            res.Append("http://api.eve-central.com/api/marketstat?");

            for (int k = 0; k < this.OreData.Length; k++)
            {
                res.Append("&typeid=").Append(this.OreData[k].GetId());
            }
            for (int k = 0; k < this.MineralData.Length; k++)
            {
                res.Append("&typeid=").Append(this.MineralData[k].GetId());
            }
            res.Append("&usesystem=").Append(currentSystem.GetId().ToString());

            return res.ToString();
        }

        /**
         * GetEveSystemById
         * 
         * Name speaks for itself!
         * */
        public EveSystem GetEveSystemById(int id)
        {
            for (int k = 0; k < this.EveSystemData.Length; k++)
            {
                if (this.EveSystemData[k].GetId() == id)
                {
                    return this.EveSystemData[k];
                }
            }
            return new EveSystem(-1, "error");
        }

        /**
         * GetEveSystemByName
         * */
        public EveSystem GetEveSystemByName(String name)
        {
            for (int k = 0; k < this.EveSystemData.Length; k++)
            {
                if (String.Compare(this.EveSystemData[k].GetName(), name, true, CultureInfo.InvariantCulture) == 0)
                {
                    return this.EveSystemData[k];
                }
            }
            return new EveSystem(-1, "error");
        }

        /**
         * LoadOreData
         * 
         * Loads Ore data in this.OreData array from specified .dat file (datapath)
         * */
        private void LoadOreData(String datapath, uint selectedOre)
        {
            try
            {
                this.OreData = new Ore[this.GetDataFileLineNumber(datapath)];

                using (StreamReader sr = new StreamReader(datapath))
                {
                    String line; int k = 0; uint baseOreCounter = 1;
                    String[] split;
                    String newOreName; int newOreId; int newOreBaseOreId; double newOrePercentIncreasedYield; double newOreVolumePerUnit;
                    double newOreSecurity; uint newOreSelected = 0;
                    
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Splitting along " character
                        split = line.Split(new Char[] { '"' });
                        newOreName = split[1];
                        split = split[0].Split(new Char[] { ' ' });
                        newOreId = int.Parse(split[0]);
                        newOrePercentIncreasedYield = double.Parse(split[1], CultureInfo.InvariantCulture);
                        newOreBaseOreId = int.Parse(split[2]);
                        newOreVolumePerUnit = double.Parse(split[3], CultureInfo.InvariantCulture);
                        newOreSecurity = double.Parse(split[4], CultureInfo.InvariantCulture);

                        if (newOrePercentIncreasedYield == 0) // only base ore are described as selected or not
                        {
                            newOreSelected = selectedOre & baseOreCounter; //   reading single bit in int (not working)
                            baseOreCounter *= 2;
                        }

                        this.OreData[k] = new Ore(newOreId,
                            newOreName,
                            newOreBaseOreId,
                            newOrePercentIncreasedYield,
                            newOreVolumePerUnit,
                            newOreSecurity,
                            newOreSelected); // if newOreSelected > 0 then bit was present in int

                        k += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /**
         * LoadMineralData
         * 
         * Loads Mineral data in this.MineralData array from specified .dat file (datapath)
         * */
        private void LoadMineralData(String datapath)
        {
            try
            {
                this.MineralData = new Mineral[this.GetDataFileLineNumber(datapath)];

                using (StreamReader sr = new StreamReader(datapath))
                {
                    String line; int k = 0;
                    String[] split;
                    String newMineralName; int newMineralId;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Splitting along " character
                        split = line.Split(new Char[] { '"' });
                        newMineralName = split[1];
                        split = split[0].Split(new Char[] { ' ' });
                        newMineralId = int.Parse(split[0]);

                        this.MineralData[k] = new Mineral(newMineralId, newMineralName);

                        k += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /**
         * LoadEveSystemData
         * 
         * Loads System data in this.EveSystemData array from specified .dat file (datapath)
         * */
        public void LoadEveSystemData(string datapath)
        {
            try
            {
                this.EveSystemData = new EveSystem[this.GetDataFileLineNumber(datapath)];

                using (StreamReader sr = new StreamReader(datapath))
                {
                    String line; int k = 0;
                    String[] split;
                    String newEveSystemName; int newEveSystemId;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Splitting along " character
                        split = line.Split(new Char[] { '"' });
                        newEveSystemName = split[1];
                        split = split[0].Split(new Char[] { ' ' });
                        newEveSystemId = int.Parse(split[0]);

                        this.EveSystemData[k] = new EveSystem(newEveSystemId, newEveSystemName);

                        k += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /**
         * GetDataFileLineNumber
         * 
         * Computes the number of lines in file specified by path (used to create array of adapted dimension!)
         * */
        private int GetDataFileLineNumber(String path)
        {
            int res = 0;
            try
            {
                res = File.ReadLines(path).Count();
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return res;
        }

        /**
         * AddSystem
         * 
         * Adds considered system to EveSystemData array.
         * */
        public void AddSystem(EveSystem system)
        {
            EveSystem[] tmpArray = new EveSystem[this.EveSystemData.Length+1];
            for (int k=0; k<this.EveSystemData.Length;k++)
            {
                tmpArray[k] = this.EveSystemData[k];
            }
            tmpArray[tmpArray.Length-1] = system;

            this.EveSystemData = tmpArray;
        }

        /**
         * DeleteSystem
         * 
         * Delete a system knowing its index in this.EveSystemData.
         * */
        public void DeleteSystem(int index)
        {
            EveSystem[] tmpArray = new EveSystem[this.EveSystemData.Length - 1];
            for (int k = 0; k < this.EveSystemData.Length; k++)
            {
                if (k < index)
                {
                    tmpArray[k] = this.EveSystemData[k];
                }
                else if (k > index)
                {
                    tmpArray[k-1] = this.EveSystemData[k];
                }
            }

            this.EveSystemData = tmpArray;
        }
    }
}
