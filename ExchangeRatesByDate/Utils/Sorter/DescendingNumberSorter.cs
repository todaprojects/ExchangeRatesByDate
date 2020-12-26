using System.Collections.Generic;
using System.Linq;
using ExchangeRatesByDate.Models;

namespace ExchangeRatesByDate.Utils.Sorter
{
    public class DescendingNumberSorter : ISorter
    {
        public IEnumerable<Item> OrderList(IEnumerable<Item> list)
        {
            return list.OrderByDescending(i => i.Rate);
        }
    }
}