using ExchangeRatesByDate.Utils.Sorter;

namespace ExchangeRatesByDate.Utils.Factories
{
    public class SorterFactory
    {
        public static ISorter GetSorter()
        {
            return new DescendingNumberSorter();
        }
    }
}