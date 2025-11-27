using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public class ServicioInformes
    {
        public List<IEvento> Eventos { get; private set; }
        public List<Persona> Personas { get; private set; }
        public List<Reserva> Reservas { get; private set; }
        public DateTime FechaGeneracion { get; private set; }
        public ServicioInformes(List<IEvento> eventos, List<Persona> personas, List<Reserva> reservas)
        {
            Eventos = eventos ?? new List<IEvento>();
            Personas = personas ?? new List<Persona>();
            Reservas = reservas ?? new List<Reserva>();
            FechaGeneracion = DateTime.Now;
        }
        public string GenerarTodosInformes()  // Agregado para llamar a todos
        {
            var sb = new StringBuilder();
            sb.Append( new InformeMayorAsistencia(this).GenerarInforme() );
            sb.Append( new InformeOrganizadoresTrayectoria(this).GenerarInforme() );
            sb.Append( new InformeParticipantesMultiples(this).GenerarInforme() );
            return sb.ToString();
        }
    }
}