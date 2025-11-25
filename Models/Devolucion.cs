using System;
using System.Collections.Generic;
using Npgsql;

namespace BibliotecaApp.Models
{
    public class Devolucion : OperacionLibro
    {
        public int IdDevolucion { get; set; }
        public int IdPrestamo { get; set; }

        public Devolucion() { }

        public Devolucion(int idDevolucion, int idPrestamo, int idUsuario, int idLibro, int cantidad, DateTime fecha)
            : base(idUsuario, idLibro, cantidad, fecha)
        {
            IdDevolucion = idDevolucion;
            IdPrestamo = idPrestamo;
        }

        public static int ObtenerCantidadDevuelta(int idPrestamo)
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT COALESCE(SUM(cantidad),0) FROM devolucion WHERE id_prestamo = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPrestamo);
                        var result = cmd.ExecuteScalar();
                        return result == null ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cantidad devuelta: " + ex.Message);
            }
        }

      
        public static int ObtenerPendiente(int idPrestamo, int cantidadPrestada)
        {
            try
            {
                int devuelto = ObtenerCantidadDevuelta(idPrestamo);
                int pendiente = cantidadPrestada - devuelto;
                return pendiente < 0 ? 0 : pendiente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular pendiente: " + ex.Message);
            }
        }

        public bool EsDevolucionValida(int cantidadPendiente)
        {
            if (Cantidad <= 0) return false;
            if (Cantidad > cantidadPendiente) return false;
            return true;
        }

        public bool RealizarDevolucion()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                using (var tran = conn.BeginTransaction())
                {
                    if (IdDevolucion == 0)
                        IdDevolucion = GenerarNuevoId();

                    string insert = @"INSERT INTO devolucion
                                      (id_devolucion, id_prestamo, id_usuario, id_libro, cantidad, fecha)
                                      VALUES (@id, @idPrestamo, @idUsuario, @idLibro, @cantidad, @fecha)";

                    using (var cmd = new NpgsqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", IdDevolucion);
                        cmd.Parameters.AddWithValue("@idPrestamo", IdPrestamo);
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@idLibro", IdLibro);
                        cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                        cmd.Parameters.AddWithValue("@fecha", Fecha);
                        cmd.ExecuteNonQuery();
                    }

                    string update = "UPDATE libro SET cantidad = cantidad + @cant WHERE id_libro = @idLibro";
                    using (var cmd = new NpgsqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@cant", Cantidad);
                        cmd.Parameters.AddWithValue("@idLibro", IdLibro);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la devolución: " + ex.Message);
            }
        }

        public static int GenerarNuevoId()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string q = "SELECT COALESCE(MAX(id_devolucion),0)+1 FROM devolucion";
                    using (var cmd = new NpgsqlCommand(q, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        return result == null ? 1 : Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar ID de devolución: " + ex.Message);
            }
        }

        public static List<Devolucion> ObtenerTodas()
        {
            var devoluciones = new List<Devolucion>();
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_devolucion, id_prestamo, id_usuario, id_libro, cantidad, fecha FROM devolucion ORDER BY id_devolucion";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            devoluciones.Add(new Devolucion
                            {
                                IdDevolucion = reader.GetInt32(0),
                                IdPrestamo = reader.GetInt32(1),
                                IdUsuario = reader.GetInt32(2),
                                IdLibro = reader.GetInt32(3),
                                Cantidad = reader.GetInt32(4),
                                Fecha = reader.GetDateTime(5)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener devoluciones: " + ex.Message);
            }
            return devoluciones;
        }
    }
}
