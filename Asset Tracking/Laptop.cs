using System;


namespace Asset_Tracking
{
    class Laptop : Asset
    {
        public Laptop(string brand, string model,  DateTime purchaseDate, Office office, double purchasePrice, string currency, double currencyRate)
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

