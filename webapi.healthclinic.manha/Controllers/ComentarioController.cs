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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentario _comentarioRepository;

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        /// <summary>
        /// Endpoint para criar um novo comentário.
        /// </summary>
        /// <param name="comentario">O objeto Comentario a ser criado.</param>
        /// <returns>Um código de status 201 (Created) se o comentário for criado com sucesso.</returns>
        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Comentar(comentario);
                return StatusCode(201); // Status 201: Created
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Endpoint para listar comentários associados a um paciente com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente para o qual os comentários serão listados.</param>
        /// <returns>Uma resposta HTTP contendo uma lista de objetos Comentario associados ao paciente.</returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentarioRepository.ListarPorPaciente(id)); // Status 200: OK
            }
            catch (Exception)
            {
                return BadRequest(); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Endpoint para excluir um comentário com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser excluído.</param>
        /// <returns>Um código de status 404 (Not Found) se o comentário for excluído com sucesso.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return NotFound(); // Status 404: Not Found
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); // Status 400: Requisição inválida
            }
        }
    }
}
