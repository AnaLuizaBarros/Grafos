using System;
using System.IO;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] leitor = File.ReadAllLines(@"../../../Teste.txt");
            Console.WriteLine("\t Alunos: " +
                "\n Ana Luiza Gonçalves Lourenço Barros" +
                "\n Douglas Barbosa da Silva" +
                "\n Jonathan William de Paiva" +
                "\n Lucas Gomes Oliveira" +
                "\n Victor Henrique de Souza Oliveira \n");
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
                        nv.adicionarVertice(Vert1);
                        nv.adicionarVertice(Vert2);
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
                Console.WriteLine(nv.printarMatriz());
                foreach (var item in nv.vertices)
                {
                    Console.WriteLine("O grau do vertice {0} = {1}", item.Vert, nv.getGrau(item));
                    nv.isPendente(item);
                }
                if (nv.IsIsolado()) Console.WriteLine("E isolado");
                else Console.WriteLine("Não e isolado");
         
                if (nv.isRegular()) Console.WriteLine("E regular");
                else Console.WriteLine("Não e regular");
                if (nv.isNulo()) Console.WriteLine("E nulo");
                else Console.WriteLine("Não e nulo");
                if (nv.isCompleto()) Console.WriteLine("E um grafo completo");
                else Console.WriteLine("Não e um grafo completo");
                if (nv.isConexo()) Console.WriteLine("E um grafo Conexo");
                else Console.WriteLine("Não e um grafo Conexo");
                if (nv.isEuleriano()) Console.WriteLine("E euleriano");
                else Console.WriteLine("Não e euleriano");
                if (nv.isUnicursal()) Console.WriteLine("E Unicursal");
                else Console.WriteLine("Não e Unicursal");         
                Grafo arvore = nv.getAGMPrim();
                Grafo arvore2 = nv.getAGMKruskal();
                Console.WriteLine("\n Matriz da prim");
                Console.WriteLine(arvore.printarMatriz());
                Console.WriteLine("Matriz da Kruskal");
                Console.WriteLine(arvore2.printarMatriz());
                nv.getCutVertices();
            }
            else
            {
                Console.WriteLine(nv.printarMatriz());
                foreach (var item in nv.vertices)
                {
                    Console.WriteLine("O grau de entrada do vertice {0} = {1}", item.Vert, nv.getGrauEntrada(item));
                    Console.WriteLine("O grau de saida do vertice {0} = {1}", item.Vert, nv.getGrauSaida(item));
                }
                if (nv.hasCiclo())
                {
                    Console.WriteLine("Este grafo possui ciclo");
                }
                else {
                    Console.WriteLine("Este grafo não possui ciclo");
                }


            }

            Console.ReadKey();

        }

    }
}
