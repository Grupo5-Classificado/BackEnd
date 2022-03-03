using System;
using System.Collections.Generic;

#nullable disable

namespace LeiloadosWebAPI.Domains
{
    public partial class Comentario
    {
        public int IdComentario { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdClassificado { get; set; }
        public string Comentario1 { get; set; }
        public byte[] BinarioImg { get; set; }
        public int Reservado { get; set; }

        public virtual Pedido IdClassificadoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
