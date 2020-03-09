using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class TradeItems
    {
        public string itemName { get; set; }
        public string productName { get; set; }
        public string hsnsac { get; set; }
        public string profitCenterName { get; set; }
        public double rateperpiece { get; set; }
        public double rateperpack { get; set; }
        public string gstrate { get; set; }
        public int piecesperpack { get; set; }
        public double itemmrp { get; set; }
        public int activeStatus { get; set; }
    }
}