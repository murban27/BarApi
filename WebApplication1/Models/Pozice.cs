using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Pozice
    {
        public Pozice()
        {
            Login = new HashSet<Login>();
        }

        public long Id { get; set; }
        public long? Name { get; set; }

        public virtual ICollection<Login> Login { get; set; }
    }
}
