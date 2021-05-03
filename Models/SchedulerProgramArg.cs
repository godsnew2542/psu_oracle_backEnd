using System;
using System.Collections.Generic;

#nullable disable

namespace psu_oracle_backEnd.Models
{
    public partial class SchedulerProgramArg
    {
        public string Owner { get; set; }
        public string ProgramName { get; set; }
        public string ArgumentName { get; set; }
        public decimal ArgumentPosition { get; set; }
        public string ArgumentType { get; set; }
        public string MetadataAttribute { get; set; }
        public string DefaultValue { get; set; }
        public string OutArgument { get; set; }
    }
}
