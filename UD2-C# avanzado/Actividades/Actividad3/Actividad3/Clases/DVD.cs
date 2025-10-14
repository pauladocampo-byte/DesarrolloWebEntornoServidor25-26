using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3.Clases
{
    internal class DVD : Publicacion
    {
        protected float duracion;

        public DVD(string titulo, float precio, float duracion) : base(titulo, precio)
        {
            this.Duracion = duracion;
        }

        public DVD()
        {
        }
        protected float Duracion { get => duracion; set => duracion = value; }

        public override string ToString()
        {
            return base.ToString() + " Duracion: " + duracion;
        }

    }
}
