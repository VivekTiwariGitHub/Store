using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Application.DTOs.Store
{
    public class CalculateResponse
    {
        public int Price { get; set; }
        public int Weigth { get; set; }
        public int Discount { get; set; }
        public double Total { get; set; }
    }
}
