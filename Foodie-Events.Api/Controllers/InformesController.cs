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
    public class InformesController : ControllerBase
    {
        private readonly ServicioInformes _servicio;  // Inyectar en prod

        public InformesController()
        {
            // Simulado
            _servicio = new ServicioInformes(new List<IEvento>(), new List<Persona>(), new List<Reserva>());
        }

        [HttpGet]
        public IActionResult GetInformes()
        {
            return Ok(_servicio.GenerarTodosInformes());
        }
    }
}