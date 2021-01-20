using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracking
{
    class Asset
    {
        /*   public class Office
           { } */
        public string Brand { get; set; }
        public string Model { get; set; }       
        public DateTime PurchaseDate { get; set; }
        public Office Office { get ; set ; }
        public double PurchasePrice { get; set; }
        public string Currency { get; set; }
        public double CurrencyRate { get; set; }
    }
}
