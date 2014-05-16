using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dEVEOre
{
    /**
     * Ore
     * 
     * In EVE, Mineral is mined in Asteroid belts. Minerals are obtained by refining Ore.
     * This class stores basic info about a type of Ore as well as its max buy price (updated by DataManager instance).
     * */
    public class Ore
    {
        // Parameters
        private int     id;                     // id (use should become clear)
        private String  name;                   // name

        private int baseOreId;                  // for a given Ore, more concentrated types exist. This is used to store the "base" Ore from which refine yields are deduced.s
        private double percentIncreasedYield;   // percentage of increase in Ore yield for more concentrated types (0% for base Ore)

        private double volumePerUnit;           // volume (in m3) of a given unit of Ore. Mining lasers attributes are given in m3 of Ore mined per cycle.

        private double maxBuyPrice;             // max buy order on the market

        private double security;                // sector's max security where you can find this ore
        private bool isSelected;                // true if Ore is selected to appear in tabs/requests/...

        // Methods
        /**
         * Constructor
         * */
        public Ore(int id, String name, int baseOreId, double percentIncreasedYield, double volumePerUnit, double security, bool selected)
        {
            this.id = id;
            this.name = name;
            this.baseOreId = baseOreId;
            this.percentIncreasedYield = percentIncreasedYield;
            this.maxBuyPrice = 0;
            this.volumePerUnit = volumePerUnit;
            this.security = security;
            this.isSelected = selected;
        }

        // (Setter, see Mineral.cs)
        public void SetMaxBuyPrice(double price)
        {
            this.maxBuyPrice = price;
        }

        // (Getters)
        public String GetName() { return this.name; }
        public int GetId() { return this.id; }
        public int GetBaseOreId() { return this.baseOreId; }
        public double GetPercentIncreasedYield() { return this.percentIncreasedYield; }
        public double GetMaxBuyPrice() { return this.maxBuyPrice; }
        public double GetVolumePerUnit() { return this.volumePerUnit; }
    }
}
