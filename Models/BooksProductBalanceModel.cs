using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings21D.Models
{
    public class BooksProductBalance
    {
        public string productName { get; set; }
        public string locationName { get; set; }
        public double availableQtyInPieces { get; set; }
    }
}