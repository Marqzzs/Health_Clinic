using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinica _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);
                return StatusCode(201, "Clinica criada");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clinicaRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }
    }
}
