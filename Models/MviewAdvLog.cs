using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class MviewAdvLog
    {
        public MviewAdvLog()
        {
            MviewAdvAjgs = new HashSet<MviewAdvAjg>();
            MviewAdvLevels = new HashSet<MviewAdvLevel>();
        }

        public decimal Runid { get; set; }
        public decimal? Filterid { get; set; }
        public DateTime? RunBegin { get; set; }
        public DateTime? RunEnd { get; set; }
        public decimal? RunType { get; set; }
        public string Uname { get; set; }
        public decimal Status { get; set; }
        public string Message { get; set; }
        public decimal? Completed { get; set; }
        public decimal? Total { get; set; }
        public string ErrorCode { get; set; }

        public virtual ICollection<MviewAdvAjg> MviewAdvAjgs { get; set; }
        public virtual ICollection<MviewAdvLevel> MviewAdvLevels { get; set; }
    }
}
