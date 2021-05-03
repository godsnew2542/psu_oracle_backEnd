using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class AqQueueTable
    {
        public string Schema { get; set; }
        public string Name { get; set; }
        public decimal UdataType { get; set; }
        public decimal Objno { get; set; }
        public decimal Flags { get; set; }
        public decimal SortCols { get; set; }
        public string Timezone { get; set; }
        public string TableComment { get; set; }
    }
}
