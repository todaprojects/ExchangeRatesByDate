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

            var items = GetItemResults();
            var sortedItems = sorter.OrderList(items);

            foreach (var item in sortedItems)
            {
                result.Append($"{item.Currency} {item.Rate:N4}\n");
            }

            return result.ToString();
        }

        private IEnumerable<Item> GetItemResults()
        {
            var items = new List<Item>();

            foreach (var requestedItem in ExchangeRates[0].Items)
            {
                var previousItem =
                    ExchangeRates[1].Items.Find(i =>
                        i.Currency == requestedItem.Currency);

                if (previousItem == null) continue;

                items.Add(new Item()
                    {
                        Currency = requestedItem.Currency,
                        Rate = requestedItem.Rate - previousItem.Rate
                    }
                );
            }

            return items;
        }
    }
}