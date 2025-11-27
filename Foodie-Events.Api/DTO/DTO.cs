using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodie_Events.Library.Domain;

namespace Foodie_Events.Api.DTO
{
    public class DTO
    {
        public class CrearEventoPresencialDto
{
    public string Ubicacion { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public CrearChefDto Organizador { get; set; }

    // Campos heredados también
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public TipoEvento Tipo { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int CapacidadMaxima { get; set; }
    public decimal PrecioBase { get; set; }
}

public class CrearChefDto
{
    public string NombreCompleto { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Especialidad { get; set; }
    public string Nacionalidad { get; set; }
    public int AniosExperiencia { get; set; }
}

    }
}