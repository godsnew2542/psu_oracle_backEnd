using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Marriagetable
    {
        public decimal KMarriage { get; set; }
        public decimal? UId { get; set; }
        public string MFname { get; set; }
        public string MLname { get; set; }
        public string MTel { get; set; }
        public string MPhone { get; set; }
        public decimal? MSalary { get; set; }
    }
}
