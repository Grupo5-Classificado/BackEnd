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
    public class ComentariosController : ControllerBase
    {
        private IComentariosRepository _ComentariosRepository { get; set; }

        public ComentariosController()
        {
            _ComentariosRepository = new ComentariosRepository();

        }

        /// <summary>
        /// Lista as Comentarioss
        /// </summary>
        /// <returns> uma lista de Comentarioss</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            List<Comentario> listaComentarios = _ComentariosRepository.Listar();

            return Ok(listaComentarios);
        }

        /// <summary>
        /// Busca uma Comentarios por ID
        /// </summary>
        /// <param name="idComentarios">O id da Comentarios a ser buscada</param>
        /// <returns>A Comentarios encontrada</returns>
        [HttpGet("{idComentarios}")]
        public IActionResult BuscarPorID(int idComentarios)
        {
            try
            {
                Comentario teste = _ComentariosRepository.BuscarPorID(idComentarios);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("O Comentario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma Comentarios
        /// </summary>
        /// <param name="Comentarios">O objeto com os dados da nova Comentarios</param>
        [HttpPost]
        public IActionResult Cadastrar(Comentario Comentarios)
        {

            try
            {
                _ComentariosRepository.Cadastrar(Comentarios);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma Comentarios existente
        /// </summary>
        /// <param name="idComentarios">id da Comentarios a ser atualizada</param>
        /// <param name="ComentariosUPDT">Objeto com os dados novos da Comentarios</param>
        /// <returns></returns>
        [HttpPut("{idComentarios}")]
        public IActionResult Atualizar(int idComentarios, Comentario ComentariosUPDT)
        {
            try
            {
                Comentario teste = _ComentariosRepository.BuscarPorID(idComentarios);
                if (teste != null)
                {
                    _ComentariosRepository.Atualizar(idComentarios, ComentariosUPDT);

                    return StatusCode(204);
                }

                return NotFound("O Comentario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Comentarios
        /// </summary>
        /// <param name="idComentarios">ID da Comentarios a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("{idComentarios}")]
        public IActionResult Deletar(int idComentarios)
        {
            try
            {
                Comentario teste = _ComentariosRepository.BuscarPorID(idComentarios);
                if (teste != null)
                {
                    _ComentariosRepository.Deletar(idComentarios);

                    return StatusCode(204);
                }

                return NotFound("O Comentario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

    }
}
