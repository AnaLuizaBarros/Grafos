using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Aresta
    {
        private int peso;
        private Vertice vert1;
        private Vertice vert2;
        private int direcao;

        public Aresta(Vertice vert1, Vertice vert2, int peso)
        {
            this.vert1 = vert1;
            this.vert2 = vert2;
            this.peso = peso;
        }

        public Aresta(Vertice vert1, Vertice vert2, int peso, int direcao)
        {
            this.vert1 = vert1;
            this.vert2 = vert2;
            this.peso = peso;
            this.direcao = direcao;
        }

        public Vertice Vert1 { get; set; }

        public Vertice Vert2 { get; set; }

        public int Peso { get; set; }

        public int Direcao { get; set; }
    }
}
