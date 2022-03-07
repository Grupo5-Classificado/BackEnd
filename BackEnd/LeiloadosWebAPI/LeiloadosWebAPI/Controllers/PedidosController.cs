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
    public class PedidosController : ControllerBase
    {
            private IPedidosRepository _PedidosRepository { get; set; }

            public PedidosController()
            {
                _PedidosRepository = new PedidosRepository();

            }

            /// <summary>
            /// Lista as Pedidoss
            /// </summary>
            /// <returns> uma lista de Pedidoss</returns>
            [HttpGet]
            public IActionResult Listar()
            {
                List<Pedido> listaPedidos = _PedidosRepository.Listar();

                return Ok(listaPedidos);
            }

            /// <summary>
            /// Busca uma Pedidos por ID
            /// </summary>
            /// <param name="idPedidos">O id da Pedidos a ser buscada</param>
            /// <returns>A Pedidos encontrada</returns>
            [HttpGet("{idPedidos}")]
            public IActionResult BuscarPorID(int idPedidos)
            {
                try
                {
                    Pedido teste = _PedidosRepository.BuscarPorID(idPedidos);
                    if (teste != null)
                    {
                        return Ok(teste);
                    }
                    return NotFound("O Pedido não foi encontrado :P");
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }

            }

        /// <summary>
        /// Cadastra uma Pedidos
        /// </summary>
        /// <param name="Pedidos">O objeto com os dados da nova Pedidos</param>
        [HttpPost]
            public IActionResult Cadastrar(Pedido Pedidos)
            {

                try
                {
                    _PedidosRepository.Cadastrar(Pedidos);

                    return StatusCode(201);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }

            }

            /// <summary>
            /// Atualiza uma Pedidos existente
            /// </summary>
            /// <param name="idPedidos">id da Pedidos a ser atualizada</param>
            /// <param name="PedidosUPDT">Objeto com os dados novos da Pedidos</param>
            /// <returns></returns>
            [HttpPut("{idPedidos}")]
            public IActionResult Atualizar(int idPedidos, Pedido PedidosUPDT)
            {
                try
                {
                    Pedido teste = _PedidosRepository.BuscarPorID(idPedidos);
                    if (teste != null)
                    {
                        _PedidosRepository.Atualizar(idPedidos, PedidosUPDT);

                        return StatusCode(204);
                    }

                    return NotFound("O Pedido não foi encontrado :P");
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            /// <summary>
            /// Deleta uma Pedidos
            /// </summary>
            /// <param name="idPedidos">ID da Pedidos a ser deletada</param>
            /// <returns></returns>
            [HttpDelete("{idPedidos}")]
            public IActionResult Deletar(int idPedidos)
            {
                try
                {
                    Pedido teste = _PedidosRepository.BuscarPorID(idPedidos);
                    if (teste != null)
                    {
                        _PedidosRepository.Deletar(idPedidos);

                        return StatusCode(204);
                    }

                    return NotFound("O Pedido não foi encontrado :P");
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }

            }
    }
}
