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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidade _especialidaderepository;

        public EspecialidadeController()
        {
            _especialidaderepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Cadastra uma nova especialidade.
        /// </summary>
        /// <param name="especialidade">Os dados da especialidade a ser cadastrada.</param>
        /// <returns>Um código de status 201 (Created) se a especialidade for cadastrada com sucesso, ou 400 (Bad Request) em caso de erro.</returns>
        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidaderepository.Cadastrar(especialidade);

                return StatusCode(201, "Especialidade cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Lista todas as especialidades.
        /// </summary>
        /// <returns>Os dados de todas as especialidades no formato JSON.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidaderepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Busca uma especialidade por ID.
        /// </summary>
        /// <param name="id">O ID da especialidade a ser buscada.</param>
        /// <returns>Os dados da especialidade no formato JSON, ou 400 (Bad Request) em caso de erro.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_especialidaderepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Exclui uma especialidade por ID.
        /// </summary>
        /// <param name="id">O ID da especialidade a ser excluída.</param>
        /// <returns>Um status 404 (Not Found) se a especialidade não for encontrada, ou 400 (Bad Request) em caso de erro.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidaderepository.Deletar(id);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Atualiza uma especialidade por ID.
        /// </summary>
        /// <param name="id">O ID da especialidade a ser atualizada.</param>
        /// <param name="especialidade">Os novos dados da especialidade.</param>
        /// <returns>Um status 200 (OK) se a especialidade for atualizada com sucesso, ou 400 (Bad Request) em caso de erro.</returns>
        [HttpPut]
        public IActionResult Put(Guid id, Especialidade especialidade)
        {
            try
            {
                _especialidaderepository.Atualizar(id, especialidade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }
    }
}
