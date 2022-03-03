using LeiloadosWebAPI.Contexts;
using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
using LeiloadosWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        LeiloadosContext ctx = new LeiloadosContext();
        public void Atualizar(int idUsuario, Usuario UsuarioU)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(idUsuario);

            if (UsuarioU.NomeUsuario != null) { UsuarioBuscado.NomeUsuario = UsuarioU.NomeUsuario; }
            if (UsuarioU.Email != null) { UsuarioBuscado.Email = UsuarioU.Email; }
            if (UsuarioU.Senha != null) { UsuarioBuscado.Senha = UsuarioU.Senha; }
            if (UsuarioU.Telefone != null) { UsuarioBuscado.Telefone = UsuarioU.Telefone; }
            if (UsuarioU.BinarioImg != null) { UsuarioBuscado.BinarioImg = UsuarioU.BinarioImg; }

            ctx.Usuarios.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorID(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            NovoUsuario.Senha = BCrypt.Net.BCrypt.HashPassword(NovoUsuario.Senha);


            ctx.Usuarios.Add(NovoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorID(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario login(LoginViewModel cred)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == cred.Email);

            if (usuario != null)
            {
                   if(usuario.Senha == cred.Senha)
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(cred.Senha);

                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();

                    return usuario;
                }

                // Com o usuário encontrado, temos a hash da senha para poder comparar com a nova entrada pelo input de senha
                var comparado = BCrypt.Net.BCrypt.Verify(cred.Senha, usuario.Senha);
                if (comparado)
                {
                    return usuario;
                }
            }

            return null;
        }
    }
}
