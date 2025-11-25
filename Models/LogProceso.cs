using System;
using BibliotecaApp.Services;

namespace BibliotecaApp.Models
{
    public class LogProceso
    {
        public int IdLog { get; set; }
        public string Username { get; set; }
        public int IdUsuario { get; set; }
        public string NombreLibro { get; set; }
        public int IdLibro { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int? IdPrestamo { get; set; }
        public int? IdDevolucion { get; set; }
        public string Accion { get; set; }

        public LogProceso() { }

        public LogProceso(string username, int idUsuario, string accion,
                          string nombreLibro = "", int idLibro = 0,
                          DateTime? fechaPrestamo = null, DateTime? fechaDevolucion = null,
                          int? idPrestamo = null, int? idDevolucion = null)
        {
            Username = username;
            IdUsuario = idUsuario;
            Accion = accion;
            NombreLibro = nombreLibro;
            IdLibro = idLibro;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            IdPrestamo = idPrestamo;
            IdDevolucion = idDevolucion;
        }

        public override string ToString()
        {
            return $"[{IdLog}] {Accion} - {Username} - {FechaPrestamo?.ToString("dd/MM/yyyy HH:mm")}";
        }

  
        public static LogProceso CrearLogin(int idUsuario, string username)
        {
            return new LogProceso(username, idUsuario, "LOGIN", fechaPrestamo: DateTime.Now);
        }

        public static LogProceso CrearLogout(int idUsuario, string username)
        {
            return new LogProceso(username, idUsuario, "LOGOUT", fechaPrestamo: DateTime.Now);
        }

        public static LogProceso CrearPrestamo(int idUsuario, string username, int idLibro, string nombreLibro, int idPrestamo, int cantidad)
        {
            return new LogProceso(username, idUsuario, "PRESTAMO", nombreLibro + $" (Cant: {cantidad})", idLibro, fechaPrestamo: DateTime.Now, idPrestamo: idPrestamo);
        }

        public static LogProceso CrearDevolucion(int idUsuario, string username, int idLibro, string nombreLibro, int idPrestamo, int idDevolucion, int cantidad)
        {
            return new LogProceso(username, idUsuario, "DEVOLUCION", nombreLibro + $" (Cant: {cantidad})", idLibro, fechaPrestamo: DateTime.Now, idDevolucion: idDevolucion, idPrestamo: idPrestamo);
        }

        public static LogProceso CrearLibro(int idUsuario, string username, int idLibro, string nombreLibro)
        {
            return new LogProceso(username, idUsuario, "CREAR_LIBRO", nombreLibro, idLibro, fechaPrestamo: DateTime.Now);
        }

        public static LogProceso ModificarLibro(int idUsuario, string username, int idLibro, string nombreLibro)
        {
            return new LogProceso(username, idUsuario, "MODIFICAR_LIBRO", nombreLibro, idLibro, fechaPrestamo: DateTime.Now);
        }

        public static LogProceso EliminarLibro(int idUsuario, string username, int idLibro, string nombreLibro)
        {
            return new LogProceso(username, idUsuario, "ELIMINAR_LIBRO", nombreLibro, idLibro, fechaPrestamo: DateTime.Now);
        }

        public static LogProceso CrearUsuario(int idUsuarioAdmin, string usernameAdmin, string nuevoUsername)
        {
            return new LogProceso(usernameAdmin, idUsuarioAdmin, "CREAR_USUARIO", $"Creó usuario: {nuevoUsername}");
        }

        public static LogProceso ModificarUsuario(int idUsuarioAdmin, string usernameAdmin, string usuarioModificado)
        {
            return new LogProceso(usernameAdmin, idUsuarioAdmin, "MODIFICAR_USUARIO", $"Modificó usuario: {usuarioModificado}");
        }

        public static LogProceso EliminarUsuario(int idUsuarioAdmin, string usernameAdmin, string usuarioEliminado)
        {
            return new LogProceso(usernameAdmin, idUsuarioAdmin, "ELIMINAR_USUARIO", $"Eliminó usuario: {usuarioEliminado}");
        }
    }
}
