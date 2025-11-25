using System;
using System.Collections.Generic;
using Npgsql;

namespace BibliotecaApp.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Sinopsis { get; set; }
        public byte[] Portada { get; set; }

        public string Disponibilidad => Cantidad > 0 ? "Disponible" : "No Disponible";

        public Libro() { }

        public Libro(int idLibro, string nombre, string genero, string estado,
                     int cantidad, DateTime fechaPublicacion, string sinopsis, byte[] portada)
        {
            IdLibro = idLibro;
            Nombre = nombre;
            Genero = genero;
            Estado = estado;
            Cantidad = cantidad;
            FechaPublicacion = fechaPublicacion;
            Sinopsis = sinopsis;
            Portada = portada;
        }

        public static List<Libro> ObtenerTodos()
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis FROM libro ORDER BY id_libro";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libros.Add(new Libro
                            {
                                IdLibro = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Genero = reader.GetString(2),
                                Estado = reader.GetString(3),
                                Cantidad = reader.GetInt32(4),
                                FechaPublicacion = reader.GetDateTime(5),
                                Sinopsis = reader.IsDBNull(6) ? "" : reader.GetString(6)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener libros: " + ex.Message);
            }

            return libros;
        }

        public static int GenerarNuevoId()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT COALESCE(MAX(id_libro), 0) + 1 FROM libro";

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
                    if (this.IdLibro == 0)
                    {
                        this.IdLibro = GenerarNuevoId();
                    }

                    string queryExiste = "SELECT COUNT(*) FROM libro WHERE id_libro = @id";
                    using (var cmdExiste = new NpgsqlCommand(queryExiste, conn))
                    {
                        cmdExiste.Parameters.AddWithValue("@id", this.IdLibro);
                        int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

                        string query;
                        if (existe > 0)
                        {
                            query = "UPDATE libro SET nombre = @nombre, genero = @genero, estado = @estado, cantidad = @cantidad, fecha_publicacion = @fecha, sinopsis = @sinopsis WHERE id_libro = @id";
                        }
                        else
                        {
                            query = "INSERT INTO libro (id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis) VALUES (@id, @nombre, @genero, @estado, @cantidad, @fecha, @sinopsis)";
                        }

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", this.IdLibro);
                            cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                            cmd.Parameters.AddWithValue("@genero", this.Genero);
                            cmd.Parameters.AddWithValue("@estado", this.Estado);
                            cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
                            cmd.Parameters.AddWithValue("@fecha", this.FechaPublicacion);
                            cmd.Parameters.AddWithValue("@sinopsis", this.Sinopsis ?? "");

                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar libro: " + ex.Message);
            }
        }

        public bool Eliminar()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM libro WHERE id_libro = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.IdLibro);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar libro: " + ex.Message);
            }
        }

        public static Libro BuscarPorId(int id)
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis FROM libro WHERE id_libro = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Libro
                                {
                                    IdLibro = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Genero = reader.GetString(2),
                                    Estado = reader.GetString(3),
                                    Cantidad = reader.GetInt32(4),
                                    FechaPublicacion = reader.GetDateTime(5),
                                    Sinopsis = reader.IsDBNull(6) ? "" : reader.GetString(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar libro: " + ex.Message);
            }

            return null;
        }

        public static List<Libro> BuscarPorNombre(string nombre)
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis FROM libro WHERE LOWER(nombre) LIKE LOWER(@nombre) ORDER BY nombre";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                libros.Add(new Libro
                                {
                                    IdLibro = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Genero = reader.GetString(2),
                                    Estado = reader.GetString(3),
                                    Cantidad = reader.GetInt32(4),
                                    FechaPublicacion = reader.GetDateTime(5),
                                    Sinopsis = reader.IsDBNull(6) ? "" : reader.GetString(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar libros: " + ex.Message);
            }

            return libros;
        }

        public static List<Libro> FiltrarPorGenero(string genero)
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis FROM libro WHERE LOWER(genero) = LOWER(@genero) ORDER BY nombre";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@genero", genero);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                libros.Add(new Libro
                                {
                                    IdLibro = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Genero = reader.GetString(2),
                                    Estado = reader.GetString(3),
                                    Cantidad = reader.GetInt32(4),
                                    FechaPublicacion = reader.GetDateTime(5),
                                    Sinopsis = reader.IsDBNull(6) ? "" : reader.GetString(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar libros: " + ex.Message);
            }

            return libros;
        }

        public static List<Libro> ObtenerDisponibles()
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis FROM libro WHERE cantidad > 0 ORDER BY nombre";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libros.Add(new Libro
                            {
                                IdLibro = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Genero = reader.GetString(2),
                                Estado = reader.GetString(3),
                                Cantidad = reader.GetInt32(4),
                                FechaPublicacion = reader.GetDateTime(5),
                                Sinopsis = reader.IsDBNull(6) ? "" : reader.GetString(6)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener libros disponibles: " + ex.Message);
            }

            return libros;
        }

        public static List<Libro> BuscarConFiltros(string busqueda = "", string genero = "", string estado = "")
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis FROM libro WHERE 1=1";

                 
                    if (!string.IsNullOrWhiteSpace(busqueda))
                    {
                        query += " AND LOWER(nombre) LIKE LOWER(@busqueda)";
                    }

                    if (!string.IsNullOrWhiteSpace(genero) && genero != "Todos")
                    {
                        query += " AND LOWER(genero) = LOWER(@genero)";
                    }

                    if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
                    {
                        if (estado == "Disponible")
                            query += " AND cantidad > 0";
                        else if (estado == "No Disponible")
                            query += " AND cantidad = 0";
                    }

                    query += " ORDER BY nombre";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(busqueda))
                            cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                        if (!string.IsNullOrWhiteSpace(genero) && genero != "Todos")
                            cmd.Parameters.AddWithValue("@genero", genero);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                libros.Add(new Libro
                                {
                                    IdLibro = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Genero = reader.GetString(2),
                                    Estado = reader.GetString(3),
                                    Cantidad = reader.GetInt32(4),
                                    FechaPublicacion = reader.GetDateTime(5),
                                    Sinopsis = reader.IsDBNull(6) ? "" : reader.GetString(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar con filtros: " + ex.Message);
            }

            return libros;
        }

        public static List<string> ObtenerGeneros()
        {
            List<string> generos = new List<string> { "Todos" };

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT DISTINCT genero FROM libro WHERE genero IS NOT NULL AND genero != '' ORDER BY genero";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            generos.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener géneros: " + ex.Message);
            }

            return generos;
        }

        public static List<string> ObtenerEstados()
        {
            List<string> estados = new List<string> { "Todos", "Disponible", "No Disponible" };
            return estados;
        }

        public bool EstaDisponible()
        {
            return this.Cantidad > 0;
        }

        public override string ToString()
        {
            return "[" + IdLibro + "] " + Nombre + " (" + Genero + ") - Disponibles: " + Cantidad;
        }
    }
}