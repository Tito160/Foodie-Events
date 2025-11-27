using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public class Reserva
    {
        public int Id { get; private set; }
        public Persona Persona { get; private set; }  // Cambiado de Participante a Persona para soportar InvitadoEspecial
        public IEvento Evento { get; private set; }
        public DateTime FechaReserva { get; private set; }
        public bool Pagado { get; private set; }
        public string MetodoPago { get; private set; }
        public EstadoReserva Estado { get; private set; }  // Cambiado a enum
        public Reserva(int id, Persona persona, IEvento evento)
        {
            if (persona == null)
                throw new ErrorValidacionException("La persona es requerida para la reserva.");
            if (evento == null)
                throw new ErrorValidacionException("El evento es requerido para la reserva.");
            Id = id;
            Persona = persona;
            Evento = evento;
            FechaReserva = DateTime.Now;
            Pagado = persona is InvitadoEspecial;  // Gratuito para invitados
            Estado = EstadoReserva.EnEspera;
            if (persona is InvitadoEspecial)
            {
                MetodoPago = "Gratuito";  // Lógica agregada mínima
                ConfirmarPago("Gratuito");  // Confirma automáticamente
            }
        }
        public void ConfirmarPago(string metodoPago)
        {
            if (Persona is not InvitadoEspecial)
                ValidadorDatos.ValidarMetodoPago(metodoPago);
            Pagado = true;
            MetodoPago = metodoPago;
            Estado = EstadoReserva.Confirmada;
            Evento.AgregarReserva(this);
        }
        public void CancelarReserva()
        {
            Estado = EstadoReserva.Cancelada;
        }
        public override string ToString()
        {
            return $"Reserva #{Id} - {Persona.NombreCompleto} | " +
                $"Evento: {Evento.Nombre} | Estado: {Estado} | Pagado: {(Pagado ? "Sí" : "No")}";
        }
    }
}