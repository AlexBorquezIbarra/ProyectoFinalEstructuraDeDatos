using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalEstructuraDeDatos
{
    class Elemento
    {
        public string Titulo { get; set; }
        public string Año { get; set; }
        public string Genero { get; set; }
        public string Temporada { get; set; }
        public string Productor { get; set; }
        public string Descripcion { get; set; }
        public string Rating { get; set; }

        public Elemento(string titulo, string año, string genero, string temporada, string productor, string descripcion, string rating)
        {
            this.Titulo = titulo;
            this.Año = año;
            this.Genero = genero;
            this.Temporada = temporada;
            this.Productor = productor;
            this.Descripcion = descripcion;
            this.Rating = rating;
        }

        public override string ToString()
        {
            return this.Titulo + this.Año;
        }
    }
}
