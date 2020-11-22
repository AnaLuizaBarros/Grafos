using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    public class Vertice
    {
        private int vert;
        private int grau;

        public Vertice() { }

        public Vertice(int vert, int grau)
        {
            this.vert = vert;
            this.grau = grau;
        }
        public Vertice(int vert)
        {
            this.vert = vert;
        }

        public int Grau { get; set; }
        public int Vert { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj as Vertice).Vert == this.vert && (obj as Vertice).Grau == this.grau) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(vert, grau);
        }
    }
}
