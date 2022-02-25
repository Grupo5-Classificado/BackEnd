using LeiloadosWebAPI.Contexts;
using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        LeiloadosContext ctx = new LeiloadosContext();
        public void Atualizar(int idTag, Tag TagU)
        {
            Tag TagBuscada = ctx.Tags.Find(idTag);

            if (TagU.NomeTag != null) { TagBuscada.NomeTag = TagU.NomeTag; }

            ctx.Tags.Update(TagBuscada);

            ctx.SaveChanges();
        }

        public Tag BuscarPorID(int idTag)
        {
            return ctx.Tags.FirstOrDefault(c => c.IdTag == idTag);
        }

        public void Cadastrar(Tag NovaTag)
        {
            ctx.Tags.Add(NovaTag);

            ctx.SaveChanges();
        }

        public void Deletar(int idTag)
        {
            Tag tagBuscada = BuscarPorID(idTag);

            ctx.Tags.Remove(tagBuscada);

            ctx.SaveChanges();
        }

        public List<Tag> Listar()
        {
            return ctx.Tags.ToList();
        }
    }
}
