using System;
using System.Collections.Generic;
using Npgsql;

namespace BibliotecaApp.Models
{
    public class Prestamo : OperacionLibro
    {
        public int IdPrestamo { get; set; }

        public Prestamo() { }

        public Prestamo(int idPrestamo, int idUsuario, int idLibro, int cantidad, DateTime fecha)
            : base(idUsuario, idLibro, cantidad, fecha)
        {
            IdPrestamo = idPrestamo;
        }


        public static List<PrestamoDetallado> ObtenerTodosDetallados()
        {
            List<PrestamoDetallado> prestamos = new List<PrestamoDetallado>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = @"SELECT p.id_prestamo, p.id_usuario, u.username, p.id_libro, l.nombre, 
                                     p.cantidad, p.fecha 
                                     FROM prestamo p 
                                     INNER JOIN usuario u ON p.id_usuario = u.id_usuario 
                                     INNER JOIN libro l ON p.id_libro = l.id_libro 
                                     ORDER BY p.fecha DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prestamos.Add(new PrestamoDetallado
                            {
                                IdPrestamo = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1),
                                NombreUsuario = reader.GetString(2),
                                IdLibro = reader.GetInt32(3),
                                NombreLibro = reader.GetString(4),
                                Cantidad = reader.GetInt32(5),
                                Fecha = reader.GetDateTime(6)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener préstamos detallados: " + ex.Message);
            }

            return prestamos;
        }

        public static int GenerarNuevoId()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT COALESCE(MAX(id_prestamo), 0) + 1 FROM prestamo";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar ID: " + ex.Message);
            }
        }

        public bool Guardar()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    if (this.IdPrestamo == 0)
                    {
                        this.IdPrestamo = GenerarNuevoId();
                    }

                    string query = "INSERT INTO prestamo (id_prestamo, id_usuario, id_libro, cantidad, fecha) VALUES (@id, @idUsuario, @idLibro, @cantidad, @fecha)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.IdPrestamo);
                        cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                        cmd.Parameters.AddWithValue("@idLibro", this.IdLibro);
                        cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
                        cmd.Parameters.AddWithValue("@fecha", this.Fecha);

                        cmd.ExecuteNonQuery();

                        ActualizarCantidadLibro();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar préstamo: " + ex.Message);
            }
        }
      

        private void ActualizarCantidadLibro()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "UPDATE libro SET cantidad = cantidad - @cantidad WHERE id_libro = @idLibro";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
                        cmd.Parameters.AddWithValue("@idLibro", this.IdLibro);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cantidad del libro: " + ex.Message);
            }
        }

        public static List<PrestamoDetallado> ObtenerPorUsuarioDetallado(int idUsuario)
        {
            List<PrestamoDetallado> prestamos = new List<PrestamoDetallado>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = @"SELECT p.id_prestamo, p.id_usuario, u.username, p.id_libro, l.nombre, 
                                     p.cantidad, p.fecha 
                                     FROM prestamo p 
                                     INNER JOIN usuario u ON p.id_usuario = u.id_usuario 
                                     INNER JOIN libro l ON p.id_libro = l.id_libro 
                                     WHERE p.id_usuario = @idUsuario 
                                     ORDER BY p.fecha DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                prestamos.Add(new PrestamoDetallado
                                {
                                    IdPrestamo = reader.GetInt32(0),
                                    IdUsuario = reader.GetInt32(1),
                                    NombreUsuario = reader.GetString(2),
                                    IdLibro = reader.GetInt32(3),
                                    NombreLibro = reader.GetString(4),
                                    Cantidad = reader.GetInt32(5),
                                    Fecha = reader.GetDateTime(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener préstamos del usuario: " + ex.Message);
            }

            return prestamos;
        }

        public static Prestamo BuscarPorId(int id)
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_prestamo, id_usuario, id_libro, cantidad, fecha FROM prestamo WHERE id_prestamo = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Prestamo
                                {
                                    IdPrestamo = reader.GetInt32(0),
                                    IdUsuario = reader.GetInt32(1),
                                    IdLibro = reader.GetInt32(2),
                                    Cantidad = reader.GetInt32(3),
                                    Fecha = reader.GetDateTime(4)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar préstamo: " + ex.Message);
            }

            return null;
        }

        public override string ToString()
        {
            return "[" + IdPrestamo + "] Usuario: " + IdUsuario + " - Libro: " + IdLibro + " - Cantidad: " + Cantidad;
        }
    }



    // ==================== CLASE PARA VISUALIZACIÓN ====================
    public class PrestamoDetallado
    {
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
