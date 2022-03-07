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
            Reservas = new HashSet<Reserva>();
        }

        public int IdPedido { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTag { get; set; }
        public string Pedido1 { get; set; }
        public string Titulo { get; set; }

        public virtual Tag IdTagNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
