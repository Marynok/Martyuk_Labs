using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Currency
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("baseCurrencyLit")]
        public string BaseCurrencyLit { get; set; }

        [JsonPropertyName("exchangeRate")]
        public IList<ExchangeRate> ExchangeRate { get; set; }
    }
}
