using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public static class ValidadorDatos
    {
        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ErrorValidacionException($"Email inválido: {email}");
            }
        }
        public static void ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono) || !Regex.IsMatch(telefono, @"^\d{7,15}$"))
            {
                throw new ErrorValidacionException($"Teléfono inválido: {telefono}");
            }
        }
        public static void ValidarFechasEvento(DateTime inicio, DateTime fin)
        {
            if (fin < inicio)
                throw new ErrorValidacionException("La fecha de fin no puede ser anterior a la fecha de inicio.");
        }
        public static void ValidarCapacidad(int capacidad)
        {
            if (capacidad <= 0)
                throw new ErrorValidacionException("La capacidad máxima debe ser mayor que 0.");
        }
        public static void ValidarPrecio(decimal precio)
        {
            if (precio < 0)
                throw new ErrorValidacionException("El precio no puede ser negativo.");
        }
        public static void ValidarTipoEvento(string tipo)
        {
            if (!Enum.TryParse<TipoEvento>(tipo, true, out _))
                throw new ErrorValidacionException($"Tipo de evento inválido: {tipo}");
        }
        public static void ValidarMetodoPago(string metodo)
        {
            if (metodo != "Gratuito" && !Enum.TryParse<MetodoPago>(metodo, true, out _))  // Adaptado para gratuito
                throw new ErrorValidacionException($"Método de pago inválido: {metodo}");
        }
        public static void ValidarEstadoReserva(string estado)
        {
            if (!Enum.TryParse<EstadoReserva>(estado, true, out _))
                throw new ErrorValidacionException($"Estado de reserva inválido: {estado}");
        }
        public static void ValidarTipoInvitado(string tipo)
        {
            if (!Enum.TryParse<TipoInvitado>(tipo, true, out _))
                throw new ErrorValidacionException($"Tipo de invitado inválido: {tipo}");
        }
        public static void ValidarPlataformaVirtual(string plataforma)
        {
            string[] plataformasValidas = { "Zoom", "Teams", "YouTube", "Google Meet", "Webex", "Otra" };
            if (Array.IndexOf(plataformasValidas, plataforma) == -1)
                throw new ErrorValidacionException($"Plataforma virtual no soportada: {plataforma}");
        }
        public static void ValidarDuracionEvento(int duracionMinutos)
        {
            if (duracionMinutos <= 0)
                throw new ErrorValidacionException("La duración del evento debe ser mayor a 0 minutos.");
        }
        public static void ValidarEspecialidad(string especialidad)
        {
            if (string.IsNullOrWhiteSpace(especialidad))
                throw new ErrorValidacionException("La especialidad del chef es requerida.");
        }
        public static void ValidarNacionalidad(string nacionalidad)
        {
            if (string.IsNullOrWhiteSpace(nacionalidad))
                throw new ErrorValidacionException("La nacionalidad del chef es requerida.");
        }
        public static void ValidarExperiencia(int aniosExperiencia)
        {
            if (aniosExperiencia < 0)
                throw new ErrorValidacionException("Los años de experiencia no pueden ser negativos.");
        }
        public static void ValidarDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                throw new ErrorValidacionException("El documento de identidad es requerido.");
        }
        public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ErrorValidacionException("El nombre es requerido.");
        }
    }
}