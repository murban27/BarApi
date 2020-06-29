using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Vat
    {
        public Vat()
        {
            Item = new HashSet<Item>();
        }

        public int VatId { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
