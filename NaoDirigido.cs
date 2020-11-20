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
        public bool isEuleriano() {
            int grauPar = 0;
            bool euleriano = false;

           for (int i = 1; i < numVertice; i++)
            {
               var grau = getGrau(i);
                if (grau % 2 == 0) {
                    grauPar++;
                }            
            }
            if (isConexo() && (grauPar == numVertice)) {
                euleriano = true;
            }
            return euleriano;
        }
    }
}
