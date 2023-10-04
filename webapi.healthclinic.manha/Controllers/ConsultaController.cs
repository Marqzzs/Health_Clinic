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

        /// <summary>
        /// Agenda uma nova consulta.
        /// </summary>
        /// <param name="consulta">Os dados da consulta a ser agendada.</param>
        /// <returns>Um código de status 201 (Criado) se a consulta for agendada com sucesso.</returns>
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

        /// <summary>
        /// Lista todas as consultas cadastradas.
        /// </summary>
        /// <returns>Uma lista de todas as consultas cadastradas.</returns>
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

        /// <summary>
        /// Busca uma consulta por seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser buscada.</param>
        /// <returns>O objeto Consulta encontrado ou um código de status 404 (Não Encontrado) se não encontrado.</returns>
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

        /// <summary>
        /// Lista todas as consultas associadas a um paciente com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente para o qual as consultas serão listadas.</param>
        /// <returns>Uma lista de objetos Consulta associados ao paciente.</returns>
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

        /// <summary>
        /// Cancela uma consulta com base em seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser cancelada.</param>
        /// <returns>Um código de status 404 (Não Encontrado) se a consulta for cancelada com sucesso.</returns>
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

        /// <summary>
        /// Reagenda uma consulta com base em seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser reagendada.</param>
        /// <param name="consulta">Os novos dados da consulta reagendada.</param>
        /// <returns>Um código de status 200 (OK) se a consulta for reagendada com sucesso.</returns>
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
