using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class CashCollectionsEntry
    {
        public string transactionDate { get; set; }
        public string customerName { get; set; }
        public double collectionAmount { get; set; }
        public string transactionRemarks { get; set; }
        public string userName { get; set; }
    }
}