    using System.Collections.Generic;
    using Npgsql;
    using BibliotecaApp.Models;

    namespace BibliotecaApp.Services
    {
        public class DevolucionService
        {
            private readonly Conexion conexion = new Conexion();

            public List<Devolucion> ObtenerDevoluciones()
            {
                var lista = new List<Devolucion>();

                try
                {
                    using (var conn = conexion.ObtenerConexion())
                    using (var cmd = new NpgsqlCommand("SELECT id_devolucion, id_prestamo, id_usuario, id_libro, cantidad, fecha FROM devolucion ORDER BY id_devolucion;", conn))
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            lista.Add(new Devolucion
                            {
                                IdDevolucion = r.GetInt32(0),
                                IdPrestamo = r.GetInt32(1),
                                IdUsuario = r.GetInt32(2),
                                IdLibro = r.GetInt32(3),
                                Cantidad = r.GetInt32(4),
                                Fecha = r.GetDateTime(5)
                            });
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error al obtener devoluciones: " + ex.Message);
                }

                return lista;
            }
        }
    }
