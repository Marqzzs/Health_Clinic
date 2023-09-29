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
    public class PacienteController : ControllerBase
    {
        private readonly IPaciente _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201, "Paciente cadastrado com sucesso");
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
                return Ok(_pacienteRepository.ListarTodos()); // Status 200: OK
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        [HttpPatch]
        public IActionResult Patch(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);

                return Ok("Paciente Atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }
    }
}
