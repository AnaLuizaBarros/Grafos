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
            if (vertices.Contains(vertice))
            {

            }
            else vertices.Add(vertice);
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

            for (int j = 1; j < numVertice; j++)
            {
                if (matadj[vertice.Vert, j] > 0)
                {
                    adjacentes.Add(new Vertice(j));

                }
            }

            return adjacentes;
        }

        public int getGrau(Vertice vertice)
        {
            int grau = 0;

            for (int j = 1; j < this.numVertice; j++)
            {

                if (matadj[vertice.Vert, j] == 1)
                {
                    grau++;

                }
            }
            return grau;
        }

        public int visitaDFS(Vertice u, int tempo, int[] cores)
        {


            int branco = 0, cinza = 1, preto = 2;
            Vertice v;
            tempo++;
            tDescoberta[u.Vert] = tempo;
            cores[u.Vert] = cinza;
            componente[u.Vert] = componentes;

            for (int k = 1; k < adjacentes(u).Count; k++)
            {
                v = adjacentes(u)[k];

                if (cores[v.Vert] == branco)
                {
                    pais[v.Vert] = u;
                    tempo = visitaDFS(v, tempo, cores);
                }
                else if (cores[v.Vert] == cinza)
                {
                    ciclo = true;

                }

            }

            cores[u.Vert] = preto;

            tempo++;
            tTermino[u.Vert] = tempo;

            return tempo;
        }

        public Vertice[] buscaEmProfundidade()
        {

            int branco = 0, cinza = 1, preto = 2;
            int[] cores = new int[numVertice];

            int tempo = 0;

            for (int i = 1; i < numVertice; i++)
            {
                cores[i] = branco;
                tDescoberta[i] = -1;
                tTermino[i] = -1;
                pais[i] = new Vertice(-1);
                componente[i] = -1;
            }

            for (int u = 1; u < numVertice; u++)
            {

                if (cores[u] == branco)
                {
                    tempo = visitaDFS(new Vertice(u), tempo, cores);
                    componentes++;
                }
                else if (cores[u] == cinza)
                {

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

                return false;
            }
            else
            {

                return true;
            }
        }

        public bool isPendente(Vertice v)
        {
            int counter = 0;
            for (int i = 1; i < matadj.GetLength(0); ++i) if (matadj[v.Vert, i] == 0) counter++;
            if (counter == 1)
            {
                Console.WriteLine("Pendente");
                return true;
            }
            else
            {
                Console.WriteLine("Não e pendente");
                return false;
            }
        }

        public List<Aresta> arestasPorVertice(Vertice v)
        {
            return arestas.Where(a => a.Vert1.Equals(v) || a.Vert2.Equals(v)).ToList();
        }

        public Aresta menorPeso(List<Aresta> arestas)
        {
            return arestas.Aggregate((min, a) => a.Peso < min.Peso ? a : min);
        }

        public Grafo getAGMPrim()
        {
            List<Vertice> vertices = new List<Vertice>() { this.vertices.First() };
            List<Aresta> usadas = new List<Aresta>();
            Grafo arvore = new Grafo(this.vertices.Count() + 1);
            arvore.adicionarVertice(this.vertices.First());
            while (vertices.Count() < this.vertices.Count())
            {
                List<Aresta> disponiveis = new List<Aresta>();
                foreach (Vertice v in vertices) disponiveis = disponiveis.Concat(arestasPorVertice(v)).ToList();
                disponiveis = disponiveis.Where(a => !usadas.Contains(a)).ToList();
                var menor = menorPeso(disponiveis);
                usadas.Add(menor);
                if (vertices.Contains(menor.Vert1) && vertices.Contains(menor.Vert2)) { }
                else
                {
                    if (vertices.Contains(menor.Vert2))
                    {
                        vertices.Add(menor.Vert1);
                        arvore.adicionarVertice(menor.Vert1);
                        arvore.adicionarAresta(menor.Vert1, menor.Vert2, menor.Peso);
                    }
                    else if (vertices.Contains(menor.Vert1))
                    {
                        vertices.Add(menor.Vert2);
                        arvore.adicionarVertice(menor.Vert2);
                        arvore.adicionarAresta(menor.Vert1, menor.Vert2, menor.Peso);
                    }
                }
            }
            return arvore;
        }

        public void removerAresta(Aresta aresta)
        {
            matadj[aresta.Vert1.Vert, aresta.Vert2.Vert] = 0;
            matadj[aresta.Vert2.Vert, aresta.Vert1.Vert] = 0;
            arestas.Remove(aresta);
        }

        public Grafo getAGMKruskal()
        {
            List<Vertice> vertices = new List<Vertice>();
            Grafo arvore = new Grafo(this.vertices.Count() + 1);
            List<Aresta> usadas = new List<Aresta>();
            List<Aresta> disponiveis = arestas;
            while (vertices.Count() < this.vertices.Count())
            {
                disponiveis = disponiveis.Where(a => !usadas.Contains(a)).ToList();
                var menor = menorPeso(disponiveis);
                usadas.Add(menor);
                arvore.adicionarVertice(menor.Vert1);
                arvore.adicionarVertice(menor.Vert2);
                if (!(vertices.Contains(menor.Vert1) && vertices.Contains(menor.Vert2))) arvore.adicionarAresta(menor.Vert1, menor.Vert2, menor.Peso);
                if (!vertices.Contains(menor.Vert1)) vertices.Add(menor.Vert1);
                if (!vertices.Contains(menor.Vert2)) vertices.Add(menor.Vert2);
            }
            return arvore;
        }
        public int getCutVertices()
        {
            int corte = 0;
            Console.Write("\nVértices:");
            for (int i = 0; i < vertices.Count; i++)
            {
                List<Vertice> lista_V2 = new List<Vertice>();
                List<Aresta> lista_A2 = new List<Aresta>();

                for (int j = 0; j < vertices.Count; j++)
                {
                    if (vertices[j] != vertices[i])
                        lista_V2.Add(vertices[j]);
                }
                for (int k = 0; k < arestas.Count; k++)
                {
                    if (arestas[k].Vert1 != vertices[i] && arestas[k].Vert2 != vertices[i])
                        lista_A2.Add(arestas[k]);
                }
                buscaEmProfundidade();

                int aux = 0;

                for (int p = 1; p < numVertice; p++)
                {
                    aux = componente[p];
                }
                if (aux > 1)
                {
                    Console.Write("\t " + vertices[i].Vert);
                    corte++;
                }


            }
            return corte;
        }
        public bool IsIsolado()
        {
            int cont = 0;
            foreach (Aresta x in arestas)
            {
                if (x.Peso.Equals(0))
                {
                    cont++;
                }
            }

            return _ = cont == 2 ? true : false;
        }

        public bool isNulo()
        {
            int cont = 0;
            foreach (Aresta x in arestas)
            {
                if (x.Peso.Equals(0))
                {
                    cont++;
                }
            }

            return _ = cont < 1 ? true : false;
        }
        public bool isEuleriano()
        {
            int grauPar = 0;
            bool euleriano = false;

            for (int i = 1; i < numVertice; i++)
            {
                var grau = getGrau(new Vertice(i));
                if (grau % 2 == 0)
                {
                    grauPar++;
                }
            }
            if (isConexo() && (grauPar == numVertice))
            {
                euleriano = true;
            }
            return euleriano;
        }
        public bool IsAdjacente(Vertice vert1, Vertice vert2)
        {
            Vertice V1 = vert1;
            Vertice V2 = vert2;
            return true;
        }
        public bool isRegular()
        {
            bool regular = true;
            int grau_1_Vert = this.getGrau(vertices[0]);
            for (int i = 1; i < vertices.Count; i++)
            {
                if (this.getGrau(vertices[i]) != grau_1_Vert)
                {
                    regular = false;
                }
            }
            return regular;
        }

        public bool isCompleto()
        {
            bool completo = true;
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int cont = 0; cont < vertices.Count; cont++)
                {
                    if (cont == i)
                        continue;
                    if (!this.IsAdjacente(vertices[i], vertices[cont]))
                    {
                        completo = false;
                    }
                }
            }
            return completo;
        }

        public bool isUnicursal()
        {
            bool unicursal = false;
            int contImpar = 0;
            bool eureliano = this.isEuleriano();
            if (eureliano)
            {
                for (int i = 1; i < numVertice; i++)
                {
                    var grau = getGrau(new Vertice(i));
                    if (grau % 2 != 0)
                    {
                        contImpar++;
                    }
                }
                if (contImpar == 2)
                {
                    unicursal = true;
                }
            }
            return unicursal;
        }

        public int getGrauEntrada(Vertice v1)
        {
            int entrada = 0;
            foreach (var item in arestas)
            {

                if (item.Direcao == 1 && item.Vert2.Vert == v1.Vert)
                {
                    entrada++;
                }
                if (item.Direcao == -1 && item.Vert1.Vert == v1.Vert)
                {
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
        public bool hasCiclo()
        {
            buscaEmProfundidade();
            return ciclo;
        }

    }
}
