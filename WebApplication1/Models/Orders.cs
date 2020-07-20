using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public long TableId { get; set; }
        [JsonIgnore]
        public virtual Tabless Table { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
