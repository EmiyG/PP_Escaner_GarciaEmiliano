using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }
        public enum TipoDoc 
        {
            libro,
            mapa
        }

        // Propiedades del escaner
        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos; // Inicializa lista de documentos

        }
        public Departamento Locacion
        {
            get => this.locacion; // Obtien el valor del enum Departamento
        }
        public string Marca
        {
            get => this.marca;
        }
        public TipoDoc Tipo
        {
            get => this.tipo;   // Obtiene valor del enum TipoDoc
        }

        /// <summary>
        /// Constructor de la clase Escaner.
        /// </summary>
        /// <param name="marca">Marca del escaner.</param>
        /// <param name="tipo">Tipo de documento que maneja el escaner.</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            // Asigna la ubicacion dependiendo si es un libro, procesosTecnivos o mapoteca
            this.locacion = tipo == TipoDoc.libro ? Departamento.procesosTecnicos : Departamento.mapoteca;
        }

        /// <summary>
        /// Cambia el estado de un documento al siguiente estado.
        /// </summary>
        /// <param name="d">Documento al que se le va a cambiar el estado.</param>
        /// <returns>True si se pudo cambiar el estado, false si el documento ya termino.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool cambioExitoso = false; // Inicializa la variable que almacena el resultado

            if ((this.tipo == TipoDoc.libro && d is Libro) || (this.tipo == TipoDoc.mapa && d is Mapa))
            {
                foreach (Documento doc in this.listaDocumentos) // Recorre la listaDocumento en el escaner
                {
                    if (this.locacion == Departamento.procesosTecnicos) // Para mapa
                    {
                        if ((Libro)d == (Libro)doc) //Parseo en libro
                        {
                            cambioExitoso = doc.AvanzarEstado(); // Avanza estado y guarda el resultado
                            break; // Si se encuentra sale
                        }
                    }
                    else if (this.locacion == Departamento.mapoteca) // Para mapa
                    {
                        if ((Mapa)d == (Mapa)doc) // Parseo en mapa
                        {
                            cambioExitoso = doc.AvanzarEstado(); // Avanza estado y guarda el resultado
                            break;
                        }
                    }
                }
            }
            return cambioExitoso; // Devuelve el resultado
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para verificar si un documento ya esta en el escáner.
        /// </summary>
        /// <param name="e">Escaner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento esta en el escaner, false en caso contrario.</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool esIgual = false; // Inicializa la variable que almacena el resultado

            if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa)) // Verifica que el tipo de documento sea adecuado para el escaner
            {
                foreach (Documento doc in e.listaDocumentos) // Recorre los objetos de la lista
                {   
                    if (d is Libro && doc is Libro && ((Libro)d == (Libro)doc)) // Si el documento que cargue es de tipo libro y ese libro es igual a un libro existente
                    {
                        esIgual = true;
                    } 
                    else if (d is Mapa && doc is Mapa && ((Mapa)d == (Mapa)doc)) // Si el documento que cargue es de tipo mapa y ese mapa es igual a un mapa existente
                    {
                        esIgual = true;
                    }
                }
            }
            return esIgual;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para verificar si un documento no esta en el escáner.
        /// </summary>
        /// <param name="e">Escaner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento no esta en el escaner, false en caso contrario.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d); // Llama al metodo de arriba
        }

        /// <summary>
        /// Sobrecarga del operador de adicion para agregar un documento al escaner.
        /// </summary>
        /// <param name="e">Escaner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento se agrego correctamente, false en caso contrario.</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool puedeAgregar = false;
            if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa)) // Verifica que los documentos correspondan a tipo libro o tipo mapa 
            {
                if (e != d && d.Estado == Documento.Paso.Inicio)
                {
                    d.AvanzarEstado();
                    e.ListaDocumentos.Add(d);
                    puedeAgregar = true;
                }
            }

            return puedeAgregar;

        }

    }
}