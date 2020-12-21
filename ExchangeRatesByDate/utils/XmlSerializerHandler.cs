using System.Xml.Serialization;
using ExchangeRatesByDate.models;

namespace ExchangeRatesByDate.utils
{
    public static class XmlSerializerHandler
    {
        private static XmlSerializer _xmlSerializerInstance;

        public static XmlSerializer GetInstance()
        {
            return _xmlSerializerInstance ??=
                new XmlSerializer(typeof(ExchangeRate));
        }
    }
}