using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class Todoitem
    {
        public decimal Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreationTs { get; set; }
        public bool? Done { get; set; }
    }
}
