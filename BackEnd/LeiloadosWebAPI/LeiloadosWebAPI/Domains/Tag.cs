using System;
using System.Collections.Generic;

#nullable disable

namespace LeiloadosWebAPI.Domains
{
    public partial class Tag
    {
        public Tag()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdTag { get; set; }
        public string NomeTag { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
