using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dEVEOre
{
    public class Ore
    {
        // Parameters
        private int     id;
        private String  name;

        private int baseOreId;
        private double percentIncreasedYield;

        private double volumePerUnit;

        private double maxBuyPrice;

        // Methods
        public Ore(int id, String name, int baseOreId, double percentIncreasedYield, double volumePerUnit)
        {
            this.id = id;
            this.name = name;
            this.baseOreId = baseOreId;
            this.percentIncreasedYield = percentIncreasedYield;
            this.maxBuyPrice = 0;
            this.volumePerUnit = volumePerUnit;
        }

        public void SetMaxBuyPrice(double price)
        {
            this.maxBuyPrice = price;
        }

        public String GetName() { return this.name; }
        public int GetId() { return this.id; }
        public int GetBaseOreId() { return this.baseOreId; }
        public double GetPercentIncreasedYield() { return this.percentIncreasedYield; }
        public double GetMaxBuyPrice() { return this.maxBuyPrice; }
        public double GetVolumePerUnit() { return this.volumePerUnit; }
    }
}
