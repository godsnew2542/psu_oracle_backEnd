using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class AqInternetAgent
    {
        public string AgentName { get; set; }
        public decimal Protocol { get; set; }
        public string Spare1 { get; set; }
    }
}
