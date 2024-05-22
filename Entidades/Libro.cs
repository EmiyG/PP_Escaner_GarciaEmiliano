using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        public string ISBN => NumNormalizado; // Obtengo el ISBN del libro, es igual al numero normalizado.

        public int NumPaginas
        {
            get => this.numPaginas; // Obtiene el numero de paginas del libro.
        }

        /// <summary>
        /// Constructor de la clase Libro.
        /// </summary>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="anio">Anio de publicacion del libro.</param>
        /// <param name="numNormalizado">Numero normalizado del libro (ISBN).</param>
        /// <param name="barcode">Cod de barras del libro.</param>
        /// <param name="numPaginas">Numero de paginas del libro.</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode) // LLamo al constructor de la clase base Documento
        {
            this.numPaginas = numPaginas; // Asigna el N de paginas al campo "numPaginas" del libro
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos libros.
        /// </summary>
        /// <param name="libro1">1er libro a comparar.</param>
        /// <param name="libro2">2do libro a comparar.</param>
        /// <returns>True si los libros son iguales, de lo contrario, false.</returns>
        public static bool operator ==(Libro libro1, Libro libro2)
        {
            // Retorna true si:
            // Los codigos de barras de ambos son iguales, o
            // Los números ISBN de ambos son iguales, o
            // Ambos  tienen el mismo titulo y el mismo autor.
            return libro1.Barcode == libro2.Barcode || libro1.ISBN == libro2.ISBN || (libro1.Titulo == libro2.Titulo && libro1.Autor == libro2.Autor);
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos libros.
        /// </summary>
        /// <param name="libro1">1er libro a comparar.</param>
        /// <param name="libro2">2do libro a comparar.</param>
        /// <returns>True si los libros son diferentes, de lo contrario, false.</returns>
        public static bool operator !=(Libro libro1, Libro libro2)
        {   // Retorna el valor contrario de la comparacion usando ==
            // Retorna true si los libros NO son iguales y false si son iguales.
            return !(libro1 == libro2);
        }

        /// <summary>
        /// Sobrescritura del metodo ToString para representar el libro como una cadena.
        /// </summary>
        /// <returns>Cadena que representa el libro.</returns>
        public override string ToString()
        {
            // Heredo el ToString de documento y lo divido en lineas
            string[] lineasDocumento = base.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            // ISBN antes del Cod. de barras
            foreach (string linea in lineasDocumento) // Recorre cada linea del resultado del ToString() de la clase base
            {
                if (linea.Contains("Cod. de barras:")) // En caso de que la línea contenga "Cód. de barras:", el ISBN va antes de esa línea
                {
                    sb.AppendLine($"ISBN: {ISBN}");
                }
                sb.AppendLine(linea);
            }
            sb.AppendLine($"Numero de paginas: {NumPaginas}."); // Introduzco el N de paginas
            return sb.ToString();
        }
    }

}