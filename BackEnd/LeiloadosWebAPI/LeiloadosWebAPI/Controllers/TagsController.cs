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
    public class TagsController : ControllerBase
    {
        private ITagsRepository _TagsRepository { get; set; }

        public TagsController()
        {
            _TagsRepository = new TagsRepository();

        }

        /// <summary>
        /// Lista as Tagss
        /// </summary>
        /// <returns> uma lista de Tagss</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            List<Tag> listaTags = _TagsRepository.Listar();

            return Ok(listaTags);
        }

        /// <summary>
        /// Busca uma Tags por ID
        /// </summary>
        /// <param name="idTags">O id da Tags a ser buscada</param>
        /// <returns>A Tags encontrada</returns>
        [HttpGet("{idTags}")]
        public IActionResult BuscarPorID(int idTags)
        {
            try
            {
                Tag teste = _TagsRepository.BuscarPorID(idTags);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A Tag não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma Tags
        /// </summary>
        /// <param name="Tags">O objeto com os dados da nova Tags</param>
        [HttpPost]
        public IActionResult Cadastrar(Tag Tags)
        {

            try
            {
                _TagsRepository.Cadastrar(Tags);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma Tags existente
        /// </summary>
        /// <param name="idTags">id da Tags a ser atualizada</param>
        /// <param name="TagsUPDT">Objeto com os dados novos da Tags</param>
        /// <returns></returns>
        [HttpPut("{idTags}")]
        public IActionResult Atualizar(int idTags, Tag TagsUPDT)
        {
            try
            {
                Tag teste = _TagsRepository.BuscarPorID(idTags);
                if (teste != null)
                {
                    _TagsRepository.Atualizar(idTags, TagsUPDT);

                    return StatusCode(204);
                }

                return NotFound("A Tag não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Tags
        /// </summary>
        /// <param name="idTags">ID da Tags a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("{idTags}")]
        public IActionResult Deletar(int idTags)
        {
            try
            {
                Tag teste = _TagsRepository.BuscarPorID(idTags);
                if (teste != null)
                {
                    _TagsRepository.Deletar(idTags);

                    return StatusCode(204);
                }

                return NotFound("A Tag não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
    }
}
