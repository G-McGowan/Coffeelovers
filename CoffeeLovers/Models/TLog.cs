using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeLovers.Models
{
    public partial class TLog
    {
        public int LogId { get; set; }
        public string LogDetail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
