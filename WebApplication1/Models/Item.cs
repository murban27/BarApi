using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Item
    {
        public Item()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long ItemId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public long SectionId { get; set; }
        public int VatId { get; set; }

        public virtual Sekce Section { get; set; }
        public virtual Vat Vat { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
