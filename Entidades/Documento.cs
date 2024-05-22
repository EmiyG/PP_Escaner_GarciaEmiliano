using System.Text;

namespace Entidades
{
    public abstract class Documento
    {   // Campos
        int anio; string autor; string barcode; Paso estado; string numNormalizado; string titulo;

        /// <summary>
        /// Constructor: inicializa un nuevo documento con datos especificados.
        /// </summary>
        
        /// <param name="titulo">Titulo del Doc.</param>
        /// <param name="autor">Autor del Doc.</param>
        /// <param name="anio">Anio de publicación.</param>
        /// <param name="numNormalizado">Numero normalizado.</param>
        /// <param name="barcode">Codigo de barras.</param>
        
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        public enum Paso // : Representa los estados de un documento.
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        // Propiedades de solo lectura
        public int Anio
        {
            get => this.anio;
        }
        public string Autor
        {
            get => this.autor;
        }
        public string Barcode
        {
            get => this.barcode;
        }
        public Paso Estado
        {
            get => this.estado;
        }
        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }
        public string Titulo
        {
            get { return this.titulo; }
        }
        /// <summary>
        /// Avanza el estado del documento al siguiente paso del proceso.
        /// </summary>
        
        /// <returns> True si estado fue AVANZO, False si 
        /// el estado era TERMINADO.</returns>
        public bool AvanzarEstado()
        {
            bool retorno = true;
            if (this.estado == Paso.Terminado) // Comprueba si esta "Terminado"
            {   // Si es "Terminado" NO se puede avanzar mas, por lo que retorna false
                retorno = false;
            }
            else
            {   // Si NO es "Terminado" incrementa el estado actual
                this.estado++;
            }
            return retorno;
        }

        /// <summary>
        /// Devuelve una cadena que representa el documento con todos sus datos.
        /// </summary>
        /// <returns>Una cadena que contiene los datos del documento.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Anio}");
            sb.AppendLine($"Cód. de barras: {Barcode}");
            return sb.ToString();
        }
    }
}
