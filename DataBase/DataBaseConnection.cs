using Npgsql;
using System;

namespace BibliotecaApp
{
    public class Conexion
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=biblioteca_db";

        public NpgsqlConnection ObtenerConexion()
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }
    }
}
