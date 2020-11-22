using System;
using System.IO;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] leitor = File.ReadAllLines("teste.txt");
            Grafo nv = new Grafo(Convert.ToInt32(leitor[0]) + 1);
            
            foreach (string linha in leitor)
            {
                string[] corte = linha.Split(';');
                if (corte.Length > 3)
                {
                    int Vert1;
                    int Vert2;
                    int peso;
                    int direcao;

                    if (corte.Length == 1)
                    {


                    }
                    else
                    {
                        Vert1 = Convert.ToInt32(corte[0]);
                        Vert2 = Convert.ToInt32(corte[1]);
                        peso = Convert.ToInt32(corte[2]);
                        direcao = Convert.ToInt32(corte[3]);
                        nv.adicionarArestaDirigida(Vert1, Vert2, peso, direcao);
                        
                        
                    }
                }
                else
                {
                    int Vert1;
                    int Vert2;
                    int peso;


                    if (corte.Length == 1)
                    {


                    }
                    else
                    {
                        Vert1 = Convert.ToInt32(corte[0]);
                        Vert2 = Convert.ToInt32(corte[1]);
                        peso = Convert.ToInt32(corte[2]);
                        nv.adicionarVertice(Vert1);
                        nv.adicionarVertice(Vert2);
                        nv.adicionarAresta(Vert1, Vert2, peso);
                        nv.isAdjacente(Vert1, Vert2);                        
                        nv.getGrau(Vert1); // apenas teste
                        nv.getGrau(Vert2);
                        nv.adjacentes(Vert1);
                       
                    }
                }





            }
            foreach (var item in nv.vertices)
            {
                
                Console.WriteLine("O grau do vertice {0} = {1}", item, nv.getGrau(item));
            }
            nv.printarmatriz();
           
            
            


            Console.ReadKey();

        }

    }
}
