using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRatesByDate.config;
using ExchangeRatesByDate.models;

namespace ExchangeRatesByDate.utils
{
    public class App
    {
        private List<ExchangeRate> ExchangeRates { get; set; }
        public List<string> Dates { get; }

        public App()
        {
            Dates = new List<string>();
            ExchangeRates = new List<ExchangeRate>();
        }

        public async Task GetExchangeDataAsync()
        {
            for (var i = 0; i < 2; i++)
            {
                var resourceUri = ResourceApi.GetUri(Dates[i]);
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
                var item = new Item();
                item.Currency = requestedItem.Currency;
                item.Rate = requestedItem.Rate - previousItem.Rate;

                ExchangeRates[2].Items.Add(item);
            }
        }

        private IEnumerable<Item> OrderItemList()
        {
            return ExchangeRates[2].Items.OrderByDescending(i => i.Rate).ToList();
        }
    }
}