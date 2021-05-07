using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Paymenttable
    {
        public decimal KPaymentt { get; set; }
        public decimal? UId { get; set; }
        public decimal? Loanamount { get; set; }
        public string Batch { get; set; }
        public decimal? Batchamount { get; set; }
        public decimal? Lastpaid { get; set; }
        public string Timepaid { get; set; }
        public decimal? Total { get; set; }
        public decimal? Balance { get; set; }
    }
}
