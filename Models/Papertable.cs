using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Papertable
    {
        public decimal KPaper { get; set; }
        public decimal? UId { get; set; }
        public string Evidence { get; set; }
        public DateTime? Evidencedate { get; set; }
    }
}
