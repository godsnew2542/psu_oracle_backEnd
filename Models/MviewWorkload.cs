using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class MviewWorkload
    {
        public decimal Workloadid { get; set; }
        public DateTime ImportTime { get; set; }
        public decimal Queryid { get; set; }
        public string Application { get; set; }
        public decimal? Cardinality { get; set; }
        public decimal? Resultsize { get; set; }
        public DateTime? Lastuse { get; set; }
        public decimal? Frequency { get; set; }
        public string Owner { get; set; }
        public decimal? Priority { get; set; }
        public string Query { get; set; }
        public decimal? Responsetime { get; set; }
    }
}
