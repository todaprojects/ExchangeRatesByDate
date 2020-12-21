using System.Xml.Serialization;

namespace ExchangeRatesByDate.models
{
    [XmlType("item")]
    public class Item
    {
        [XmlElementAttribute("date")]
        public string Date { get; set; }
        [XmlElementAttribute("currency")]
        public string Currency { get; set; }
        [XmlElementAttribute("rate")]
        public decimal Rate { get; set; }
    }
}