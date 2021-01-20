using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracking
{
   public abstract class Asset
    {
        public string Model { get; set; }
        public string Price { get; set; }
        public DateTime DateTime { get; set; }
        public bool ExpiryProduct { get; set; }
        public string Currency { get; set; }
        public double GetPrice { get; set; }
    }
}
