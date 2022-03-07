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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private IReservaRepository _reservaRepository { get; set; }

        public ReservasController()
        {
            _reservaRepository = new ReservaRepository();
        }

        [HttpGet("listarMinhas/{idUsuario}")]
        public IActionResult ListarMinhas(int idUsuario)
        {

            return Ok(_reservaRepository.ListarMinhas(idUsuario));
        }

        [HttpPost]
        public IActionResult Cadastrar(Reserva reserva)
        {
            try
            {
                _reservaRepository.Cadastrar(reserva);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idReserva}")]
        public IActionResult Deletar(int idReserva)
        {
            try
            {
                Reserva reserva = _reservaRepository.BurcarPorId(idReserva);

                if (reserva != null)
                {
                    _reservaRepository.Deletar(idReserva);
                    return StatusCode(204);
                }

                return NotFound("O Pedido não foi encontrado");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

    }
}
