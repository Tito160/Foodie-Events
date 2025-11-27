using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public class InvitadoEspecial : Persona
    {
        public TipoInvitado TipoInvitado { get; private set; }  // Cambiado a enum
        public string Especialidad { get; private set; }
        public int Seguidores { get; private set; }
        public InvitadoEspecial(int id, string nombreCompleto, string email, string telefono,
            TipoInvitado tipoInvitado, string especialidad = "", int seguidores = 0)
            : base(id, nombreCompleto, email, telefono)
        {
            ValidadorDatos.ValidarTipoInvitado(tipoInvitado.ToString());  // Adaptado
            TipoInvitado = tipoInvitado;
            Especialidad = especialidad;
            Seguidores = seguidores;
        }
        public override string PresentarInformacion()
        {
            string info = $"{TipoInvitado}: {NombreCompleto}";
            if (!string.IsNullOrEmpty(Especialidad))
            {
                info += $" | Especialidad: {Especialidad}";
            }
            if (Seguidores > 0)
            {
                info += $" | Seguidores: {Seguidores:N0}";
            }
            info += " | Acceso: Gratuito";
            return info;
        }
        public override void Registrar()
        {
            base.Registrar();
            Console.WriteLine($"Invitado especial ({TipoInvitado}) registrado con acceso gratuito.");
        }
        public override string ToString() => PresentarInformacion();
    }
}