using LeiloadosWebAPI.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de pedidos
    /// </summary>
    interface IPedidosRepository
    {

        /// <summary>
        /// Lista todos os Pedidos
        /// </summary>
        /// <returns>Uma lista de Pedidos</returns>
        List<Pedido> Listar();

        /// <summary>
        /// Busca um Pedido a partir de um ID
        /// </summary>
        /// <param name="idPedido">ID do Pedido a ser buscado</param>
        /// <returns>Um Pedido encontrado</returns>
        Pedido BuscarPorID(int idPedido);

        /// <summary>
        /// Cadastra um novo Pedido
        /// </summary>
        /// <param name="NovoPedido">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Pedido NovoPedido);

        /// <summary>
        /// Atualiza os dados de um Pedido
        /// </summary>
        /// <param name="idPedido">ID do Pedido a ser atualizado</param>
        /// <param name="PedidoU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idPedido, Pedido PedidoU);

        /// <summary>
        /// Deleta um Pedido
        /// </summary>
        /// <param name="idPedido">ID da Pedido a ser deletado</param>
        void Deletar(int idPedido);
    }
}
