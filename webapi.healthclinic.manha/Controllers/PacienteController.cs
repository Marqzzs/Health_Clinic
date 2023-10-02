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

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="paciente">Os dados do paciente a serem cadastrados.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201, "Paciente cadastrado com sucesso"); // Status 201: Criado
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Obtém uma lista de todos os pacientes cadastrados.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de pacientes.</returns>
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

        /// <summary>
        /// Obtém um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser buscado.</param>
        /// <returns>Uma resposta HTTP contendo os detalhes do paciente encontrado.</returns>
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

        /// <summary>
        /// Exclui um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser excluído.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return NotFound(); // Status 404: Não encontrado
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Atualiza um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser atualizado.</param>
        /// <param name="paciente">Os novos dados do paciente.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPatch]
        public IActionResult Patch(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);

                return Ok("Paciente Atualizado"); // Status 200: OK
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }
    }
}
