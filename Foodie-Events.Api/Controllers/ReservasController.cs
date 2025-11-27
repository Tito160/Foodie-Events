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
    public class ReservasController : ControllerBase
    {
        private readonly List<Reserva> _reservas = new List<Reserva>();

        [HttpPost]
        public IActionResult CrearReserva([FromBody] Reserva reserva)
        {
            _reservas.Add(reserva);
            return Ok(reserva);
        }

        [HttpGet]
        public IActionResult GetReservas()
        {
            return Ok(_reservas);
        }
    }
}