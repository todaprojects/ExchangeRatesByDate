using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatesByDate.Config;
using ExchangeRatesByDate.Models;
using ExchangeRatesByDate.Utils;
using ExchangeRatesByDate.Utils.Factories;

namespace ExchangeRatesByDate.App
{
    public class App
    {
        /// <summary>
        /// ExchangeRates[0] - currency exchange rates of the requested date;
        /// ExchangeRates[1] - currency exchange rates of the day before the requested date;
        /// ExchangeRates[2] - object with the results: currencies and their rate changes.
        /// </summary>
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

        public string GetExchangeResults()
        {
            var result = new StringBuilder();
            var sorter = SorterFactory.GetSorter();
            var orderedItemList = sorter.OrderList(ExchangeRates[2].Items);

            foreach (var item in orderedItemList)
            {
                result.Append($"{item.Currency} {item.Rate:N4}\n");
            }

            return result.ToString();
        }

        public void FormExchangeResults()
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
    }
}