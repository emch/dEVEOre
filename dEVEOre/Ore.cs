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

        // max price in considered system?

        // Methods
        public Ore(int id, String name, int baseOreId, double percentIncreasedYield)
        {
            this.id = id;
            this.name = name;
            this.baseOreId = baseOreId;
            this.percentIncreasedYield = percentIncreasedYield;
        }

        public String GetName() { return this.name; }
        public int GetId() { return this.id; }
        public int GetBaseOreId() { return this.baseOreId; }
        public double GetPercentIncreasedYield() { return this.percentIncreasedYield; }
    }
}
