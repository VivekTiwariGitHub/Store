using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Store.Application.DTOs.Store
{
    public class StoreResponse
    {
        public int Price { get; set; }
        public int Weigth { get; set; }
        public int Discount { get; set; }
    }
}
