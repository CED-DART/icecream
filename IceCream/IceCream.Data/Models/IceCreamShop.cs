using System;
using System.Collections.Generic;

namespace IceCream.Data.Models
{
    public partial class IceCreamShop
    {
        public int IceCreamShop1 { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal? AveragePrice { get; set; }
        public string PaymentMethods { get; set; }
        public DateTime Created { get; set; }
    }
}
