using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRatesByDate.Config;
using ExchangeRatesByDate.Models;

namespace ExchangeRatesByDate.Utils
{
    public class App
    {
        /*
         * ExchangeRates[0] - currency exchange rates of the requested date;
         * ExchangeRates[1] - currency exchange rates of the day before the requested date;
         * ExchangeRates[2] - object with the results: currencies and their rate changes.
        */
        private List<ExchangeRate> ExchangeRates { get; set; }
        public List<string> Dates { get; }

        public App()
        {
            Dates = new List<string>();
            ExchangeRates = new List<ExchangeRate>();
        }

        public async Task GetExchangeDataAsync()
        {
            foreach (var resourceUri in Dates.Select(ResourceApi.GetUri))
            {
                ExchangeRates.Add(await XmlConverter.ParseObjAsync<ExchangeRate>(resourceUri));
            }
        }

        public void PrintResults()
        {
            GetExchangeResults();

            foreach (var item in OrderItemList())
            {
                Console.WriteLine($"{item.Currency} {item.Rate:N4}");
            }
        }

        private void GetExchangeResults()
        {
            ExchangeRates.Add(new ExchangeRate());

            foreach (var requestedItem in ExchangeRates[0].Items)
            {
                var previousItem =
                    ExchangeRates[1].Items.Find(i =>
                        i.Currency == requestedItem.Currency);

                if (previousItem == null) continue;
                var item = new Item
                {
                    Currency = requestedItem.Currency,
                    Rate = requestedItem.Rate - previousItem.Rate
                };

                ExchangeRates[2].Items.Add(item);
            }
        }

        private IEnumerable<Item> OrderItemList()
        {
            return ExchangeRates[2].Items.OrderByDescending(i => i.Rate).ToList();
        }
    }
}