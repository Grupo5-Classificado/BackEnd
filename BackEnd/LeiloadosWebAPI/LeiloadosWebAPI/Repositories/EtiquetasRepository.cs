using LeiloadosWebAPI.Contexts;
using LeiloadosWebAPI.Domains;
using LeiloadosWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeiloadosWebAPI.Repositories
{
    public class EtiquetasRepository : IEtiquetasRepository
    {
        LeiloadosContext ctx = new LeiloadosContext();

        public void Atualizar(int idEtiqueta, Etiqueta EtiquetaU)
        {
            Etiqueta EtiquetaBuscada = ctx.Etiquetas.Find(idEtiqueta);

            if (EtiquetaU.IdClassificado != null) { EtiquetaBuscada.IdClassificado = EtiquetaU.IdClassificado; }
            if (EtiquetaU.IdTag != null) { EtiquetaBuscada.IdTag = EtiquetaU.IdTag; }

            ctx.Etiquetas.Update(EtiquetaBuscada);  

            ctx.SaveChanges();
        }

        public Etiqueta BuscarPorID(int idEtiqueta)
        {
            return ctx.Etiquetas.FirstOrDefault(c => c.IdEtiqueta == idEtiqueta);
        }

        public void Cadastrar(Etiqueta NovaEtiqueta)
        {
            ctx.Etiquetas.Add(NovaEtiqueta);

            ctx.SaveChanges();
        }

        public void Deletar(int idEtiqueta)
        {
            Etiqueta EtiquetaBuscada = BuscarPorID(idEtiqueta);

            ctx.Etiquetas.Remove(EtiquetaBuscada);

            ctx.SaveChanges();
        }

        public List<Etiqueta> Listar()
        {
            return ctx.Etiquetas.ToList();
        }
    }
}
