using LeiloadosWebAPI.Contexts;
using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
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
    }
}
