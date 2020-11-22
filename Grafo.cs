using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class Grafo
    {
        public List<Aresta> arestas = new List<Aresta>();
        public List<int> vertices = new List<int>();
        public LinkedList<int>[] arestas2 = new LinkedList<int>[5];
        private int[,] matadj;
        public int numVertice;
        private int[] tDescoberta;
        private int[] tTermino;
        private int[] pais;
       

        public int NumVertice { get; set; }

        public Grafo()
        {

        }

        public Grafo(int NumVertice)
        {
            this.numVertice = NumVertice;

            matadj = new int[numVertice, numVertice];
            tDescoberta = new int[numVertice];
            tTermino = new int[numVertice];
            pais = new int[numVertice];

            for (int i = 1; i < numVertice; i++)
                for (int j = 1; j < numVertice; j++)
                    matadj[i, j] = 0;

        }

        public void adicionarVertice(int vertice)
        {
            //int grau = getGrau(vertice);
            //Vertice v = new Vertice(vertice, grau);
            if (vertices.Contains(vertice))
            {

            }
            else vertices.Add(vertice);
            
            
            
            //Console.WriteLine("Numero de vertices adicionados :" +vertices.Count);    
        }
        public void adicionarAresta(int Vert1, int Vert2, int peso)
        {
            matadj[Vert1, Vert2] = 1;
            matadj[Vert2, Vert1] = 1;
            Aresta aresta = new Aresta(Vert1, Vert2, peso);
            arestas.Add(aresta);
            if(arestas2[Vert1] == null)
            {
                arestas2[Vert1] = new LinkedList<int>();
            }
            arestas2[Vert1].AddLast(Vert2);
            
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

       
        public List<int> adjacentes(int vertice)
        {
            List<int> adjacentes = new List<int>();
            //Console.WriteLine("Vertices adjacentes a {0}: " ,vertice);

            for (int j = 1; j < numVertice; j++)
            {
                if (matadj[vertice,j] > 0)
                {
                    adjacentes.Add(j);
                    //Console.WriteLine(j + " ");
                }
            }
            //Console.WriteLine("");

            return adjacentes;
        }
        //Lembrando que e preciso terminar a matriz de adjacencia para fazer o grau
        public int getGrau(int vertice)
        {
            int grau = 0;
           
                for (int j = 1; j < this.numVertice; j++)
                {

                    if (matadj[vertice, j] == 1)
                    {
                        grau ++;
                        
                    }
                }
            //Console.WriteLine("Grau do vertice {0} e {1} ", vertice, grau);
            



            return grau;

        }
       
      

        public int visitaDFS(int u, int tempo, int[] cores)
        {
            // ArrayList<Objects> prop = new ArrayList<>();
            int branco = 0, cinza = 1, preto = 2;
            int v;
            tempo++;
            tDescoberta[u] = tempo;
            cores[u] = cinza;

            for (int k = 1; k < adjacentes(u).Count; k++)
            {
                v = adjacentes(u)[k];
                //Console.WriteLine(". " + u + " -" + cores[v] + "/");
                if (cores[v] == branco)
                {
                    pais[v] = u;
                    tempo = visitaDFS(v, tempo, cores);
                }
                else if (cores[v] == cinza)
                {
                    //Console.WriteLine("*Aresta de retorno: (" + u + "," + v + ")");
                }

            }
              //Console.WriteLine("u: " + u+ "/  " );
            cores[u] = preto;
            //sort = u + sort;
            tempo++;
            tTermino[u] = tempo;
            //Console.WriteLine("-------");
            //Console.WriteLine("sort: " + sort);
            return tempo;
        }
       
        public int[] buscaEmProfundidade()
        {
            int branco = 0, cinza = 1, preto = 2;
            int[] cores = new int[numVertice];
            //inicializacoes
            int tempo = 0;
            //Console.WriteLine(tDescoberta.Length);
            for (int i = 1; i < numVertice; i++)
            {
                cores[i] = branco;
                tDescoberta[i] = -1;
                tTermino[i] = -1;
                pais[i] = -1;
            }
            //para cada vertice visita em profundidade os vizinhos nao visitados
            for (int u = 1; u < numVertice; u++)
            {
                //Console.WriteLine("u " + u + "esta cor " + cores[u]);
                if (cores[u] == branco)
                {
                    tempo = visitaDFS(u, tempo, cores);
                }
                else if (cores[u] == cinza)
                {
                   // Console.WriteLine("Aresta de retorno:" + u);
                }
            }

            return pais;
        }
    }
}
