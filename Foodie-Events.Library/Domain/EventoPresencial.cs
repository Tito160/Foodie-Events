using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public class EventoPresencial : EventoGastronomico
    {
        public string Ubicacion { get; private set; }
        public string Direccion { get; private set; }
        public string Ciudad { get; private set; }
        public EventoPresencial(int id, string nombre, string descripcion, TipoEvento tipo,
            DateTime fechaInicio, DateTime fechaFin, int capacidadMaxima,
            decimal precioBase, Chef organizador, string ubicacion,
            string direccion, string ciudad)
            : base(id, nombre, descripcion, tipo, fechaInicio, fechaFin, capacidadMaxima,
                   precioBase, organizador)
        {
            if (string.IsNullOrWhiteSpace(ubicacion))
                throw new ErrorValidacionException("La ubicación es requerida para eventos presenciales.");
            Ubicacion = ubicacion;
            Direccion = direccion;
            Ciudad = ciudad;
        }
        public override string ObtenerModalidad() => "Presencial";
        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase;
        }
        public string ObtenerInstruccionesAsistencia()
        {
            return $"Instrucciones para evento presencial:\n" +
                   $"Lugar: {Ubicacion}\n" +
                   $"Dirección: {Direccion}, {Ciudad}\n" +
                   $"Hora: {FechaInicio:HH:mm} - {FechaFin:HH:mm}\n" +
                   $"Recomendación: Llegar 15 minutos antes";
        }
    }
}