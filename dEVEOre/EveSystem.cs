using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dEVEOre
{
    /**
     * EveSystem
     * 
     * A simple class to store basic info on a system that is its id and name.
     * */
    public class EveSystem
    {
        // Parameters
        private int id;         // id (used by EVE API to identify systems)
        private String name;    // name (user-friendly!)

        // Methods
        /**
         * Constructor
         * */
        public EveSystem(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        // (Getters)
        public int GetId() { return this.id; }
        public String GetName() { return this.name; }
    }
}
