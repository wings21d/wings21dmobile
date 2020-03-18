using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class TradeItemBalance
    {
        public string itemName { get; set; }
        public string locationName { get; set; }
        public double availableQtyInPieces { get; set; }
    }
}