using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class MviewAdvAjg
    {
        public MviewAdvAjg()
        {
            MviewAdvFjgs = new HashSet<MviewAdvFjg>();
        }

        public decimal Ajgid { get; set; }
        public decimal Runid { get; set; }
        public decimal Ajgdeslen { get; set; }
        public byte[] Ajgdes { get; set; }
        public decimal Hashvalue { get; set; }
        public decimal? Frequency { get; set; }

        public virtual MviewAdvLog Run { get; set; }
        public virtual ICollection<MviewAdvFjg> MviewAdvFjgs { get; set; }
    }
}
