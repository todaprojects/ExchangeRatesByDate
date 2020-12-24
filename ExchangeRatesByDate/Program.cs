using System;
using System.Threading.Tasks;
using ExchangeRatesByDate.Helpers;
using ExchangeRatesByDate.Utils;

namespace ExchangeRatesByDate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Date: ");
                    var requestedDate = DateHelper.Parse(Console.ReadLine());

                    if (requestedDate != null)
                    {
                        var app = new App();

                        app.Dates.Add(requestedDate);
                        app.Dates.Add(DateHelper.GetPrevious());

                        await app.GetExchangeDataAsync();

                        app.PrintResults();

                        break;
                    }

                    Console.WriteLine("Try again: valid date is any between 1993-06-26 and 2014-12-31.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}