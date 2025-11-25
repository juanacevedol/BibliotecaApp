using System;
using System.Collections.Generic;
using Npgsql;
using BibliotecaApp.Models;
using System.Windows.Forms;

namespace BibliotecaApp.Services
{
    public class LogProcesoService
    {
        private readonly Conexion _conexion = new Conexion();

        // Guardar un log en base de datos
        public void RegistrarLog(LogProceso log)
        {
            try
            {
                using var conn = _conexion.ObtenerConexion();
                string query = @"
                    INSERT INTO log_procesos
                    (id_log, username, id_usuario, nombre_libro, id_libro, fecha_prestamo, fecha_devolucion, id_prestamo, id_devolucion, accion)
                    VALUES
                    ((SELECT COALESCE(MAX(id_log),0)+1 FROM log_procesos),
                     @username,@idUsuario,@nombreLibro,@idLibro,@fechaPrestamo,@fechaDevolucion,@idPrestamo,@idDevolucion,@accion)";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", log.Username ?? "");
                cmd.Parameters.AddWithValue("@idUsuario", log.IdUsuario);
                cmd.Parameters.AddWithValue("@nombreLibro", log.NombreLibro ?? "");
                cmd.Parameters.AddWithValue("@idLibro", log.IdLibro);
                cmd.Parameters.AddWithValue("@fechaPrestamo", (object?)log.FechaPrestamo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fechaDevolucion", (object?)log.FechaDevolucion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idPrestamo", (object?)log.IdPrestamo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idDevolucion", (object?)log.IdDevolucion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@accion", log.Accion ?? "");

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar log: " + ex.Message);
            }
        }

        // Obtener todos los logs
        public List<LogProceso> ObtenerLogs()
        {
            var lista = new List<LogProceso>();

            try
            {
                using var conn = _conexion.ObtenerConexion();
                string query = "SELECT id_log, username, id_usuario, nombre_libro, id_libro, fecha_prestamo, fecha_devolucion, id_prestamo, id_devolucion, accion FROM log_procesos ORDER BY id_log DESC";

                using var cmd = new NpgsqlCommand(query, conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lista.Add(new LogProceso
                    {
                        IdLog = r.GetInt32(0),
                        Username = r.IsDBNull(1) ? "" : r.GetString(1),
                        IdUsuario = r.IsDBNull(2) ? 0 : r.GetInt32(2),
                        NombreLibro = r.IsDBNull(3) ? "" : r.GetString(3),
                        IdLibro = r.IsDBNull(4) ? 0 : r.GetInt32(4),
                        FechaPrestamo = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5),
                        FechaDevolucion = r.IsDBNull(6) ? (DateTime?)null : r.GetDateTime(6),
                        IdPrestamo = r.IsDBNull(7) ? (int?)null : r.GetInt32(7),
                        IdDevolucion = r.IsDBNull(8) ? (int?)null : r.GetInt32(8),
                        Accion = r.IsDBNull(9) ? "" : r.GetString(9)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener logs: " + ex.Message);
            }

            return lista;
        }
    }
}
