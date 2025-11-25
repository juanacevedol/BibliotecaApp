using System;

namespace BibliotecaApp.Models
{
    public class OperacionLibro
    {
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public OperacionLibro() { }

        public OperacionLibro(int idUsuario, int idLibro, int cantidad, DateTime fecha)
        {
            IdUsuario = idUsuario;
            IdLibro = idLibro;
            Cantidad = cantidad;
            Fecha = fecha;
        }
    }
}
   