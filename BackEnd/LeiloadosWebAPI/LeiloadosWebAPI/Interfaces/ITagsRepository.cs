using LeiloadosWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de tags
    /// </summary>
    interface ITagsRepository
    {
        /// <summary>
        /// Lista todas as Tags
        /// </summary>
        /// <returns>Uma lista de Tags</returns>
        List<Tag> Listar();

        /// <summary>
        /// Busca uma Tag a partir de um ID
        /// </summary>
        /// <param name="idTag">ID da Tag a ser buscada</param>
        /// <returns>Uma Tag encontrada</returns>
        Tag BuscarPorID(int idTag);

        /// <summary>
        /// Cadastra uma nova Tag
        /// </summary>
        /// <param name="NovaTag">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Tag NovaTag);

        /// <summary>
        /// Atualiza os dados de uma Tag
        /// </summary>
        /// <param name="idTag">ID da Tag a ser atualizada</param>
        /// <param name="TagU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idTag, Tag TagU);

        /// <summary>
        /// Deleta uma Tag
        /// </summary>
        /// <param name="idTag">ID da Tag a ser deletada</param>
        void Deletar(int idTag);
    }
}
