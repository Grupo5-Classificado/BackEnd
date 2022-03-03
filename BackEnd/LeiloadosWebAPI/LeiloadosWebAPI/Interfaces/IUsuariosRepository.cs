using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de usuários
    /// </summary>
    interface IUsuariosRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um Usuario a partir de um ID
        /// </summary>
        /// <param name="idUsuario">ID do Usuario a ser buscado</param>
        /// <returns>Um Usuario encontrado</returns>
        Usuario BuscarPorID(int idUsuario);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="NovoUsuario">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Usuario NovoUsuario);

        /// <summary>
        /// Atualiza os dados de um Usuario
        /// </summary>
        /// <param name="idUsuario">ID do Usuario a ser atualizado</param>
        /// <param name="UsuarioU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idUsuario, Usuario UsuarioU);

        /// <summary>
        /// Deleta um Usuario
        /// </summary>
        /// <param name="idUsuario">ID da Usuario a ser deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Loga o usuário
        /// </summary>
        /// <param name="cred">Credenciais de login</param>
        Usuario login(LoginViewModel cred);

    }
}
