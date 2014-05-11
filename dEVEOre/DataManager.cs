using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace dEVEOre
{
    public class DataManager
    {
        // Parameters
        private Ore[] OreData;
        private Mineral[] MineralData;
        private EveSystem[] EveSystemData;

        // Constants
        private const String ORE_DATAFILE_PATH = "data/ore.dat";
        private const String MINERAL_DATAFILE_PATH = "data/minerals.dat";
        private const String REFINE_DATAFILE_PATH = "data/refine.dat";
        private const String EVESYSTEM_DATAFILE_PATH = "data/systems.dat";

        // Methods
        public Ore[] GetOreData() { return this.OreData; }
        public Mineral[] GetMineralData() { return this.MineralData; }
        public EveSystem[] GetEveSystemData() { return this.EveSystemData; }
        // public void UpdatePrices(int currentSystem) {}

        public String GetXmlRequestString(EveSystem currentSystem)
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

        public DataManager()
        {
            try
            {
                this.LoadOreData(ORE_DATAFILE_PATH);
                this.LoadMineralData(MINERAL_DATAFILE_PATH);
                this.LoadEveSystemData(EVESYSTEM_DATAFILE_PATH);
                this.LoadRefineData(REFINE_DATAFILE_PATH);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
