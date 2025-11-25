using System;
using System.Collections.Generic;
using Npgsql;
using BibliotecaApp.Models;

namespace BibliotecaApp.Services
{
    public class LibroService
    {
        private readonly Conexion conexion;

        public LibroService()
        {
            conexion = new Conexion();
        }

        public List<Libro> ObtenerLibros()
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = @"SELECT id_libro, nombre, genero, estado, cantidad, fecha_publicacion, sinopsis 
                                     FROM libro;";
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
                Console.WriteLine("Error al obtener libros: " + ex.Message);
            }

            return libros;
        }
    }
}
