using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3.Clases
{
    public class Libro : Publicacion
    {
        private string autor;

        public Libro(string titulo, float precio, string autor): base(titulo, precio)
        {
            this.Autor = autor;
        }

        public Libro()
        {
        }

        public string Autor { get => autor; set => autor = value; }

        public override string ToString()
        {
            return base.ToString() + " Autor: " + autor;
        }
    }
}
