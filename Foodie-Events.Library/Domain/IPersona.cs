using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Events.Library.Domain
{
    public interface IPersona
    {
        int Id { get; }
        string NombreCompleto { get; }
        string Email { get; }
        string Telefono { get; }
        void Registrar();
        string ProporcionarDatosContacto();
        string PresentarInformacion();
    }
}