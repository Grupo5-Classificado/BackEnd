using System;
using System.Collections.Generic;

#nullable disable

namespace LeiloadosWebAPI.Domains
{
    public partial class Tag
    {
        public Tag()
        {
            Etiqueta = new HashSet<Etiqueta>();
        }

        public int IdTag { get; set; }
        public string NomeTag { get; set; }

        public virtual ICollection<Etiqueta> Etiqueta { get; set; }
    }
}
