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
    public class DataManager
    {
        // Parameters
        private Ore[] OreData;
        private Mineral[] MineralData;
        private EveSystem[] EveSystemData;
        private RefineTable RefineData;
        private DataTable profitData;

        private XmlDocument ApiXmlData;
        private XmlNamespaceManager ApiXmlDataNS;

        // Constants
        private const String ORE_DATAFILE_PATH = "data/ore.dat";
        private const String MINERAL_DATAFILE_PATH = "data/minerals.dat";
        private const String REFINE_DATAFILE_PATH = "data/refine.dat";
        private const String EVESYSTEM_DATAFILE_PATH = "data/systems.dat";

        // Methods
        public Ore[] GetOreData() { return this.OreData; }
        public Mineral[] GetMineralData() { return this.MineralData; }
        public EveSystem[] GetEveSystemData() { return this.EveSystemData; }

        public XmlDocument GetApiXmlData() { return this.ApiXmlData; }
        public XmlNamespaceManager GetApiXmlDataNamespaceManager() { return this.ApiXmlDataNS; }
        public DataTable GetProfitDataTable() { return this.profitData; }

        /**
         * 
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
         * */
        public DataManager()
        {
            try
            {
                this.LoadOreData(ORE_DATAFILE_PATH);
                this.LoadMineralData(MINERAL_DATAFILE_PATH);
                this.LoadEveSystemData(EVESYSTEM_DATAFILE_PATH);
                this.LoadRefineData(REFINE_DATAFILE_PATH);
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

        public void UpdatePrices(EveSystem currentSystem)
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

        public void UpdateXmlData(EveSystem currentSystem)
        {
            String requestString = this.GetXmlRequestString(currentSystem);

            this.ApiXmlData.Load(requestString);
            this.ApiXmlDataNS = new XmlNamespaceManager(this.GetApiXmlData().NameTable);
        }

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

        private void LoadOreData(String datapath)
        {
            try
            {
                this.OreData = new Ore[this.GetDataFileLineNumber(datapath)];

                using (StreamReader sr = new StreamReader(datapath))
                {
                    String line; int k = 0;
                    String[] split;
                    String newOreName; int newOreId; int newOreBaseOreId; double newOrePercentIncreasedYield; double newOreVolumePerUnit;
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

                        this.OreData[k] = new Ore(newOreId,
                            newOreName,
                            newOreBaseOreId,
                            newOrePercentIncreasedYield,
                            newOreVolumePerUnit);

                        k += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        private void LoadEveSystemData(string datapath)
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

        private void LoadRefineData(String datapath)
        {

        }

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
    }
}
