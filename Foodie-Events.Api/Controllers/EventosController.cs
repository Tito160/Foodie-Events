using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Foodie_Events.Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foodie_Events.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly List<IEvento> _eventos = new List<IEvento>();  // Simulado, usa DB en prod

        [HttpPost]
        public IActionResult CrearEvento([FromBody] EventoPresencial evento)  // Ejemplo para presencial
        {
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