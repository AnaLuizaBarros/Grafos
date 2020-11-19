using System;
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

        public Grafo()
        {

        }

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
            matadj[Vert1, Vert2] = 1;
            matadj[Vert2, Vert1] = 1;
            Aresta aresta = new Aresta(Vert1, Vert2, peso);

            arestas.Add(aresta);

        }
        public void adicionarArestaDirigida(int Vert1, int Vert2, int peso, int direcao)
        {
            matadj[Vert1, Vert2] = 1;
            matadj[Vert2, Vert1] = 1;
            Aresta aresta = new Aresta(Vert1, Vert2, peso, direcao);
            arestas.Add(aresta);
        }
        public void printarmatriz()
        {
            Console.WriteLine("\nMatriz de adjacencia ");
            for (int i = 1; i < this.numVertice; i++)
            {
                for (int j = 1; j < this.numVertice; j++)
                {
                    Console.Write(" " + matadj[i, j] + " ");
                }
                Console.WriteLine("\n ");
            }
        }

        public List<Aresta> GetArestas()
        {
            return this.arestas;
        }
        public bool isAdjacente(int Vert1, int Vert2)
        {
            for (int i = 1; i < numVertice; i++)
            {
                for (int j = 1; j < numVertice; j++)
                {
                    if (matadj[Vert1, Vert2] == 1)
                    {
                        Console.WriteLine("Os vertices {0} e {1} sao adjacentes", Vert1, Vert2);
                        return true;
                    }
                }

            }
            return false;
        }

        //Lembrando que e preciso terminar a matriz de adjacencia para fazer o grau
        public int getGrau(int Vert1)
        {
            int grau = 0;      
                for (int j = 1; j < this.numVertice; j++)
                {
                    if (matadj[Vert1, j] == 1)
                    {
                       grau++;
                    }
                }
            
            Console.WriteLine("Grau do vertice {0} e {1} ", Vert1, grau);
            return grau;

        }
    }
}
