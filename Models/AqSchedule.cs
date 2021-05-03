using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class AqSchedule
    {
        public Guid Oid { get; set; }
        public string Destination { get; set; }
        public DateTime? StartTime { get; set; }
        public string Duration { get; set; }
        public string NextTime { get; set; }
        public string Latency { get; set; }
        public DateTime? LastTime { get; set; }
        public decimal? Jobno { get; set; }
    }
}
