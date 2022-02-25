using LeiloadosWebAPI.Contexts;
using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
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

            if (ComentarioU.Comentario1 != null) { ComentarioBuscado.Comentario1 = ComentarioU.Comentario1; }
            if (ComentarioU.BinarioImg != null) { ComentarioBuscado.BinarioImg = ComentarioU.BinarioImg; }

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
            return ctx.Comentarios.ToList();
        }
    }
}
