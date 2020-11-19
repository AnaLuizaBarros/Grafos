using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Adjacentes
    {
        private int vert1;
        private int vert2;

        public Adjacentes(int vert1, int vert2)
        {
            this.vert1 = vert1;
            this.vert2 = vert2;
        }

        public int Vert1 { get; set; }
        public int Vert2 { get; set; }

    }
}
