using System.Collections.Generic;
using Npgsql;
using BibliotecaApp.Models;

namespace BibliotecaApp.Services
{
    public class PrestamoService
    {
        private readonly Conexion conexion = new Conexion();

        public List<Prestamo> ObtenerPrestamos()
        {
            var lista = new List<Prestamo>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT id_prestamo, id_usuario, id_libro, cantidad, fecha FROM prestamo ORDER BY id_prestamo;", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Prestamo
                        {
                            IdPrestamo = r.GetInt32(0),
                            IdUsuario = r.GetInt32(1),
                            IdLibro = r.GetInt32(2),
                            Cantidad = r.GetInt32(3),
                            Fecha = r.GetDateTime(4)
                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al obtener préstamos: " + ex.Message);
            }

            return lista;
        }
    }
}
