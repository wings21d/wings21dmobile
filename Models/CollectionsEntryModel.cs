using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class CollectionsEntry
    {
        public string transactionDate { get; set; }
        public string customerName { get; set; }
        public double cashAmount { get; set; }
        public double chequeAmount { get; set; }
        public double chequeNumber { get; set; }
        public string transactionRemarks { get; set; }
        public string userName { get; set; }
        public string documentNo { get; set; }
    }
}