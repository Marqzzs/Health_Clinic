using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaConsultaController : ControllerBase
    {
        private readonly IPresencaConsulta _presencaConsulta;

        public PresencaConsultaController()
        {
            _presencaConsulta = new PresencaConsultaRepository();
        }

        /// <summary>
        /// Registra a participação de um paciente em uma consulta.
        /// </summary>
        /// <param name="idConsulta">O ID da consulta.</param>
        /// <param name="idPaciente">O ID do paciente.</param>
        /// <returns>Um IActionResult indicando o resultado da operação.</returns>
        [HttpPost]
        public IActionResult Post(Guid idConsulta, Guid idPaciente)
        {
            try
            {
                _presencaConsulta.ParticiparConsulta(idConsulta, idPaciente);
                return Ok("Presença marcada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista todas as presenças de um paciente com base no seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente.</param>
        /// <returns>Um IActionResult contendo a lista de presenças do paciente.</returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_presencaConsulta.ListarPresencas(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Cancela a participação de um paciente em um evento.
        /// </summary>
        /// <param name="idEvento">O ID do evento.</param>
        /// <param name="idUsuario">O ID do usuário (paciente).</param>
        /// <returns>Um IActionResult indicando o resultado da operação.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid idEvento, Guid idUsuario)
        {
            try
            {
                _presencaConsulta.CancelarParticipacao(idEvento, idUsuario);
                return Ok("Participação cancelada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
