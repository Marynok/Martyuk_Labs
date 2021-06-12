using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryService.Controllers
{
    public class CurrencyController:ICurrencyController
    {
        private Currency _currency;

        private string getURL()
        {
            var data = DateTime.Now.ToShortDateString();
            return "https://api.privatbank.ua/p24api/exchange_rates?json&date=" + data;
        }

        public async Task<Currency> GetApiDataAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, getURL()); 
            var response = await client.SendAsync(request).ConfigureAwait(false);
            return JsonSerializer.Deserialize<Currency>(await response.Content.ReadAsStringAsync());
        }

        public async Task<decimal> GetExchangeRate(string searchCurrency)
        {
            if ((_currency is null) || (!_currency.Date.Equals(DateTime.Today)))
            {
                _currency = await GetApiDataAsync();
            }
            var exchangeRate = _currency.ExchangeRate.FirstOrDefault(rate => rate.Currency == searchCurrency);
            return (exchangeRate is null)? 0 : exchangeRate.Sale ;
        }
    }
}
