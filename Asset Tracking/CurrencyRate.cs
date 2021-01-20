using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracking
{
    public class CurrencyRate
    { // defining
        string currency;
        double dollars, result = 0;

        public CurrencyRate()
        {

        }

        public string Currency { get => currency; set => currency = value; }
        public double Dollars { get => dollars; set => dollars = value; }
        public double Result { get => result; set => result = value; }

        // method for double currency

        public double Curency1(string currency, double dollars)

        {


            if (currency == "euros")
            {
                result = dollars * 1.02;
            }
            else if (currency == "krona")
            {
                result = dollars * 120;
            }

            else if (currency == "pesos")
            {
                result = dollars * 10;
            }
            else
            {

                Console.WriteLine("Error");
            }
            return result;
        }

        }
}