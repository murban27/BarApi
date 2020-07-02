using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Sekce
    {
        public Sekce()
        {
            Item = new HashSet<Item>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
