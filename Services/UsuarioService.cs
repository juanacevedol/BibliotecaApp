using System.Collections.Generic;
using Npgsql;
using BibliotecaApp.Models;

namespace BibliotecaApp.Services
{
    public class UsuarioService
    {
        private readonly Conexion conexion = new Conexion();

        public List<Usuario> ObtenerUsuarios()
        {
            var lista = new List<Usuario>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT id_usuario, username, password, rol FROM usuario ORDER BY id_usuario;", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = r.GetInt32(0),
                            Username = r.GetString(1),
                            Password = r.GetString(2),
                            Rol = r.GetString(3)
                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al obtener usuarios: " + ex.Message);
            }

            return lista;
        }
    }
}
