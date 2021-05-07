using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Problemtable
    {
        public decimal KProblem { get; set; }
        public decimal? UId { get; set; }
        public string Detail { get; set; }
        public string Surety { get; set; }
        public string Loantype { get; set; }
    }
}
