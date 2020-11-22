using System;
using System.IO;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] leitor = File.ReadAllLines(@"../../../Teste.txt");
            Grafo nv = new Grafo(Convert.ToInt32(leitor[0]) + 1);
            bool naodirigido = true;
            foreach (string linha in leitor)
            {
                string[] corte = linha.Split(';');
                if (corte.Length > 3)
                {
                    Vertice Vert1;
                    Vertice Vert2;
                    int peso;
                    int direcao;

                    if (corte.Length == 1)
                    {


                    }
                    else
                    {
                        naodirigido = false;
                        Vert1 = new Vertice(Convert.ToInt32(corte[0]));
                        Vert2 = new Vertice(Convert.ToInt32(corte[1]));
                        peso = Convert.ToInt32(corte[2]);
                        direcao = Convert.ToInt32(corte[3]);
                        nv.adicionarArestaDirigida(Vert1, Vert2, peso, direcao);
                    }
                }
                else
                {
                    Vertice Vert1;
                    Vertice Vert2;
                    int peso;


                    if (corte.Length == 1)
                    {


                    }
                    else
                    {
                        Vert1 = new Vertice(Convert.ToInt32(corte[0]));
                        Vert2 = new Vertice(Convert.ToInt32(corte[1]));
                        peso = Convert.ToInt32(corte[2]);
                        nv.adicionarVertice(Vert1);
                        nv.adicionarVertice(Vert2);
                        nv.adicionarAresta(Vert1, Vert2, peso);
                        nv.isAdjacente(Vert1, Vert2);                        
                        nv.getGrau(Vert1); 
                        nv.getGrau(Vert2);
                        nv.adjacentes(Vert1);
                       
                    }
                }
            }
            if (naodirigido)
            {
                foreach (var item in nv.vertices)
                {
                    Console.WriteLine("O grau do vertice {0} = {1}", item.Vert, nv.getGrau(item));
                }
                nv.isConexo();
                Console.WriteLine(nv.printarMatriz());
                Grafo arvore = nv.getAGMPrim();
                Grafo arvore2 = nv.getAGMKruskal();
                Console.WriteLine(arvore.printarMatriz());
                Console.WriteLine(arvore2.printarMatriz());
            }
            else
            {
                Console.WriteLine(nv.printarMatriz());
            }

            Console.ReadKey();

        }

    }
}
