using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class MviewAdvLevel
    {
        public decimal Runid { get; set; }
        public decimal Levelid { get; set; }
        public decimal? Dimobj { get; set; }
        public decimal Flags { get; set; }
        public decimal Tblobj { get; set; }
        public byte[] Columnlist { get; set; }
        public string Levelname { get; set; }

        public virtual MviewAdvLog Run { get; set; }
    }
}
