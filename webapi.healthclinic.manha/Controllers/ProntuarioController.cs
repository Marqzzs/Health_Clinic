using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {
        private readonly IProntuario _prontuarioRepository;

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo prontuário no sistema.
        /// </summary>
        /// <param name="prontuario">O objeto Prontuario a ser cadastrado.</param>
        /// <returns>O status da operação.</returns>
        [HttpPost]
        public IActionResult Post(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.CadastrarProntuario(prontuario);

                return StatusCode(201, "Prontuario adicionado"); // Status 201: Criado
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Retorna todos os prontuários cadastrados no sistema.
        /// </summary>
        /// <returns>Uma lista de prontuários.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_prontuarioRepository.ListarTodos()); // Status 200: OK
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Retorna os prontuários de um paciente com base no ID do paciente.
        /// </summary>
        /// <param name="id">O ID do paciente.</param>
        /// <returns>Uma lista de prontuários do paciente.</returns>
        [HttpGet("PorPaciente")]
        public IActionResult GetByPaciente(Guid id)
        {
            try
            {
                return Ok(_prontuarioRepository.ListarPorPaciente(id)); // Status 200: OK
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Deleta um prontuário com base no seu ID.
        /// </summary>
        /// <param name="id">O ID do prontuário a ser deletado.</param>
        /// <returns>O status da operação.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);

                return NotFound("Prontuario deletado"); // Status 404: Não encontrado
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Atualiza as informações de um prontuário com base no seu ID.
        /// </summary>
        /// <param name="id">O ID do prontuário a ser atualizado.</param>
        /// <param name="prontuario">O objeto Prontuario contendo as novas informações.</param>
        /// <returns>O status da operação.</returns>
        [HttpPatch]
        public IActionResult Patch(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);

                return Ok("Prontuario atualizado"); // Status 200: OK
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }
    }
}
