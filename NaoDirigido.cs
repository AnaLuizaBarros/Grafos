using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class NaoDirigido : Grafo
    {


        /*
      
   
        //Dado a definição "Vértices com grau 0 são chamados isolados", compreendemos aqui que caso o peso da aresta seja 
        //grau 0 ou nulo, ele é um grafo isolado.
        public bool IsIsolado()
        {
            int cont = 0;
            foreach (Aresta x in grafo.lista)
            {
                if (x.Peso.Equals(0))
                {
                    cont++;
                }
            }

            return _ = cont == 2 ? true : false;
        }

        //Dado o conceito "Grafos que possuem somente vértices isolados são chamados de grafos nulos", aqui percorremos todas as arestas
        //que foram passadas no program principal e verificamos se foram passadas como 0, caso o resultado seja positivo, o retorno é true.
        public bool isNulo()
        {
            int cont = 0;
            foreach (Aresta x in grafo.lista)
            {
                if (x.Peso.Equals(0))
                {
                    cont++;
                }
            }

            return _ = cont < 1  ? true : false;
        }

     
    */
        public bool isConexo()
        {
            return true;
            //Em implementação
        }

        //Grafo euleriano precisa ser conexo e ter os vertices grau par
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

        // Um grafo regular é um grafo onde cada vértice tem o mesmo número de adjacências
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

        // Um grafo completo é um grafo simples em que todo vértice é adjacente a todos os outros vértices
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

        // Um grafo é dito unicursal ou semi-euleriano se ele possui pelo menos um trajeto euleriano aberto
        // Um Grafo é Unicursal se e somente se ele possuir exatamente 2 vértices de grau ímpar
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
    }
}
