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
    public class ComentariosRepository : IComentariosRepository
    {
        LeiloadosContext ctx = new LeiloadosContext();

        public void Atualizar(int idComentario, Comentario ComentarioU)
        {
            Comentario ComentarioBuscado = ctx.Comentarios.Find(idComentario);

            ctx.Comentarios.Update(ComentarioBuscado);

            ctx.SaveChanges();
        }

        public Comentario BuscarPorID(int idComentario)
        {
            return ctx.Comentarios.FirstOrDefault(c => c.IdComentario == idComentario);
        }

        public void Cadastrar(Comentario NovoComentario)
        {
            ctx.Comentarios.Add(NovoComentario);

            ctx.SaveChanges();
        }

        public void Deletar(int idComentario)
        {
            Comentario ComentarioBuscado = BuscarPorID(idComentario);

            ctx.Comentarios.Remove(ComentarioBuscado);

            ctx.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            return ctx.Comentarios.Include(x => x.IdClassificadoNavigation).Include(y => y.IdUsuarioNavigation).ToList();
        }
    }
}
