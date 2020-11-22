using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Vertice
    {
        private int vert;
        private int grau;

        public Vertice() { }

        public Vertice(int vert, int grau)
        {
            this.vert = vert;
            this.grau = grau;
        }

        public int Grau { get; set; }
        public int Vert { get; set; }
    }
}
