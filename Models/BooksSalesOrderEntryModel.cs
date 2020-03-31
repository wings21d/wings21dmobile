using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class BooksSalesOrderEntry
    {
        public string transactionDate { get; set; }
        public string customerName { get; set; }
        public string productName { get; set; }
        public int quantity{ get; set; }
        public string transactionRemarks { get; set; }
        public string userName { get; set; }
    }
}