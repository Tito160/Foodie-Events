using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Foodie_Events.Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

using static Foodie_Events.Api.DTO.DTO;

namespace Foodie_Events.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private static readonly List<IEvento> _eventos = new List<IEvento>();


        [HttpPost]
        public IActionResult CrearEvento([FromBody] CrearEventoPresencialDto dto)  // Ejemplo para presencial
        {
            var chef = new Chef(
            1,dto.Organizador.NombreCompleto,dto.Organizador.Especialidad,dto.Organizador.Nacionalidad,dto.Organizador.AniosExperiencia,dto.Organizador.Email,dto.Organizador.Telefono);

            var evento = new EventoPresencial(2,dto.Nombre,dto.Descripcion,dto.Tipo,dto.FechaInicio,dto.FechaFin,dto.CapacidadMaxima,dto.PrecioBase,chef,dto.Ubicacion,dto.Direccion,dto.Ciudad);


            _eventos.Add(evento);
            return Ok(evento);
        }

        [HttpGet]
        public IActionResult GetEventos()
        {
            return Ok(_eventos);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarEvento(int id)
        {
            var evento = _eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null) return NotFound();
            evento.EliminarEvento();
            _eventos.Remove(evento);
            return Ok();
        }
    }
}