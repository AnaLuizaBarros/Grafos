using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    public class Arvore
    {
        private Vertice pai;
        private List<Arvore> filhos;

        public Vertice Raiz { get; }

        public Arvore(Vertice raiz)
        {
            this.Raiz = raiz;
            pai = null;
            filhos = new List<Arvore>();
        }

        public Arvore(Vertice raiz, Vertice pai)
        {
            this.Raiz = raiz;
            this.pai = pai;
            filhos = new List<Arvore>();
        }

        private Arvore inserirFilho(Arvore arvore, Vertice v1, Vertice v2)
        {
            if (v1 == arvore.Raiz) arvore.filhos.Add(new Arvore(v2, arvore.Raiz));
            else foreach (Arvore arvore1 in arvore.filhos) return inserirFilho(arvore1, v1, v2);
            return arvore;
        }

        public Arvore inserirFilho(Vertice v1, Vertice v2)
        {
            return inserirFilho(this, v1, v2);
        }

        public bool isFolha()
        {
            if (filhos.Count == 0) return true;
            else return false;
        }

        private Arvore buscar(Arvore arvore, Vertice dado)
        {
            //revisar
            if (arvore.isFolha()) return null;
            else if (arvore.Raiz.Equals(dado)) return arvore;
            else foreach (Arvore arvore1 in arvore.filhos) return buscar(arvore1, dado);
            return null;
        }

        public Arvore buscar(Vertice dado)
        {
            return buscar(this, dado);
        }
    }
}
