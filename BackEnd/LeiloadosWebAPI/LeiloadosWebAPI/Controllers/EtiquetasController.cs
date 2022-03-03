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
    public class EtiquetasController : ControllerBase
    {
        private IEtiquetasRepository _EtiquetasRepository { get; set; }

        public EtiquetasController()
        {
            _EtiquetasRepository = new EtiquetasRepository();

        }

        /// <summary>
        /// Lista as Etiquetass
        /// </summary>
        /// <returns> uma lista de Etiquetass</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            List<Etiqueta> listaEtiquetas = _EtiquetasRepository.Listar();

            return Ok(listaEtiquetas);
        }

        /// <summary>
        /// Busca uma Etiquetas por ID
        /// </summary>
        /// <param name="idEtiquetas">O id da Etiquetas a ser buscada</param>
        /// <returns>A Etiquetas encontrada</returns>
        [HttpGet("{idEtiquetas}")]
        public IActionResult BuscarPorID(int idEtiquetas)
        {
            try
            {
                Etiqueta teste = _EtiquetasRepository.BuscarPorID(idEtiquetas);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A Etiqueta não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma Etiquetas
        /// </summary>
        /// <param name="Etiquetas">O objeto com os dados da nova Etiquetas</param>
        [HttpPost]
        public IActionResult Cadastrar(Etiqueta Etiquetas)
        {

            try
            {
                _EtiquetasRepository.Cadastrar(Etiquetas);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma Etiquetas existente
        /// </summary>
        /// <param name="idEtiquetas">id da Etiquetas a ser atualizada</param>
        /// <param name="EtiquetasUPDT">Objeto com os dados novos da Etiquetas</param>
        /// <returns></returns>
        [HttpPut("{idEtiquetas}")]
        public IActionResult Atualizar(int idEtiquetas, Etiqueta EtiquetasUPDT)
        {
            try
            {
                Etiqueta teste = _EtiquetasRepository.BuscarPorID(idEtiquetas);
                if (teste != null)
                {
                    _EtiquetasRepository.Atualizar(idEtiquetas, EtiquetasUPDT);

                    return StatusCode(204);
                }

                return NotFound("A Etiqueta não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Etiquetas
        /// </summary>
        /// <param name="idEtiquetas">ID da Etiquetas a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("{idEtiquetas}")]
        public IActionResult Deletar(int idEtiquetas)
        {
            try
            {
                Etiqueta teste = _EtiquetasRepository.BuscarPorID(idEtiquetas);
                if (teste != null)
                {
                    _EtiquetasRepository.Deletar(idEtiquetas);

                    return StatusCode(204);
                }

                return NotFound("A Etiqueta não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
    }
}
