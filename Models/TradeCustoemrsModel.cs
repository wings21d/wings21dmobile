using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class TradeCustomers
    {
        public string customerName { get; set; }
        public string beatName { get; set; }
        public string profitCenterName { get; set; }
        public string gstNumber { get; set; }
        public string customerCity { get; set; }
        public int activeStatus { get; set; }
    }
}