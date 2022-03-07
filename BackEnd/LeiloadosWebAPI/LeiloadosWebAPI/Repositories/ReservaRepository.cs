using LeiloadosWebAPI.Contexts;
using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        LeiloadosContext ctx = new LeiloadosContext();

        public Reserva BurcarPorId(int idReserva)
        {
            return ctx.Reservas.Include(x => x.IdUsuarioNavigation).Include(y => y.IdClassificadoNavigation).FirstOrDefault(c => c.IdReserva == idReserva);
        }

        public void Cadastrar(Reserva reserva)
        {
            ctx.Reservas.Add(reserva);
            ctx.SaveChanges();
        }

        public void Deletar(int idReserva)
        {
            Reserva reservaBuscada = BurcarPorId(idReserva);

            ctx.Reservas.Remove(reservaBuscada);

            ctx.SaveChanges();
        }

        public List<Reserva> ListarMinhas(int idUsuario)
        {
            return ctx.Reservas.Include(x => x.IdUsuarioNavigation).Include(y => y.IdClassificadoNavigation).Where(x => x.IdUsuario == idUsuario).ToList();
        }
    }
}
