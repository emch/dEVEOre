using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace dEVEOre
{
    // create new class RefineCouple ?
    // public int GetRefinedMineralFromOre(int oreid, int mineralid)
    public class RefineTable
    {
        // Parameters
        private int[,] refineTable;

        // Methods
        public RefineTable(int oreNb, int mineralNb, String path)
        {
            this.refineTable = new int[oreNb, mineralNb+2];
            this.LoadRefineTable(path);
        }

        public int GetBatch(Ore ore)
        {
            return this.refineTable[this.GetOreRowNb(ore), 1];
        }

        public int GetBatch(int oreId)
        {
            return this.refineTable[this.GetOreRowNb(oreId), 1];
        }

        public int GetRefineQty(Ore ore, Mineral mineral)
        {
            return this.refineTable[this.GetOreRowNb(ore), this.GetMineralColumnNb(mineral)];
        }

        public int GetRefineQty(int oreId, Mineral mineral)
        {
            return this.refineTable[this.GetOreRowNb(oreId), this.GetMineralColumnNb(mineral)];
        }

        private int GetOreRowNb(int oreId)
        {

            for (int k = 0; k < this.refineTable.GetLength(0); k++) // number of rows
            {
                if (this.refineTable[k, 0] == oreId)
                {
                    return k;
                }
            }
            return -666;
        }

        private int GetOreRowNb(Ore ore)
        {

            for (int k = 0; k < this.refineTable.GetLength(0); k++) // number of rows
            {
                if (this.refineTable[k, 0] == ore.GetId())
                {
                    return k;
                }
            }
            return -666;
        }

        // improve
        private int GetMineralColumnNb(Mineral mineral)
        {
            switch (mineral.GetId())
            {
                case (int)MineralTypesIds.Tritanium:
                    return 2;
                    break;
                case (int)MineralTypesIds.Pyerite: // Pyerite
                    return 3;
                    break;
                case (int)MineralTypesIds.Mexallon: // Mexallon
                    return 4;
                    break;
                case (int)MineralTypesIds.Isogen: // Isogen
                    return 5;
                    break;
                case (int)MineralTypesIds.Noxcium: // Nocxium
                    return 6;
                    break;
                case (int)MineralTypesIds.Megacyte: // Megacyte
                    return 7;
                    break;
                case (int)MineralTypesIds.Zydrine: // Zydrine
                    return 8;
                    break;
                case (int)MineralTypesIds.Morphite: // Morphite
                    return 9;
                    break;
                default:
                    return -666;
                    break;
            }

        }

        private void LoadRefineTable(String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line; int lineNb = 0;
                    String[] split;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Splitting along space character
                        split = line.Split(new Char[] { ' ' });
                        
                        // 
                        for (int k = 0; k < split.Length; k++)
                        {
                            this.refineTable[lineNb, k] = int.Parse(split[k]);
                        }

                        lineNb += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public enum MineralTypesIds
    {
        Tritanium = 34,
        Pyerite = 35,
        Mexallon = 36,
        Isogen = 37,
        Noxcium = 38,
        Megacyte = 40,
        Zydrine = 39,
        Morphite = 11399
    }
}
