using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dEVEOre
{
    public class Mineral
    {
        // Parameters
        private int id;
        private String name;

        private double maxBuyPrice;
        
        // Methods
        public Mineral(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetId() { return this.id; }
        public String GetName() { return this.name; }
    }
}
