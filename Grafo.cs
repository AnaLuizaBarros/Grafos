﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Grafo
    {
        public List<Aresta> arestas = new List<Aresta>();
        private int[,] matadj;
        private int numVertice;

        public int NumVertice { get; set; }

        public Grafo(int NumVertice)
        {
            this.numVertice = NumVertice;

            matadj = new int[numVertice, numVertice];

            for (int i = 1; i < numVertice; i++)
                for (int j = 1; j < numVertice; j++)
                    matadj[i, j] = 0;

        }

        public void adicionarAresta(int Vert1, int Vert2, int peso)
        {
            matadj[Vert1, Vert2] = peso;
            matadj[Vert2, Vert1] = peso;
            Aresta aresta = new Aresta(Vert1, Vert2, peso);
            arestas.Add(aresta);
        }
        public void printarmatriz()
        {
            for (int i = 1; i < this.numVertice; i++)
            {
                for (int j = 1; j < this.numVertice; j++)
                {
                    Console.Write(" " + matadj[i, j] + " ");
                }
                Console.WriteLine("\n ");
            }
        }


    }
}