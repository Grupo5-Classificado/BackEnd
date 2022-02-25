using LeiloadosWebAPI.Contexts;
using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        LeiloadosContext ctx = new LeiloadosContext();

        public void Atualizar(int idPedido, Pedido PedidoU)
        {
            Pedido PedidoBuscado = ctx.Pedidos.Find(idPedido);

            if (PedidoU.Pedido1 != null) { PedidoBuscado.Pedido1 = PedidoU.Pedido1; }
            if (PedidoU.Titulo != null) { PedidoBuscado.Titulo = PedidoU.Titulo; }


            ctx.Pedidos.Update(PedidoBuscado);

            ctx.SaveChanges();
        }

        public Pedido BuscarPorID(int idPedido)
        {
            return ctx.Pedidos.FirstOrDefault(c => c.IdPedido == idPedido);
        }

        public void Cadastrar(Pedido NovoPedido)
        {
            ctx.Pedidos.Add(NovoPedido);

            ctx.SaveChanges();
        }

        public void Deletar(int idPedido)
        {
            Pedido PedidoBuscado = BuscarPorID(idPedido);

            ctx.Pedidos.Remove(PedidoBuscado);

            ctx.SaveChanges();
        }

        public List<Pedido> Listar()
        {
            return ctx.Pedidos.ToList();
        }
    }
}
