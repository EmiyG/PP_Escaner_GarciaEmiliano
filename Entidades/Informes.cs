using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{
    public static class Informes
    {
        /// <summary>
        /// Muestra los documentos por un estado especfico en el escaner.
        /// </summary>
        /// <param name="e">Escaner.</param>
        /// <param name="estado">Estado de los documentos a mostrar.</param>
        /// <param name="extension">Extension procesada.</param>
        /// <param name="cantidad">Cantidad de items unicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los items.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {  
            var documentos = e.ListaDocumentos.Where(d => d.Estado == estado).ToList(); // Filtra los documentos del escaner segun el estado especificado y los convierte en una lista
            // Suma de las extensiones de los documentos
            // Para libros, suma el numero de páginas.
            // Para mapas, suma la superficie 
            extension = documentos.OfType<Libro>().Sum(l => l.NumPaginas) + documentos.OfType<Mapa>().Sum(m => m.Superficie);
            cantidad = documentos.Count; // Cuenta el numero total de documentos en el estado especificado
            var sb = new StringBuilder(); 
            foreach (var doc in documentos)  // Recorre cada documento en la lista y agrega su representacion en cadena al StringBuilder
            {
                sb.AppendLine(doc.ToString());
            }
            resumen = sb.ToString(); // Convierte el StringBuilder en una cadena y la asigna al parametro de salida "resumen"
        }


        /// <summary>
        /// Muestra los documentos distribuidos en el escaner.
        /// </summary>
        /// <param name="e">Escaner.</param>
        /// <param name="extension">Extension procesada total.</param>
        /// <param name="cantidad">Items unicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los Items.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {  
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos en el escaner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="extension">Extensión procesada total.</param>
        /// <param name="cantidad">Items unicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los Items.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos terminados en el escaner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="extension">Extensión procesada total.</param>
        /// <param name="cantidad">Items unicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los Items.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }

    }
}
