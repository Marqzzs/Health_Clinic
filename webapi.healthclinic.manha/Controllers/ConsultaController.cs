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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsulta _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201, "Consulta agendada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        [HttpGet("comPaciente")]
        public IActionResult ListarComPaciente(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.ListarComPaciente(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return NotFound("Consulta cancelada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        [HttpPatch]
        public IActionResult Patch(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

                return Ok("Consulta reagendada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }
    }
}
