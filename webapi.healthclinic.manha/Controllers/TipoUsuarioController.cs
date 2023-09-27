using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;
using System;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuario _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário.
        /// </summary>
        /// <param name="tipoUsuario">Os dados do tipo de usuário a ser cadastrado.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201); // Status 201: Criado com sucesso
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Retorna todos os tipos de usuário cadastrados.
        /// </summary>
        /// <returns>Uma lista de tipos de usuário.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ListarTodos()); // Status 200: OK
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Retorna um tipo de usuário específico com base no ID.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser buscado.</param>
        /// <returns>O tipo de usuário encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id)); // Status 200: OK
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser atualizado.</param>
        /// <param name="tipoUsuario">Os novos dados do tipo de usuário.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return StatusCode(201, "Atualizado com sucesso"); // Status 201: Criado com sucesso
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Exclui um tipo de usuário existente.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser excluído.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return NoContent(); // Status 204: Sem conteúdo
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }
    }
}
