using System.Collections.Generic;
using Npgsql;
using BibliotecaApp.Models;

namespace BibliotecaApp.Services
{

    public class RecomendacionService
    {
        private readonly Conexion conexion = new Conexion();

      
        public List<Recomendacion> ObtenerRecomendaciones()
        {
            var lista = new List<Recomendacion>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT id_recomendacion, id_usuario, id_libro, fecha FROM recomendacion ORDER BY fecha DESC;", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Recomendacion
                        {
                            IdRecomendacion = r.GetInt32(0),
                            IdUsuario = r.GetInt32(1),
                            IdLibro = r.GetInt32(2),
                            Fecha = r.GetDateTime(3)
                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al obtener recomendaciones: " + ex.Message);
            }

            return lista;
        }


        public List<RecomendacionDetallada> ObtenerRecomendacionesPorUsuario(int idUsuario)
        {
            return Recomendacion.ObtenerPorUsuarioDetallado(idUsuario);
        }

        public List<RecomendacionDetallada> GenerarRecomendaciones(int idUsuario, int cantidad = 10)
        {
            return Recomendacion.GenerarRecomendacionesParaUsuario(idUsuario, cantidad);
        }
    }
}