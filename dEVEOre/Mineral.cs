using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dEVEOre
{
    class Mineral
    {
        // Parameters
        private int id;
        private String name;
        private int id5pcnt; // 5% yield
        private int id10pcnt; // 10% yield

        // Methods
        public Mineral(int id, String name, int id5pcnt, int id10pcnt)
        {
            this.id = id;
            this.name = name;
            this.id5pcnt = id5pcnt;
            this.id10pcnt = id10pcnt;
        }
    }
}
