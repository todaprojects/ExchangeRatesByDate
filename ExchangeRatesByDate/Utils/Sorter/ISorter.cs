using System.Collections.Generic;
using ExchangeRatesByDate.Models;

namespace ExchangeRatesByDate.Utils.Sorter
{
    public interface ISorter
    {
        IEnumerable<Item> OrderList(IEnumerable<Item> list);
    }
}