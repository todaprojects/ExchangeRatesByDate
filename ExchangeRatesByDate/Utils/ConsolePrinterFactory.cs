using ExchangeRatesByDate.Printer;

namespace ExchangeRatesByDate.Utils
{
    public class ConsolePrinterFactory
    {
        public static IPrinter GetPrinter()
        {
            return new ConsolePrinter();
        }
    }
}