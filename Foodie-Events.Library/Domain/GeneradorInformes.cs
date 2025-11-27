using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public abstract class GeneradorInformes : IGeneradorInformes
    {
        protected ServicioInformes Servicio { get; }
        protected GeneradorInformes(ServicioInformes servicio)
        {
            Servicio = servicio;
        }
        public abstract string GenerarInforme();
    }

    public class InformeMayorAsistencia : GeneradorInformes
    {
        public InformeMayorAsistencia(ServicioInformes servicio) : base(servicio) { }
        public override string GenerarInforme()
        {
            var sb = new StringBuilder();
            sb.AppendLine("INFORME: Eventos con mayor asistencia");
            var eventosConAsistencia = Servicio.Eventos
                .Select(e => new {
                    Evento = e,
                    Asistencia = Servicio.Reservas.Count(r => r.Evento.Id == e.Id && r.Estado == EstadoReserva.Confirmada)
                })
                .OrderByDescending(x => x.Asistencia);
            foreach (var item in eventosConAsistencia)
            {
                sb.AppendLine($" • {item.Evento.Nombre}: {item.Asistencia} participantes");
            }
            return sb.ToString();
        }
    }

    public class InformeOrganizadoresTrayectoria : GeneradorInformes
    {
        public InformeOrganizadoresTrayectoria(ServicioInformes servicio) : base(servicio) { }
        public override string GenerarInforme()
        {
            var sb = new StringBuilder();
            sb.AppendLine("INFORME: Organizadores con más trayectoria");
            var chefs = Servicio.Personas.OfType<Chef>()
                .OrderByDescending(c => c.AniosExperiencia);
            foreach (var chef in chefs)
            {
                sb.AppendLine($" • {chef.NombreCompleto}: {chef.AniosExperiencia} años");
            }
            return sb.ToString();
        }
    }

    public class InformeParticipantesMultiples : GeneradorInformes
    {
        public InformeParticipantesMultiples(ServicioInformes servicio) : base(servicio) { }
        public override string GenerarInforme()
        {
            var sb = new StringBuilder();
            sb.AppendLine("INFORME: Personas en múltiples actividades");
            var personasMulti = Servicio.Reservas.GroupBy(r => r.Persona)
                .Where(g => g.Count() > 1)
                .OrderByDescending(g => g.Count());
            foreach (var group in personasMulti)
            {
                sb.AppendLine($" • {group.Key.NombreCompleto}: {group.Count()} eventos");
            }
            return sb.ToString();
        }
    }
}