using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie_Events.Library.Domain;

namespace Foodie_Events.Tests
{
    public class ReservaTest
    {
        private Chef CrearChef() =>
            new Chef(1, "Juan Perez", "Italiana", "Argentina", 10, "juan@mail.com", "123456789");
        private EventoPresencial CrearEvento() =>
            new EventoPresencial(1, "Cata de vinos", "Degustación", TipoEvento.Cata,
                DateTime.Today, DateTime.Today.AddDays(1), 50, 1000, CrearChef(), "Buenos Aires", "Calle 123", "CABA");
        private Participante CrearParticipante() =>
            new Participante(1, "Maria Lopez", "maria@mail.com", "123456789", "DNI123");
        private InvitadoEspecial CrearInvitado() =>
            new InvitadoEspecial(2, "Critico Gourmet", "critico@mail.com", "987654321", TipoInvitado.Critico);
        [Fact]
        public void CrearReserva_Valida_DebeCrearEnEspera()
        {
            var reserva = new Reserva(1, CrearParticipante(), CrearEvento());
            Assert.Equal(EstadoReserva.EnEspera, reserva.Estado);
            Assert.False(reserva.Pagado);
        }
        [Fact]
        public void CrearReserva_Invitado_DebeSerGratuito()
        {
            var reserva = new Reserva(1, CrearInvitado(), CrearEvento());
            Assert.True(reserva.Pagado);
            Assert.Equal("Gratuito", reserva.MetodoPago);
            Assert.Equal(EstadoReserva.Confirmada, reserva.Estado);
        }
        [Fact]
        public void ConfirmarPago_Valido_DebeCambiarEstadoAPagado()
        {
            var reserva = new Reserva(1, CrearParticipante(), CrearEvento());
            reserva.ConfirmarPago("Tarjeta");
            Assert.True(reserva.Pagado);
            Assert.Equal(EstadoReserva.Confirmada, reserva.Estado);
        }
        [Fact]
        public void ConfirmarPago_MetodoInvalido_DebeLanzarExcepcion()
        {
            var reserva = new Reserva(1, CrearParticipante(), CrearEvento());
            Assert.Throws<ErrorValidacionException>(() => reserva.ConfirmarPago("Bitcoin"));
        }
        [Fact]
        public void CancelarReserva_DebeCambiarEstadoACancelada()
        {
            var reserva = new Reserva(1, CrearParticipante(), CrearEvento());
            reserva.CancelarReserva();
            Assert.Equal(EstadoReserva.Cancelada, reserva.Estado);
        }
    }
}