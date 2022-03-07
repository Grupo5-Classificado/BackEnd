using System;
using System.Collections.Generic;

#nullable disable

namespace LeiloadosWebAPI.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdClassificado { get; set; }

        public virtual Pedido IdClassificadoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
