using System;

namespace ExchangeRatesByDate.Printer
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}