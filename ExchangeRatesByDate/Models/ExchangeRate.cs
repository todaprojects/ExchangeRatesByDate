using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeRatesByDate.Models
{
    [XmlRoot("ExchangeRates")]
    public class ExchangeRate
    {
        [XmlElement("item")]
        public List<Item> Items { get; set; }

        public ExchangeRate()
        {
            Items = new List<Item>();
        }
    }
}