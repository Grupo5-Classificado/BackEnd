using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
using LeiloadosWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _UsuariosRepository { get; set; }

        public UsuariosController()
        {
            _UsuariosRepository = new UsuariosRepository();

        }

        /// <summary>
        /// Lista as Usuarioss
        /// </summary>
        /// <returns> uma lista de Usuarioss</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            List<Usuario> listaUsuarios = _UsuariosRepository.Listar();

            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Busca uma Usuarios por ID
        /// </summary>
        /// <param name="idUsuarios">O id da Usuarios a ser buscada</param>
        /// <returns>A Usuarios encontrada</returns>
        [HttpGet("{idUsuarios}")]
        public IActionResult BuscarPorID(int idUsuarios)
        {
            try
            {
                Usuario teste = _UsuariosRepository.BuscarPorID(idUsuarios);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("O Usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma Usuarios
        /// </summary>
        /// <param name="Usuarios">O objeto com os dados da nova Usuarios</param>
        [HttpPost]
        public IActionResult Cadastrar(Usuario Usuarios)
        {

            try
            {
                _UsuariosRepository.Cadastrar(Usuarios);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma Usuarios existente
        /// </summary>
        /// <param name="idUsuarios">id da Usuarios a ser atualizada</param>
        /// <param name="UsuariosUPDT">Objeto com os dados novos da Usuarios</param>
        /// <returns></returns>
        [HttpPut("{idUsuarios}")]
        public IActionResult Atualizar(int idUsuarios, Usuario UsuariosUPDT)
        {
            try
            {
                Usuario teste = _UsuariosRepository.BuscarPorID(idUsuarios);
                if (teste != null)
                {
                    _UsuariosRepository.Atualizar(idUsuarios, UsuariosUPDT);

                    return StatusCode(204);
                }

                return NotFound("O Usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Usuarios
        /// </summary>
        /// <param name="idUsuarios">ID da Usuarios a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("{idUsuarios}")]
        public IActionResult Deletar(int idUsuarios)
        {
            try
            {
                Usuario teste = _UsuariosRepository.BuscarPorID(idUsuarios);
                if (teste != null)
                {
                    _UsuariosRepository.Deletar(idUsuarios);

                    return StatusCode(204);
                }

                return NotFound("O Usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
    }
}
