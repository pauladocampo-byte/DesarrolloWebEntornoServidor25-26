using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3.Clases
{
    public class Publicacion
    {
        protected string titulo;
        protected float precio;

        public Publicacion(string titulo, float precio)
        {
            this.Titulo = titulo;
            this.Precio = precio;
        }

        public Publicacion()
        {
        }

        protected string Titulo { get => titulo; set => titulo = value; }
        protected float Precio { get => precio; set => precio = value; }

        public override string ToString()
        {
            return $"Titulo: {this.titulo}, Precio: {this.precio}";
        }

    }
}
