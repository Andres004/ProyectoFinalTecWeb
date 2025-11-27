using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/conductor")]
    public class ConductorController : ControllerBase
    {
        private readonly IConductorService _service;
        private readonly IViajeService _viajes;
        public ConductorController(IConductorService service, IViajeService viajes)
        {
            _service = service;
            _viajes = viajes;
        }
        // POST: api/conductor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConductorDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Created($"api/v1/speakers/{id}", new { id });
        }

        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterConductorDto dto)
        {
            var id = await _service.RegisterAsync(dto);
            return CreatedAtAction(nameof(Register), new { id }, null);
        }

        
    }
}
