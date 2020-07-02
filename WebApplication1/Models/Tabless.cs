using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Tabless
    {
        public Tabless()
        {
            Orders = new HashSet<Orders>();
        }

        public long Id { get; set; }
        public int? Capacity { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
