using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public class EventoVirtual : EventoGastronomico
    {
        public string Plataforma { get; private set; }
        public string EnlaceAcceso { get; private set; }
        public int DuracionMinutos { get; private set; }
        public EventoVirtual(int id, string nombre, string descripcion, TipoEvento tipo,
            DateTime fechaInicio, DateTime fechaFin, int capacidadMaxima,
            decimal precioBase, Chef organizador, string plataforma,
            string enlaceAcceso, int duracionMinutos = 60)
            : base(id, nombre, descripcion, tipo, fechaInicio, fechaFin, capacidadMaxima,
                precioBase, organizador)
        {
            if (string.IsNullOrWhiteSpace(plataforma))
                throw new ErrorValidacionException("La plataforma es requerida para eventos virtuales.");
            ValidadorDatos.ValidarPlataformaVirtual(plataforma);
            ValidadorDatos.ValidarDuracionEvento(duracionMinutos);
            Plataforma = plataforma;
            EnlaceAcceso = enlaceAcceso;
            DuracionMinutos = duracionMinutos;
        }
        public override string ObtenerModalidad() => "Virtual";
        public override decimal CalcularPrecioFinal()
        {
            decimal descuentoVirtual = PrecioBase * 0.1m;
            return PrecioBase - descuentoVirtual;
        }
        public override bool HayCupoDisponible()
        {
            if (CapacidadMaxima == 0)
                return true;
            return base.HayCupoDisponible();
        }
        public string ObtenerInstruccionesConexion()
        {
            return $"Instrucciones para evento virtual:\n" +
                   $"Plataforma: {Plataforma}\n" +
                   $"Enlace: {EnlaceAcceso}\n" +
                   $"Hora: {FechaInicio:HH:mm} - Duración: {DuracionMinutos} minutos\n" +
                   $"Recomendación: Conectarse 10 minutos antes";
        }
    }
}