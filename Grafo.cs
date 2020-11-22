using System;
using System.Collections.Generic;
using System.Linq;

namespace Grafos
{
    class Grafo
    {
        public List<Aresta> arestas = new List<Aresta>();
        public List<Vertice> vertices = new List<Vertice>();
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

        public void adicionarVertice(Vertice vertice)
        {
            //int grau = getGrau(vertice);
            //Vertice v = new Vertice(vertice, grau);
            if (!vertices.Contains(vertice)) vertices.Add(vertice);
            //Console.WriteLine("Numero de vertices adicionados :" +vertices.Count);    
        }
        public void adicionarAresta(Vertice Vert1, Vertice Vert2, int peso)
        {
            matadj[Vert1.Vert, Vert2.Vert] = 1;
            matadj[Vert2.Vert, Vert1.Vert] = 1;
            Aresta aresta = new Aresta(Vert1, Vert2, peso);
            arestas.Add(aresta);
            if(arestas2[Vert1.Vert] == null)
            {
                arestas2[Vert1.Vert] = new LinkedList<int>();
            }
            arestas2[Vert1.Vert].AddLast(Vert2.Vert);
        }
        public void adicionarArestaDirigida(Vertice Vert1, Vertice Vert2, int peso, int direcao)
        {
            matadj[Vert1.Vert, Vert2.Vert] = 1;
            matadj[Vert2.Vert, Vert1.Vert] = 1;
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
        public bool isAdjacente(Vertice Vert1, Vertice Vert2)
        {
            for (int i = 1; i < numVertice; i++)
            {
                for (int j = 1; j < numVertice; j++)
                {
                    if (matadj[Vert1.Vert, Vert2.Vert] == 1)
                    {
                        Console.WriteLine("Os vertices {0} e {1} sao adjacentes", Vert1, Vert2);
                        return true;
                    }
                }

            }
            return false;
        }

       
        public List<Vertice> adjacentes(Vertice vertice)
        {
            List<Vertice> adjacentes = new List<Vertice>();
            //Console.WriteLine("Vertices adjacentes a {0}: " ,vertice);

            for (int j = 1; j < numVertice; j++)
            {
                if (matadj[vertice.Vert,j] > 0)
                {
                    adjacentes.Add(new Vertice(j));
                    //Console.WriteLine(j + " ");
                }
            }
            //Console.WriteLine("");

            return adjacentes;
        }
        //Lembrando que e preciso terminar a matriz de adjacencia para fazer o grau
        public int getGrau(Vertice vertice)
        {
            int grau = 0;
           
                for (int j = 1; j < this.numVertice; j++)
                {

                    if (matadj[vertice.Vert, j] == 1)
                    {
                        grau ++;
                        
                    }
                }
            //Console.WriteLine("Grau do vertice {0} e {1} ", vertice, grau);
            
            return grau;
        }
       
        public int visitaDFS(Vertice u, int tempo, int[] cores)
        {
            // ArrayList<Objects> prop = new ArrayList<>();
            int branco = 0, cinza = 1, preto = 2;
            Vertice v;
            tempo++;
            tDescoberta[u.Vert] = tempo;
            cores[u.Vert] = cinza;

            for (int k = 1; k < adjacentes(u).Count; k++)
            {
                v = adjacentes(u)[k];
                //Console.WriteLine(". " + u + " -" + cores[v] + "/");
                if (cores[v.Vert] == branco)
                {
                    pais[v.Vert] = u.Vert;
                    tempo = visitaDFS(v, tempo, cores);
                }
                else if (cores[v.Vert] == cinza)
                {
                    //Console.WriteLine("*Aresta de retorno: (" + u + "," + v + ")");
                }

            }
              //Console.WriteLine("u: " + u+ "/  " );
            cores[u.Vert] = preto;
            //sort = u + sort;
            tempo++;
            tTermino[u.Vert] = tempo;
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
                    tempo = visitaDFS(new Vertice(u), tempo, cores);
                }
                else if (cores[u] == cinza)
                {
                   // Console.WriteLine("Aresta de retorno:" + u);
                }
            }

            return pais;
        }

        public bool isPendente(Vertice v)
        {
            return Array.Exists(pais, p => p == v.Vert);
        }

        public List<Aresta> arestasPorVertice(Vertice v)
        {
            return arestas.Where(a => a.Vert1.Equals(v)).ToList();
        }

        public Aresta menorPeso(List<Aresta> arestas)
        {
            return arestas.Aggregate((min, a) => a.Peso < min.Peso ?  a : min);
        }

        public Arvore getAGMPrim()
        {
            List<Vertice> vertices = new List<Vertice>() { this.vertices.First() };
            Arvore arvore = new Arvore(vertices.First());
            List<Aresta> usadas = new List<Aresta>();
            while (vertices.All(v => this.vertices.Contains(v)))
            {
                List<Aresta> disponiveis = new List<Aresta>();
                foreach (Vertice v in vertices) disponiveis.Concat(arestasPorVertice(v));
                disponiveis = disponiveis.Where(a => !usadas.Contains(a)).ToList();
                var menor = menorPeso(disponiveis);
                usadas.Add(menor);
                vertices.Add(menor.Vert1);
                arvore.inserirFilho(menor.Vert1, menor.Vert2);
            }
            return arvore;
        }
    }
}
