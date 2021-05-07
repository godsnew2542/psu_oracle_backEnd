using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Usertable
    {
        public decimal UId { get; set; }
        public string UTitle { get; set; }
        public string UFname { get; set; }
        public string ULname { get; set; }
        public string UPosition { get; set; }
        public string UType { get; set; }
        public string USalaryid { get; set; }
        public string UStartdate { get; set; }
        public decimal? USalary { get; set; }
        public decimal? ULoan { get; set; }
        public string UAffiliation { get; set; }
        public string UTel { get; set; }
        public string UPhone { get; set; }
        public string UStatus { get; set; }
        public string UDivision { get; set; }
    }
}
