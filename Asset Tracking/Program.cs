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
            List<Asset> assets = PrepareAssets();
            List<CurrencyRate> currencyRates = PrepareCurrencyRates();
            assets = SortAssets(assets);
            PrintHeader();
            PrintData(assets, currencyRates);

            Console.ReadLine();

        }

        // Creates a simulated list of inputs from user. 
        static List<Asset> PrepareAssets()
        {
            return new List<Asset>()
            {
                new Phone("iPhone", "X", GetDate("2018-07-15"),new Office("Sweden"), 12450, "SEK",8.45),

                new Laptop("Asus", "W234", GetDate("2017-04-21"),new Office("USA"), 1200, "USD",1.00),

                new Phone("iPhone", "11", GetDate("2020-09-25"),new Office("Spain"), 990, "EUR",10.12),

                new Laptop("Lenovo", "Yoga 530", GetDate("2019-04-21"),new Office("USA"), 1530, "USD",1.00),

                new Phone("iPhone", "8", GetDate("2018-03-16"),new Office("Spain"), 970, "EUR",10.12),

                new Laptop("Lenovo", "Yoga 730", GetDate("2018-05-28"),new Office("USA"), 1835, "USD",1.00),

                new Phone("Motorola", "Razr", GetDate("2020-03-16"),new Office("Sweden"), 9700, "SEK",8.45),

                new Laptop("HP", "Elitebook", GetDate("2020-10-02"),new Office("Sweden"), 1588, "SEK",8.45)


            };
        }

        // Creates a simulated list of exchange rates. 
        static List<CurrencyRate> PrepareCurrencyRates()
        {
            return new List<CurrencyRate>()
            {

                new CurrencyRate("USD",1.00),

                new CurrencyRate("SEK", 0.12),

                new CurrencyRate("EUR", 1.21)
            };
        }

        // Sorts the Asset list by asset type and purchase date.
        static List<Asset> SortAssets(List<Asset> assets)
        {
            assets = assets.OrderBy(asset => asset.GetType().ToString()).ThenBy(asset => asset.PurchaseDate).ToList();
            return assets;
        }

        // Prints the Header columns to Console
        static void PrintHeader()
        {
            Console.WriteLine(
               Tab("Brand") +

                Tab("Model") +

                Tab("Office") +

                Tab("Purchase Date") +

                Tab("Price") +

                Tab("Currency") +

                Tab("In USD today"));

            Console.WriteLine(

              Tab("-----") +

              Tab("-----") +

              Tab("------") +

              Tab("-------------") +

              Tab("-----") +

              Tab("---------") +

              Tab("------------")

              );
        }

        // Printing out the Data
        static void PrintData(List<Asset> assets, List<CurrencyRate> currencyRates)
        {
            assets.ForEach(asset => PreparePrintDataLine(asset, currencyRates));
        }

        // Converts Date from string to DateTime
        static DateTime GetDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        }

        // Preparing Data to be printed
        static void PreparePrintDataLine(Asset asset, List<CurrencyRate> currencyRates)
        {
            int daysWarning = 913; //Approx 30 months 

            int daysAlarm = 1004;  //Approx 33 months 

            TimeSpan diff = DateTime.Now - asset.PurchaseDate;

            DecideForegroundColor(daysWarning, daysAlarm, diff);



            double usdRateToday = currencyRates.Where(currencyRate => currencyRate.Currency == asset.Currency).Select(ex => ex.Rate).FirstOrDefault();

            PrintDataLine(asset, usdRateToday);



            Console.ForegroundColor = ConsoleColor.White;
        }

        // Decides what Console Foreground Color to be used depending on how old assets are. 
        static void DecideForegroundColor(int daysWarning, int daysAlarm, TimeSpan diff)
        {
            if (diff.Days > daysAlarm)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (diff.Days > daysWarning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Prints data for one asset to Console. 
        static void PrintDataLine(Asset asset, double usdRateToday)
        {
            Console.WriteLine(
                Tab(asset.Brand) +

                            Tab(asset.Model) +

                            Tab(asset.Office.Name) +

                            Tab(asset.PurchaseDate.ToShortDateString()) +

                            Tab(asset.PurchasePrice.ToString("0.##")) +

                            Tab(asset.Currency) +

                            Tab((asset.PurchasePrice * usdRateToday).ToString("0.##"))

                            );  

        }

        // PadRight with 14 characters on a string.
        static string Tab(string input)

        {

            return input.PadRight(14);

        }



        // Currency sends data to Laptop and Phone class
        /*
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
        /*     Console.WriteLine();
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
        /*     Console.WriteLine("Phone");

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

              } */


   
}

}

