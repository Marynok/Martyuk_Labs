using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ICurrencyController
    {
        Task<Currency> GetApiDataAsync();
        Task<decimal> GetExchangeRate(string searchCurrency);
    }
}
