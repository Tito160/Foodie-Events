using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public abstract class EventoGastronomico : IEvento
    {
        public int Id { get; protected set; }
        public string Nombre { get; protected set; }
        public string Descripcion { get; protected set; }
        public TipoEvento Tipo { get; protected set; }  // Cambiado a enum
        public DateTime FechaInicio { get; protected set; }
        public DateTime FechaFin { get; protected set; }
        public int CapacidadMaxima { get; protected set; }
        public decimal PrecioBase { get; protected set; }
        public Chef Organizador { get; protected set; }
        public List<Reserva> Reservas { get; protected set; }
        protected EventoGastronomico(int id, string nombre, string descripcion, TipoEvento tipo,
            DateTime fechaInicio, DateTime fechaFin, int capacidadMaxima,
            decimal precioBase, Chef organizador)
        {
            ValidadorDatos.ValidarTipoEvento(tipo.ToString());  // Adaptado para enum
            ValidadorDatos.ValidarFechasEvento(fechaInicio, fechaFin);
            ValidadorDatos.ValidarCapacidad(capacidadMaxima);
            ValidadorDatos.ValidarPrecio(precioBase);
            if (organizador == null)
                throw new ErrorValidacionException("El evento debe tener un chef organizador.");
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Tipo = tipo;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            CapacidadMaxima = capacidadMaxima;
            PrecioBase = precioBase;
            Organizador = organizador;
            Reservas = new List<Reserva>();
        }
        public virtual bool HayCupoDisponible() => Reservas.Count < CapacidadMaxima;
        public virtual int LugaresDisponibles() => CapacidadMaxima - Reservas.Count;
        public virtual void AgregarReserva(Reserva reserva)
        {
            if (!HayCupoDisponible())
                throw new ErrorValidacionException("No hay cupo disponible para este evento.");
            Reservas.Add(reserva);
        }
        public virtual void CancelarReserva(Reserva reserva)
        {
            if (Reservas.Contains(reserva))
                Reservas.Remove(reserva);
        }
        public virtual void EliminarEvento()  // Agregado para cascading delete
        {
            Reservas.Clear();  // Borra reservas asociadas
        }
        public virtual string ObtenerInformacionEvento()
        {
            return $"Evento: {Nombre} ({Tipo}) | " +
                   $"{FechaInicio:dd/MM/yyyy} - {FechaFin:dd/MM/yyyy} | " +
                   $"Capacidad: {CapacidadMaxima} | Modalidad: {ObtenerModalidad()}";
        }
        public abstract string ObtenerModalidad();
        public abstract decimal CalcularPrecioFinal();
        public override string ToString() => ObtenerInformacionEvento();
    }
}