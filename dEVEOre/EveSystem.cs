using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dEVEOre
{
    public class EveSystem
    {
        // Parameters
        private int id;
        private String name;

        // Methods
        public EveSystem(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetId() { return this.id; }
        public String GetName() { return this.name; }
    }
}
