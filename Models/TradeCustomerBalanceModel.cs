using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class TradeCustomerBalance
    {
        public string customerName { get; set; }
        public string billNumber { get; set; }
        public string billDate { get; set; }
        public double pendingValue { get; set; }
    }
}