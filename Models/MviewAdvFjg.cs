using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class MviewAdvFjg
    {
        public decimal Fjgid { get; set; }
        public decimal Ajgid { get; set; }
        public decimal Fjgdeslen { get; set; }
        public byte[] Fjgdes { get; set; }
        public decimal Hashvalue { get; set; }
        public decimal? Frequency { get; set; }

        public virtual MviewAdvAjg Ajg { get; set; }
    }
}
