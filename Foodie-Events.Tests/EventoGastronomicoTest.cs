using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie_Events.Library.Domain;

namespace Foodie_Events.Tests
{
    public class EventoGastronomicoTest
    {
        private Chef CrearChef() =>
            new Chef(1, "Juan Perez", "Italiana", "Argentina", 10, "juan@mail.com", "123456789");
        [Fact]
        public void CrearEvento_Valido_DebeCrearCorrectamente()
        {
            var evento = new EventoPresencial(1, "Cata de vinos", "Degustación", TipoEvento.Cata,
                DateTime.Today, DateTime.Today.AddDays(1), 50, 1000, CrearChef(), "Buenos Aires", "Calle 123", "CABA");  // Usando Presencial
            Assert.Equal("Cata de vinos", evento.Nombre);
            Assert.Equal(50, evento.CapacidadMaxima);
        }
        [Fact]
        public void CrearEvento_TipoInvalido_DebeLanzarExcepcion()
        {
            Assert.Throws<ErrorValidacionException>(() =>
                new EventoPresencial(1, "Evento raro", "Descripcion", (TipoEvento)999,  // Inválido
                    DateTime.Today, DateTime.Today.AddDays(1), 50, 1000, CrearChef(), "Buenos Aires", "Calle 123", "CABA"));
        }
        [Fact]
        public void AgregarReserva_HayCupo_DebeAgregarCorrectamente()
        {
            var evento = new EventoPresencial(1, "Cata de vinos", "Degustación", TipoEvento.Cata,
                DateTime.Today, DateTime.Today.AddDays(1), 1, 1000, CrearChef(), "Buenos Aires", "Calle 123", "CABA");
            var participante = new Participante(1, "Maria Lopez", "maria@mail.com", "123456789", "DNI123");
            var reserva = new Reserva(1, participante, evento);
            evento.AgregarReserva(reserva);
            Assert.Single(evento.Reservas);
        }
        [Fact]
        public void AgregarReserva_SinCupo_DebeLanzarExcepcion()
        {
            var evento = new EventoPresencial(1, "Cata de vinos", "Degustación", TipoEvento.Cata,
                DateTime.Today, DateTime.Today.AddDays(1), 1, 1000, CrearChef(), "Buenos Aires", "Calle 123", "CABA");
            var participante = new Participante(1, "Maria Lopez", "maria@mail.com", "123456789", "DNI123");
            var reserva1 = new Reserva(1, participante, evento);
            evento.AgregarReserva(reserva1);
            var reserva2 = new Reserva(2, participante, evento);
            Assert.Throws<ErrorValidacionException>(() => evento.AgregarReserva(reserva2));
        }
        [Fact]
        public void EliminarEvento_DebeBorrarReservas()
        {
            var evento = new EventoPresencial(1, "Cata de vinos", "Degustación", TipoEvento.Cata,
                DateTime.Today, DateTime.Today.AddDays(1), 1, 1000, CrearChef(), "Buenos Aires", "Calle 123", "CABA");
            var participante = new Participante(1, "Maria Lopez", "maria@mail.com", "123456789", "DNI123");
            var reserva = new Reserva(1, participante, evento);
            evento.AgregarReserva(reserva);
            evento.EliminarEvento();
            Assert.Empty(evento.Reservas);
        }
    }
}