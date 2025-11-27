using System;
using Foodie_Events.Library.Domain;
using FoodieEvents;

namespace FoodieEvents.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a FoodieEvents Console");
            while (true)
            {
                Console.WriteLine("1. Crear Chef");
                Console.WriteLine("2. Crear Evento Presencial");
                Console.WriteLine("3. Crear Reserva");
                Console.WriteLine("4. Generar Informes");
                Console.WriteLine("5. Salir");
                var opcion = Console.ReadLine();
                try
                {
                    switch (opcion)
                    {
                        case "1":
                            CrearChef();
                            break;
                        case "2":
                            CrearEventoPresencial();
                            break;
                        case "3":
                            CrearReserva();
                            break;
                        case "4":
                            GenerarInformes();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                    }
                }
                catch (ErrorValidacionException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void CrearChef()
        {
            // Inputs simulados
            var chef = new Chef(1, "Juan Perez", "Italiana", "Argentina", 10, "juan@mail.com", "123456789");
            chef.Registrar();
        }

        static void CrearEventoPresencial()
        {
            var chef = new Chef(1, "Juan Perez", "Italiana", "Argentina", 10, "juan@mail.com", "123456789");
            var evento = new EventoPresencial(1, "Cata", "Desc", TipoEvento.Cata, DateTime.Now, DateTime.Now.AddDays(1), 50, 100, chef, "Lugar", "Dir", "Ciudad");
            Console.WriteLine(evento.ObtenerInformacionEvento());
        }

        static void CrearReserva()
        {
            var chef = new Chef(1, "Juan Perez", "Italiana", "Argentina", 10, "juan@mail.com", "123456789");
            var evento = new EventoPresencial(1, "Cata", "Desc", TipoEvento.Cata, DateTime.Now, DateTime.Now.AddDays(1), 50, 100, chef, "Lugar", "Dir", "Ciudad");
            var participante = new Participante(1, "Maria", "maria@mail.com", "123", "DNI123");
            var reserva = new Reserva(1, participante, evento);
            reserva.ConfirmarPago("Tarjeta");
            Console.WriteLine(reserva.ToString());
        }

        static void GenerarInformes()
        {
            // Simulado con datos dummy
            var servicio = new ServicioInformes(new List<IEvento>(), new List<Persona>(), new List<Reserva>());
            Console.WriteLine(servicio.GenerarTodosInformes());
        }
    }
}