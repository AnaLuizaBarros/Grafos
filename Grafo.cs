using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafos
{
    class Grafo
    {
        public List<Aresta> arestas = new List<Aresta>();
        public List<Vertice> vertices = new List<Vertice>();
       
        private int[,] matadj;
        public int numVertice;
        private int[] tDescoberta;
        private int[] tTermino;
        private Vertice[] pais;
        private int[] componente;
        private int componentes;
        private bool ciclo;
       

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
            pais = new Vertice[numVertice];
            componente = new int[numVertice];


            for (int i = 1; i < numVertice; i++)
                for (int j = 1; j < numVertice; j++)
                    matadj[i, j] = 0;

        }

        public void adicionarVertice(Vertice vertice)
        {
            //int grau = getGrau(vertice);
            //Vertice v = new Vertice(vertice, grau);
            if (vertices.Contains(vertice))
            {

            }
            else vertices.Add(vertice);
            
            
            
            //Console.WriteLine("Numero de vertices adicionados :" +vertices.Count);    
        }
        public void adicionarAresta(Vertice Vert1, Vertice Vert2, int peso)
        {
            matadj[Vert1.Vert, Vert2.Vert] = 1;
            matadj[Vert2.Vert, Vert1.Vert] = 1;
            Aresta aresta = new Aresta(Vert1, Vert2, peso);
            arestas.Add(aresta);
            
            
        }
        public void adicionarArestaDirigida(Vertice Vert1, Vertice Vert2, int peso, int direcao)
        {
            matadj[Vert1.Vert, Vert2.Vert] = 1;
            matadj[Vert2.Vert, Vert1.Vert] = 1;
            Aresta aresta = new Aresta(Vert1, Vert2, peso, direcao);
            arestas.Add(aresta);
            
          
        }
        public string printarMatriz()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nMatriz de adjacencia ");
            for (int i = 1; i < this.numVertice; i++)
            {
                for (int j = 1; j < this.numVertice; j++)
                {
                    sb.Append(" " + matadj[i, j] + " ");
                }
                sb.AppendLine("\n ");
            }
            return sb.ToString();
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
                        Console.WriteLine("Os vertices {0} e {1} sao adjacentes", Vert1.Vert, Vert2.Vert);
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

        public void acharcutpoint()
        {

        }

        public int visitaDFS(Vertice u, int tempo, int[] cores)
        {
  
            // ArrayList<Objects> prop = new ArrayList<>();
            int branco = 0, cinza = 1, preto = 2;
            Vertice v;
            tempo++;
            tDescoberta[u.Vert] = tempo;
            cores[u.Vert] = cinza;
            componente[u.Vert] = componentes;
           
            for (int k = 1; k < adjacentes(u).Count; k++)
            {
                v = adjacentes(u)[k];
                //Console.WriteLine(". " + u + " -" + cores[v] + "/");
                if (cores[v.Vert] == branco)
                {
                    pais[v.Vert] = u;
                    tempo = visitaDFS(v, tempo, cores);
                }
                else if (cores[v.Vert] == cinza)
                {
                    ciclo = true;
                    //Console.WriteLine("*Aresta de retorno: (" + u.Vert + "," + v.Vert + ")");
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
       
        public Vertice[] buscaEmProfundidade()
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
                pais[i] = new Vertice(-1);
                componente[i] = -1;
            }
            componentes = 1;
            //para cada vertice visita em profundidade os vizinhos nao visitados
            for (int u = 1; u < numVertice; u++)
            {
                //Console.WriteLine("u " + u + "esta cor " + cores[u]);
                if (cores[u] == branco)
                {
                    tempo = visitaDFS(new Vertice(u), tempo, cores);
                    componentes++;
                }
                else if (cores[u] == cinza)
                {
                   // Console.WriteLine("Aresta de retorno:" + u);
                }
            }

            return pais;
        }
        
        public bool isConexo()
        {
            int aux = 0;
            buscaEmProfundidade();
            for (int i = 1; i < numVertice; i++)
            {
                aux = componente[i];
            }
            if (aux > 1)
            {
                Console.WriteLine("\nO grafo nao e conexo");
                return false;
            }
            else
            {
                Console.WriteLine("\nO grafo e conexo");
                return true;
            }
        }

        public bool isPendente(Vertice v)
        {
            return Array.Exists(pais, p => p.Equals(v));
        }

        public List<Aresta> arestasPorVertice(Vertice v)
        {
            return arestas.Where(a => a.Vert1.Equals(v)).ToList();
        }

        public Aresta menorPeso(List<Aresta> arestas)
        {
            return arestas.Aggregate((min, a) => a.Peso < min.Peso ? a : min);
        }

        public Grafo getAGMPrim()
        {
            List<Vertice> vertices = new List<Vertice>() { this.vertices.First() };
            List<Aresta> usadas = new List<Aresta>();
            Grafo arvore = new Grafo(this.vertices.Count()+1);
            arvore.adicionarVertice(this.vertices.First());
            while (this.vertices.Intersect(vertices).Count() < this.vertices.Count())
            {
                List<Aresta> disponiveis = new List<Aresta>();
                foreach (Vertice v in vertices) disponiveis = disponiveis.Concat(arestasPorVertice(v)).ToList();
                disponiveis = disponiveis.Where(a => !usadas.Contains(a)).ToList();
                var menor = menorPeso(disponiveis);
                usadas.Add(menor);
                vertices.Add(menor.Vert2);
                arvore.adicionarVertice(menor.Vert2);
                arvore.adicionarAresta(menor.Vert1, menor.Vert2, menor.Peso);
            }
            return arvore;
        }

        public Grafo getAGMKruskal()
        {
            List<Vertice> vertices = new List<Vertice>();
            Grafo arvore = new Grafo(this.vertices.Count() + 1);
            List<Aresta> usadas = new List<Aresta>();
            List<Aresta> disponiveis = this.arestas;
            while (this.vertices.Intersect(vertices).Count() < this.vertices.Count())
            {
                disponiveis = disponiveis.Where(a => !usadas.Contains(a)).ToList();
                var menor = menorPeso(disponiveis);
                usadas.Add(menor);
                vertices.Add(menor.Vert1);
                vertices.Add(menor.Vert2);
                arvore.adicionarVertice(menor.Vert1);
                arvore.adicionarVertice(menor.Vert2);
                arvore.adicionarAresta(menor.Vert1, menor.Vert2, menor.Peso);
            }
            return arvore;
        }

        /*public void tarjan()
        {
            int cont = 0;
            int tempo;
            int branco = 0, cinza = 1, preto = 2;
            int[] cores = new int[numVertice];
            for (int i = 1; i < numVertice; i++)
            {
                ponto[i] = false;
                cores[i] = branco;
            }
            for (int i = 1; i < numVertice; i++)
            {
                for (int j = 1; j < numVertice; j++)
                {
                    ponte[i, j] = false;
                }
            }
            for (int i = 1; i < numVertice; i++)
            {
                if(cores[i] == branco)
                {
                    cont = 0;
                    visitaTarjan();
                }
                if( cont >= 2)
                {
                    ponto[i] = true;
                }
                else
                {
                    ponto[i] = false;
                }
            }
        }
        public void visitaTarjan()
        {
                
        }*/
        public int getCutVertices()
        {
            return 0;
        }



        public int getGrauEntrada(Vertice v1) {
            int entrada = 0;
            foreach (var item in arestas)
            {
           
                if ( item.Direcao == 1 && item.Vert2.Vert == v1.Vert) {
                    entrada++;
                }
                if (item.Direcao == -1 && item.Vert1.Vert == v1.Vert) {
                    entrada++;
                }
                
            }
            return entrada;
        }
        public int getGrauSaida(Vertice v1)
        {
            int saida = 0;
            foreach (var item in arestas)
            {
                if (item.Direcao == 1 && item.Vert1.Vert == v1.Vert)
                {
                    saida++;
                }
                if (item.Direcao == -1 && item.Vert2.Vert == v1.Vert)
                {
                    saida++;
                }

            }
            return saida;
        }
        public bool hasCiclo() {
            buscaEmProfundidade();
            return ciclo;
        }
    }
}
