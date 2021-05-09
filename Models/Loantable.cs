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
        public DateTime? Loandate { get; set; }
        public DateTime? Confirmdate { get; set; }
        public DateTime? Depositdate { get; set; }
        public decimal? SmId { get; set; }
        public decimal? UmId { get; set; }
        public string LStatus { get; set; }
    }
}
