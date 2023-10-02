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
    public class MedicoController : ControllerBase
    {
        private readonly IMedico _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="medico">Os dados do médico a serem cadastrados.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return StatusCode(201, "Medico cadastrado"); // Status 201: Criado
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Obtém uma lista de todos os médicos cadastrados.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de médicos.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Obtém um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser buscado.</param>
        /// <returns>Uma resposta HTTP contendo os detalhes do médico encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Lista os medicos com base no id da especialidade
        /// </summary>
        /// <param name="id">id da especialidade</param>
        /// <returns>Retorna os medicos com base na especialidade</returns>
        [HttpGet("Especialidade")]
        public IActionResult ListarComEspecialdade(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.ListarComEspecialidade(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Exclui um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser excluído.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);

                return NotFound("Medico demitido");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Atualiza um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser atualizado.</param>
        /// <param name="medico">Os novos dados do médico.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPatch]
        public IActionResult Patch(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);

                return Ok("Medico atualizado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }
    }
}
