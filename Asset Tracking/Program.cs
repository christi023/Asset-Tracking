using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace Asset_Tracking

{
    public class Program
    {
        static void Main(string[] args)
        {
            // Currency sends data to Laptop and Phone class

            List<Laptop> laptop = new List<Laptop>();
            List<Phone> phone = new List<Phone>();

            // defining
            int priceCheck = 0;
            String inputModel = "";
            String price = "";
            bool expiryProduct = false;
            String datetime;
            string currency = "m";
            // double dollars, result = 0;
            DateTime PresentTime; // now 


            /********* LAPTOP LOGIC **********/
            Console.WriteLine();
            DateTime inputTime;
            double getPrice = 0;
            string Expiry = "";
            //  string Elapsed = "";
            CurrencyRate currencyRate = new CurrencyRate();

            Console.WriteLine("Laptop");

            while (true)
            {// getting the present time 
                PresentTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));

                try
                { // input a product
                    Console.WriteLine("Input Product:");
                    inputModel = Console.ReadLine();

                    if (inputModel.ToLower() == "q")
                    {
                        break;
                    }

                    while (true)
                    {
                        // input the currency $$
                        Console.WriteLine("Input Currency:");
                        Console.WriteLine("Select a currency : euros  krona  pesos    ");
                        currency = Console.ReadLine();

                        // input price
                        Console.WriteLine("Input Price:");
                        price = Console.ReadLine();
                        getPrice = currencyRate.Curency1(currency, System.Convert.ToDouble(price));

                        if (price.ToLower() == "q")
                        {
                            break;
                        }
                        else
                        {
                            if (int.TryParse(price, out priceCheck) == false)
                            {
                                Console.WriteLine("Pls add price, ");
                                continue;

                            }
                            break;
                        }

                    }

                    // input date time
                    Console.WriteLine("Input Datetime:");
                    datetime = Console.ReadLine();
                    inputTime = DateTime.Parse(datetime);
                    TimeSpan ts = PresentTime - inputTime;
                    int timeRemaining = System.Convert.ToInt32(ts.TotalDays);

                    if (timeRemaining >= 1005)
                    {
                        Console.WriteLine("This Product Is Expired");
                        expiryProduct = true;
                    }
                    else
                    {
                        Console.WriteLine("Number Of Elapsed Days : " + ts.TotalDays + " Days");

                    }

                    if (datetime.ToLower() == "q")
                    {
                        break;
                    }

                    laptop.Add(new Laptop(inputModel, price, getPrice, currency, Convert.ToDateTime(datetime), expiryProduct));
                    expiryProduct = false;

                }
                catch
                {
                }
            }


            /*********PHONE LOGIC **********/
            Console.WriteLine("Phone");

            while (true)
            {// getting the present time 
                PresentTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));

                try
                { // input a product
                    Console.WriteLine("Input Product:");
                    inputModel = Console.ReadLine();

                    if (inputModel.ToLower() == "q")
                    {
                        break;
                    }

                    while (true)
                    {
                        // input the currency $$
                        Console.WriteLine("Input Currency:");
                        Console.WriteLine("Select a currency : euros  krona  pesos    ");
                        currency = Console.ReadLine();

                        // input price
                        Console.WriteLine("Input Price:");
                        price = Console.ReadLine();
                        getPrice = currencyRate.Curency1(currency, System.Convert.ToDouble(price));

                        if (price.ToLower() == "q")
                        {
                            break;
                        }
                        else
                        {
                            if (int.TryParse(price, out priceCheck) == false)
                            {
                                Console.WriteLine("Pls add price, ");
                                continue;

                            }
                            break;
                        }

                    }

                    // input date time
                    Console.WriteLine("Input Datetime:");
                    datetime = Console.ReadLine();
                    inputTime = DateTime.Parse(datetime);
                    TimeSpan ts = PresentTime - inputTime;
                    int timeRemaining = System.Convert.ToInt32(ts.TotalDays);

                    if (timeRemaining >= 1005)
                    {
                        Console.WriteLine("This Product Is Expired");
                        expiryProduct = true;
                    }
                    else
                    {
                        Console.WriteLine("Number Of Elapsed Days : " + ts.TotalDays + " Days");

                    }

                    if (datetime.ToLower() == "q")
                    {
                        break;
                    }

                    phone.Add(new Phone(inputModel, price, getPrice, currency, Convert.ToDateTime(datetime), expiryProduct));
                    expiryProduct = false;

                }
                catch
                {
                }
            }

            // showing 

            Console.WriteLine("                         Laptop");

            Console.WriteLine("Model" + "         " + "Price" + "        " + "exchange" + " " + "Currency" + "        " + "Date");

            foreach (Laptop lpt in laptop)
            {
                if (lpt.ExpiryProduct == true)
                {
                    Expiry = "This Product Got Expired";
                }
                else
                {
                    Expiry = "";

                }

                Console.WriteLine(lpt.Model + "           " + lpt.Price + "        " + lpt.GetPrice + " " + lpt.Currency + "              " + lpt.DateTime + "        " + Expiry);

            }

            Console.WriteLine("                              Phone");
            Console.WriteLine("Model" + "         " + "Price" + "        " + " exchange" + " " + "Currency" + "        " + "Date");
            foreach (Phone ph in phone)
            {
                if (ph.ExpiryProduct == true)
                {
                    Expiry = "This Product Got Expired";
                }
                else
                {
                    Expiry = "";

                }
                Console.WriteLine(ph.Model + "           " + ph.Price + "        " + ph.GetPrice + " " + ph.Currency + "              " + ph.DateTime + "        " + Expiry);

            }


        }
    }

}

