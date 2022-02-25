using System;
using System.Collections.Generic;

#nullable disable

namespace LeiloadosWebAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentarios = new HashSet<Comentario>();
            Pedidos = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? Popularidade { get; set; }
        public byte[] BinarioImg { get; set; }
        public int? Telefone { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
