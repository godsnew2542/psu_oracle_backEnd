using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Help
    {
        public string Topic { get; set; }
        public decimal Seq { get; set; }
        public string Info { get; set; }
    }
}
