using System;
using System.Collections.Generic;
using System.Text;

namespace SeekAd.Data.Models
{
    public class Deal
    {
        public string CustomerName { get; set; }
        public string AdCode { get; set; }
        public DiscountType DiscountType { get; set; }
        public int PurchaseSize { get; set; }
        public int CostSize { get; set; }
        public double Discount { get; set; }
        public string Operator { get; set; } // possible values >, <, >=, == etc
        public int Priority { get; set; }
    }
}
