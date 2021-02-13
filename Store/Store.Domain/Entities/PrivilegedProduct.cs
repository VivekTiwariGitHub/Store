using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Entities
{
    public class PrivilegedProduct : Product
    {
        public int Discount { get; set; }
    }
}
