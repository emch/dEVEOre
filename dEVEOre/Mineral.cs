using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dEVEOre
{
    /**
     * Mineral
     * 
     * In EVE, Mineral is produced by refining Ore.
     * This class stores basic info about a Mineral as well as its max buy price (updated by DataManager instance).
     * */
    public class Mineral
    {
        // Parameters
        private int id;             // id (in EVE, all objects, like systems, have an id)
        private String name;        // name (still, user-friendly!)

        private double maxBuyPrice; // max buy order on the market
        
        // Methods
        /**
         * Constructor
         * */
        public Mineral(int id, String name)
        {
            this.id = id;
            this.name = name;
            this.maxBuyPrice = 0;
        }

        // (Setter, to be used when updating price from DataManager instance)
        public void SetMaxBuyPrice(double price)
        {
            this.maxBuyPrice = price;
        }

        // (Getters)
        public int GetId() { return this.id; }
        public String GetName() { return this.name; }
        public double GetMaxBuyPrice() { return this.maxBuyPrice; }
    }
}
