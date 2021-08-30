using DeliveryService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Currency
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime Date { get; set; }

        [JsonPropertyName("baseCurrencyLit")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("exchangeRate")]
        public IList<ExchangeRate> ExchangeRate { get; set; }
    }
}
