using Entidades;
using static Entidades.Escaner;


namespace Test
{
    class Consola
    {
        static void Main(string[] args)
        {
            int extension;
            int cantidad;
            string resumen;

            // Cambio de nombres de los libros
            Libro l1 = new Libro("Nueva Era", "David Johnson", 2021, "212-a", "9781087703237", 425);
            Libro l2 = new Libro("El Negocio del Siglo XXI", "Sarah Smith", 2022, "234-2", "9789877253146", 411);
            Libro l3 = new Libro("Crecimiento Personal", "Jessica Adams", 2007, "23-23", "9780881130720", 321);
            Libro l4 = new Libro("La Aventura del Saber", "Richard Johnson", 2007, "234-533", "9789978809525", 360);

            // Creación de los mapas
            Mapa m1 = new Mapa("Mapa del Mundo", "John Doe", 2010, "", "2384-2834", 42, 10);
            Mapa m2 = new Mapa("Mapa de Europa", "Jane Smith", 2000, "", "3245-5334", 50, 40);
            Mapa m3 = new Mapa("Mapa de América", "Robert Brown", 1995, "", "8092-5689", 50, 85);
            Mapa m4 = new Mapa("Mapa de Asia", "Emily White", 2018, "", "2382-2852", 89, 100);

            // Creación de los escáneres
            Escaner eLibros = new Escaner("Exo", Escaner.TipoDoc.libro);
            Escaner eMapas = new Escaner("Samsung", Escaner.TipoDoc.mapa);

            // Colocamos directamente el libro en distribución 
            Libro l5 = new Libro("El Principito", "Antoine de Saint-Exupéry", 1997, "8923-2859", "9780789915504", 341);
            l5.AvanzarEstado();//estado distribuido
            Libro l6 = new Libro("1984", "George Orwell", 1989, "3784-2348", "9780829752298", 528);
            l6.AvanzarEstado();
            l6.AvanzarEstado();//estado revision

            // Muestra de verificación
            Console.WriteLine(eMapas + l1);
            Console.WriteLine(eLibros + l1);
            Console.WriteLine();

            // Muestra de carga en escáner de libros
            Console.WriteLine("CARGA EN ESCANER EXO LIBROS");
            Console.WriteLine("Carga de Libros en el scaner de libros");
            Console.WriteLine(eLibros + l1);
            Console.WriteLine(eLibros + l2);
            Console.WriteLine(eLibros + l3);
            Console.WriteLine(eLibros + l4);
            Console.WriteLine(eLibros + l5);// false, el estado no esta en INICIO
            Console.WriteLine(eLibros + l6);// false, el estado no esta en INICIO
            Console.WriteLine();

            // Cambio de estado de documentos en escáner de libros
            eLibros.CambiarEstadoDocumento(l1);
            eLibros.CambiarEstadoDocumento(l2);
            eLibros.CambiarEstadoDocumento(l2);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);

            // Muestra de informes de los documentos distribuidos en escáner de libros
            Console.WriteLine("DISTRIBUIDOS EN ESCANER DE LIBROS");
            Informes.MostrarDistribuidos(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine($"Cantidad de páginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            // Muestra de informes de los documentos en escáner de libros
            Console.WriteLine("DOCUMENTOS EN ESCANER DE LIBROS");
            Informes.MostrarEnEscaner(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine($"Cantidad de páginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            // Muestra de informes de los documentos en revisión en escáner de libros
            Console.WriteLine("DOCUMENTOS EN REVISIÓN EN ESCANER DE LIBROS");
            Informes.MostrarEnRevision(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine($"Cantidad de páginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            // Muestra de informes de los documentos terminados en escáner de libros
            Console.WriteLine("DOCUMENTOS TERMINADOS EN ESCANER DE LIBROS");
            Informes.MostrarTerminados(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine($"Cantidad de páginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            /////////////////////////////////////////////////////////////

            // Muestra de carga en escáner de mapas
            Console.WriteLine("CARGA EN ESCANER SAMSUNG MAPAS");
            Console.WriteLine("Carga de Mapas en el scaner de mapas");
            Console.WriteLine(eMapas + m1);
            Console.WriteLine(eMapas + m2);
            Console.WriteLine(eMapas + m3);
            Console.WriteLine(eMapas + m4);
            Console.WriteLine();

            // Cambio de estado de documentos en escáner de mapa
            eMapas.CambiarEstadoDocumento(m1);
            eMapas.CambiarEstadoDocumento(m2);
            eMapas.CambiarEstadoDocumento(m2);
            eMapas.CambiarEstadoDocumento(m3);
            eMapas.CambiarEstadoDocumento(m3);
            eMapas.CambiarEstadoDocumento(m3);
            eMapas.CambiarEstadoDocumento(m3);
            eMapas.CambiarEstadoDocumento(m3);

            // Muestra de informes de los documentos distribuidos en escáner de mapas
            Console.WriteLine("DISTRIBUIDOS EN ESCANER DE MAPAS");
            Informes.MostrarDistribuidos(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine($"Total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            // Muestra de informes de los documentos en escáner de mapas
            Console.WriteLine("DOCUMENTOS EN ESCANER DE MAPAS");
            Informes.MostrarEnEscaner(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine($"Total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            // Muestra de informes de los documentos en revisión en escáner de mapas
            Console.WriteLine("DOCUMENTOS EN REVISIÓN EN ESCANER DE MAPAS");
            Informes.MostrarEnRevision(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine($"Total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            // Muestra de informes de los documentos terminados en escáner de mapas
            Console.WriteLine("DOCUMENTOS TERMINADOS EN ESCANER DE MAPAS");
            Informes.MostrarTerminados(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine($"Total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            Console.ReadKey();

        }
    }

}

