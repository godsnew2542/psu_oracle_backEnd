using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Papertable
    {
        public decimal UId { get; set; }
        public string Evidence { get; set; }
        public DateTime? Evidencedate { get; set; }

        public virtual Usertable UIdNavigation { get; set; }
    }
}
