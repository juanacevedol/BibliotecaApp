using System;
using System.Collections.Generic;
using Npgsql;

namespace BibliotecaApp.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public Usuario() { }

        public Usuario(int idUsuario, string username, string password, string rol)
        {
            IdUsuario = idUsuario;
            Username = username;
            Password = password;
            Rol = rol;
        }

        public static Usuario ValidarCredenciales(string username, string password)
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_usuario, username, password, rol FROM usuario WHERE LOWER(username) = LOWER(@username) AND password = @password";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    IdUsuario = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Rol = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar credenciales: " + ex.Message);
            }

            return null;
        }

        public static List<Usuario> ObtenerTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_usuario, username, password, rol FROM usuario ORDER BY id_usuario";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                IdUsuario = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Rol = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }

            return usuarios;
        }

        public static int GenerarNuevoId()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT COALESCE(MAX(id_usuario), 0) + 1 FROM usuario";

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

        public static bool ExisteUsername(string username)
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT COUNT(*) FROM usuario WHERE LOWER(username) = LOWER(@username)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar username: " + ex.Message);
            }
        }

        public bool Guardar()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    if (this.IdUsuario == 0)
                    {
                        this.IdUsuario = GenerarNuevoId();
                    }

                    string queryExiste = "SELECT COUNT(*) FROM usuario WHERE id_usuario = @id";
                    using (var cmdExiste = new NpgsqlCommand(queryExiste, conn))
                    {
                        cmdExiste.Parameters.AddWithValue("@id", this.IdUsuario);
                        int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

                        string query;
                        if (existe > 0)
                        {
                            query = "UPDATE usuario SET username = @username, password = @password, rol = @rol WHERE id_usuario = @id";
                        }
                        else
                        {
                            query = "INSERT INTO usuario (id_usuario, username, password, rol) VALUES (@id, @username, @password, @rol)";
                        }

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", this.IdUsuario);
                            cmd.Parameters.AddWithValue("@username", this.Username);
                            cmd.Parameters.AddWithValue("@password", this.Password);
                            cmd.Parameters.AddWithValue("@rol", this.Rol);

                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar usuario: " + ex.Message);
            }
        }

        public bool Eliminar()
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM usuario WHERE id_usuario = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.IdUsuario);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar usuario: " + ex.Message);
            }
        }

        public static Usuario BuscarPorId(int id)
        {
            try
            {
                var conexion = new Conexion();
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = "SELECT id_usuario, username, password, rol FROM usuario WHERE id_usuario = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    IdUsuario = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Rol = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuario: " + ex.Message);
            }

            return null;
        }

        public bool EsAdmin()
        {
            return this.Rol.Equals("administrador", StringComparison.OrdinalIgnoreCase);
        }

        public bool EsLector()
        {
            return this.Rol.Equals("lector", StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return "[" + IdUsuario + "] " + Username + " - " + Rol;
        }
    }
}