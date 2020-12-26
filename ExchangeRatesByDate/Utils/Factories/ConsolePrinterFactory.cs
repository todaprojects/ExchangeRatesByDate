using ExchangeRatesByDate.Utils.Printer;

namespace ExchangeRatesByDate.Utils.Factories
{
    public class ConsolePrinterFactory
    {
        public static IPrinter GetPrinter()
        {
            return new ConsolePrinter();
        }
    }
}