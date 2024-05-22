using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        int alto;
        int ancho;

        public int Alto
        {
            get => this.alto; // Obtiene la Altura
        }

        public int Ancho
        {
            get => this.ancho; // Obtiene el Ancho
        }

        public int Superficie => Alto * Ancho; // Obtiene la superficie del mapa.

        /// <summary>
        /// Constructor de la clase Mapa.
        /// </summary>
        /// <param name="titulo">Titulo del mapa.</param>
        /// <param name="autor">Autor del mapa.</param>
        /// <param name="anio">Anio de publicacion del mapa.</param>
        /// <param name="barcode">Codigo de barras del mapa.</param>
        /// <param name="ancho">Ancho del mapa.</param>
        /// <param name="alto">Alto del mapa.</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode, int ancho, int alto)
            : base(titulo, autor, anio, "", barcode) 
        {   
            this.ancho = ancho; // Asigna el valor del parametro ancho a la propiedad ancho del objeto Mapa
            this.alto = alto; // Asigna el valor del parametro alto a la propiedad alto del objeto Mapa
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos mapas.
        /// </summary>
        /// <param name="m1">1er mapa.</param>
        /// <param name="m2">2do mapa.</param>
        /// <returns>True si los mapas son iguales, de lo contrario, false.</returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {   
            return m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
            // Verifica que los codigos de barras, los titulos, los autores, los años y las superficies sean iguaales
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos mapas.
        /// </summary>
        /// <param name="m1">1er mapa.</param>
        /// <param name="m2">2do mapa.</param>
        /// <returns>True si los mapas son diferentes, de lo contrario, false.</returns>
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2); // Retorna la negacion del resultado de la comparacion de igualldad
        }

        /// <summary>
        /// Sobrescritura del método ToString permite convertir el mapa en una cadena de texto que contiene informacion sobre sus elementos.
        /// </summary>
        /// <returns>Cadena que representa el mapa.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Superficie: {Ancho} * {Alto}  =  {Superficie} cm2.");
            return sb.ToString();
        }
    }
}