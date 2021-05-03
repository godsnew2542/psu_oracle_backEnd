using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class AqInternetAgentPriv
    {
        public string AgentName { get; set; }
        public string DbUsername { get; set; }

        public virtual AqInternetAgent AgentNameNavigation { get; set; }
    }
}
