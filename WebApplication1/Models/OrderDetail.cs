using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class OrderDetail
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long? ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Orders Order { get; set; }
    }
}
