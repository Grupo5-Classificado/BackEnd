using LeiloadosWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de intermediação de tags e pedidos
    /// </summary>
    interface IEtiquetasRepository
    {
        /// <summary>
        /// Lista todas as Etiquetas
        /// </summary>
        /// <returns>Uma lista de Etiquetas</returns>
        List<Etiqueta> Listar();

        /// <summary>
        /// Busca uma Etiqueta a partir de um ID
        /// </summary>
        /// <param name="idEtiqueta">ID da Etiqueta a ser buscada</param>
        /// <returns>Uma Etiqueta encontrada</returns>
        Etiqueta BuscarPorID(int idEtiqueta);

        /// <summary>
        /// Cadastra uma nova Etiqueta
        /// </summary>
        /// <param name="NovaEtiqueta">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Etiqueta NovaEtiqueta);

        /// <summary>
        /// Atualiza os dados de uma Etiqueta
        /// </summary>
        /// <param name="idEtiqueta">ID da Etiqueta a ser atualizada</param>
        /// <param name="EtiquetaU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idEtiqueta, Etiqueta EtiquetaU);

        /// <summary>
        /// Deleta uma Etiqueta
        /// </summary>
        /// <param name="idEtiqueta">ID da Etiqueta a ser deletada</param>
        void Deletar(int idEtiqueta);
    }
}
