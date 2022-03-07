using LeiloadosWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Interfaces
{
    interface IReservaRepository
    {
        void Cadastrar(Reserva reserva);

        void Deletar(int idReserva);

        List<Reserva> ListarMinhas(int idUsuario);

        Reserva BurcarPorId(int idReserva);
    }
}
