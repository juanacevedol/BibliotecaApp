using System;
using System.Collections.Generic;
using Npgsql;

namespace BibliotecaApp.Models
{
    public class Recomendacion
    {
        #region Propiedades
        public int IdRecomendacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public DateTime Fecha { get; set; }

        public Recomendacion()
        {
            Fecha = DateTime.Now;
        }

        public Recomendacion(int idRecomendacion, int idUsuario, int idLibro, DateTime fecha)
        {
            IdRecomendacion = idRecomendacion;
            IdUsuario = idUsuario;
            IdLibro = idLibro;
            Fecha = fecha;
        }

        public static List<RecomendacionDetallada> ObtenerPorUsuarioDetallado(int idUsuario)
        {
            List<RecomendacionDetallada> recomendaciones = new List<RecomendacionDetallada>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = @"
                        SELECT 
                            r.id_recomendacion,
                            r.id_usuario,
                            r.id_libro,
                            l.nombre AS nombre_libro,
                            l.genero,
                            l.estado,
                            l.cantidad,
                            r.fecha
                        FROM recomendacion r
                        INNER JOIN libro l ON r.id_libro = l.id_libro
                        WHERE r.id_usuario = @idUsuario
                        ORDER BY r.fecha DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recomendaciones.Add(new RecomendacionDetallada
                                {
                                    IdRecomendacion = reader.GetInt32(0),
                                    IdUsuario = reader.GetInt32(1),
                                    IdLibro = reader.GetInt32(2),
                                    NombreLibro = reader.GetString(3),
                                    Genero = reader.GetString(4),
                                    Estado = reader.GetString(5),
                                    CantidadDisponible = reader.GetInt32(6),
                                    Fecha = reader.GetDateTime(7)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener recomendaciones del usuario: " + ex.Message);
            }

            return recomendaciones;
        }


        public static List<RecomendacionDetallada> GenerarRecomendacionesParaUsuario(int idUsuario, int cantidad = 10)
        {
            List<RecomendacionDetallada> recomendaciones = new List<RecomendacionDetallada>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    
                    string queryGeneros = @"
                        SELECT l.genero, COUNT(*) as total
                        FROM prestamo p
                        INNER JOIN libro l ON p.id_libro = l.id_libro
                        WHERE p.id_usuario = @idUsuario
                        GROUP BY l.genero
                        ORDER BY total DESC
                        LIMIT 3";

                    List<string> generosFavoritos = new List<string>();
                    using (var cmd = new NpgsqlCommand(queryGeneros, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                generosFavoritos.Add(reader.GetString(0));
                            }
                        }
                    }

                   
                    if (generosFavoritos.Count > 0)
                    {
                        string generosCondicion = string.Join(" OR ", generosFavoritos.ConvertAll(g => $"l.genero = '{g}'"));

                        string queryRecomendaciones = $@"
                            SELECT
                                l.id_libro,
                                l.nombre,
                                l.genero,
                                l.estado,
                                l.cantidad
                            FROM libro l
                            WHERE ({generosCondicion})
                            AND l.cantidad > 0
                            AND l.id_libro NOT IN (
                                SELECT id_libro 
                                FROM prestamo 
                                WHERE id_usuario = @idUsuario
                            )
                            ORDER BY RANDOM()
                            LIMIT @cantidad";

                        using (var cmd = new NpgsqlCommand(queryRecomendaciones, conn))
                        {
                            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmd.Parameters.AddWithValue("@cantidad", cantidad);

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    recomendaciones.Add(new RecomendacionDetallada
                                    {
                                        IdUsuario = idUsuario,
                                        IdLibro = reader.GetInt32(0),
                                        NombreLibro = reader.GetString(1),
                                        Genero = reader.GetString(2),
                                        Estado = reader.GetString(3),
                                        CantidadDisponible = reader.GetInt32(4),
                                        Fecha = DateTime.Now,
                                        RazonRecomendacion = $"Basado en tu interés en {reader.GetString(2)}"
                                    });
                                }
                            }
                        }
                    }

                    if (recomendaciones.Count < cantidad)
                    {
                        int faltantes = cantidad - recomendaciones.Count;

                        string queryPopulares = @"
                            SELECT 
                                l.id_libro,
                                l.nombre,
                                l.genero,
                                l.estado,
                                l.cantidad,
                                COUNT(p.id_prestamo) as popularidad
                            FROM libro l
                            LEFT JOIN prestamo p ON l.id_libro = p.id_libro
                            WHERE l.cantidad > 0
                            AND l.id_libro NOT IN (
                                SELECT id_libro 
                                FROM prestamo 
                                WHERE id_usuario = @idUsuario
                            )
                            GROUP BY l.id_libro, l.nombre, l.genero, l.estado, l.cantidad
                            ORDER BY popularidad DESC
                            LIMIT @faltantes";

                        using (var cmd = new NpgsqlCommand(queryPopulares, conn))
                        {
                            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmd.Parameters.AddWithValue("@faltantes", faltantes);

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    recomendaciones.Add(new RecomendacionDetallada
                                    {
                                        IdUsuario = idUsuario,
                                        IdLibro = reader.GetInt32(0),
                                        NombreLibro = reader.GetString(1),
                                        Genero = reader.GetString(2),
                                        Estado = reader.GetString(3),
                                        CantidadDisponible = reader.GetInt32(4),
                                        Fecha = DateTime.Now,
                                        RazonRecomendacion = "Popular entre otros lectores"
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar recomendaciones: " + ex.Message);
            }

            return recomendaciones;
        }


        public static int GenerarNuevoId()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT COALESCE(MAX(id_recomendacion), 0) + 1 FROM recomendacion";
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

        public static bool ExisteRecomendacion(int idUsuario, int idLibro)
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = @"SELECT COUNT(*) 
                                    FROM recomendacion 
                                    WHERE id_usuario = @idUsuario 
                                    AND id_libro = @idLibro";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@idLibro", idLibro);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar recomendación: " + ex.Message);
            }
        }

        public bool Guardar()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    if (IdRecomendacion == 0)
                    {
                        IdRecomendacion = GenerarNuevoId();
                    }

                    if (ExisteRecomendacion(IdUsuario, IdLibro))
                    {
                        return false;
                    }

                    string query = @"INSERT INTO recomendacion 
                                    (id_recomendacion, id_usuario, id_libro, fecha) 
                                    VALUES (@id, @idUsuario, @idLibro, @fecha)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", IdRecomendacion);
                        cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@idLibro", IdLibro);
                        cmd.Parameters.AddWithValue("@fecha", Fecha);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar recomendación: " + ex.Message);
            }
        }

        public override string ToString()
        {
            return $"[{IdRecomendacion}] Libro {IdLibro} recomendado a Usuario {IdUsuario}";
        }

        #endregion
    }

    public class RecomendacionDetallada
    {
        public int IdRecomendacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public int CantidadDisponible { get; set; }
        public DateTime Fecha { get; set; }
        public string RazonRecomendacion { get; set; }

        public string Disponibilidad => CantidadDisponible > 0 ? "✓ Disponible" : "✗ No Disponible";
    }
}
