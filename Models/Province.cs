using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Province
    {
        public decimal Id { get; set; }
        public string Code { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public decimal GeographyId { get; set; }
    }
}
