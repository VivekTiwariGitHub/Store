using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.DTOs.Store
{
    public class StoreRequest
    {
        public int Price { get; set; }
        public int Weigth { get; set; }
        public int Discount { get; set; }
    }
}
