using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracking
{
    class Phone : Asset // inheritance
    {     public Phone(string model, string price, double getPrice, string currency, DateTime dateTime, bool expiryProduct)
        {
            Model = model;
            Price = price;
            DateTime = dateTime;
            ExpiryProduct = expiryProduct;
            Currency = currency;
            GetPrice = getPrice;

        }

    }
}

