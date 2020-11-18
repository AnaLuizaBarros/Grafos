using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Aresta
    {
        private int peso;
        private int vert1;
        private int vert2;

        public Aresta(int vert1, int vert2, int peso)
        {
            this.vert1 = vert1;
            this.vert2 = vert2;
            this.peso = peso;
        }

        public int Vert1 { get; set; }

        public int Vert2 { get; set; }

        public int Peso { get; set; }

    }
}
