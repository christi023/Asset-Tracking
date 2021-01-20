using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracking
{
    class Phone : Asset // inheritance
    {
        public Phone(string brand, string model,  DateTime purchaseDate, Office office, double purchasePrice, string currency, double currencyRate)
        {
            Brand = brand;
            Model = model;        
            PurchaseDate = purchaseDate;
            Office = office;
            PurchasePrice = purchasePrice;
            Currency = currency;
            CurrencyRate = currencyRate;

        }
    } 

    }


