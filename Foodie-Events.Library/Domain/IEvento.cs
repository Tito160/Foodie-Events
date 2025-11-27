using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public interface IEvento
    {
        int Id { get; }
        string Nombre { get; }
        string Descripcion { get; }
        TipoEvento Tipo { get; }  // Adaptado a enum
        DateTime FechaInicio { get; }
        DateTime FechaFin { get; }
        int CapacidadMaxima { get; }
        decimal PrecioBase { get; }
        Chef Organizador { get; }
        List<Reserva> Reservas { get; }
        bool HayCupoDisponible();
        int LugaresDisponibles();
        void AgregarReserva(Reserva reserva);
        void CancelarReserva(Reserva reserva);
        void EliminarEvento();  // Agregado
        string ObtenerInformacionEvento();
        string ObtenerModalidad();
        decimal CalcularPrecioFinal();
    }
}