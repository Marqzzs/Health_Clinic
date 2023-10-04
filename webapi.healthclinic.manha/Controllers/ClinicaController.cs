using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        /// <summary>
        /// Cria uma nova clínica.
        /// </summary>
        /// <param name="clinica">Os dados da clínica a serem cadastrados.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);
                return Ok(); // Status 201: Criado
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Obtém uma lista de todas as clínicas.
        /// </summary>
        /// <returns>Uma resposta HTTP contendo a lista de clínicas.</returns>
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

        /// <summary>
        /// Obtém uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser buscado.</param>
        /// <returns>Uma resposta HTTP contendo os detalhes da clínica encontrada.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Exclui uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser excluída.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return NotFound(); // Status 404: Não encontrado
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Atualiza uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser atualizada.</param>
        /// <param name="clinica">Os novos dados da clínica.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPatch]
        public IActionResult Patch(Guid id, Clinica clinica)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinica);

                return Ok("Clinica cadastrada"); // Status 200: OK
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }
    }
}
