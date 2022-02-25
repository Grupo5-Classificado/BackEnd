using System;
using System.Collections.Generic;

#nullable disable

namespace LeiloadosWebAPI.Domains
{
    public partial class Etiqueta
    {
        public int IdEtiqueta { get; set; }
        public int? IdTag { get; set; }
        public int? IdClassificado { get; set; }

        public virtual Pedido IdClassificadoNavigation { get; set; }
        public virtual Tag IdTagNavigation { get; set; }
    }
}
