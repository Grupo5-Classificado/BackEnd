using LeiloadosWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de comentários
    /// </summary>
    interface IComentariosRepository
    {

        /// <summary>
        /// Lista todos os Comentarios
        /// </summary>
        /// <returns>Uma lista de Comentarios</returns>
        List<Comentario> Listar();

        /// <summary>
        /// Busca um Comentario a partir de um ID
        /// </summary>
        /// <param name="idComentario">ID do Comentario a ser buscado</param>
        /// <returns>Um Comentario encontrado</returns>
        Comentario BuscarPorID(int idComentario);

        /// <summary>
        /// Cadastra um novo Comentario
        /// </summary>
        /// <param name="NovoComentario">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Comentario NovoComentario);

        /// <summary>
        /// Atualiza os dados de um Comentario
        /// </summary>
        /// <param name="idComentario">ID do Comentario a ser atualizado</param>
        /// <param name="ComentarioU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idComentario, Comentario ComentarioU);

        /// <summary>
        /// Deleta um Comentario
        /// </summary>
        /// <param name="idComentario">ID da Comentario a ser deletado</param>
        void Deletar(int idComentario);
    }
}
