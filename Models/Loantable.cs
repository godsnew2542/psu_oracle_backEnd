using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Loantable
    {
        public decimal KLoan { get; set; }
        public decimal? UId { get; set; }
        public string Loantype { get; set; }
        public decimal? Loanamount { get; set; }
        public decimal? SId { get; set; }
        public string Loandate { get; set; }
        public string Confirmdate { get; set; }
        public string Depositdate { get; set; }
        public decimal? SmId { get; set; }
        public decimal? UmId { get; set; }
        public string LStatus { get; set; }
    }
}
