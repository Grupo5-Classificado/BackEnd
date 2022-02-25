using System;
using System.Collections.Generic;

#nullable disable

namespace LeiloadosWebAPI.Domains
{
    public partial class Pedido
    {
        public Pedido()
        {
            Comentarios = new HashSet<Comentario>();
            Etiqueta = new HashSet<Etiqueta>();
        }

        public int IdPedido { get; set; }
        public int? IdUsuario { get; set; }
        public string Pedido1 { get; set; }
        public string Titulo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Etiqueta> Etiqueta { get; set; }
    }
}
