using System;
using System.Collections.Generic;
using System.Text;

namespace lab_1
{
    class CurrencyExchangeConvertation
    {
        static public string  Value  { get; private set;} = "USD";
        static Dictionary<String, decimal> exchangeRate = new Dictionary<String, decimal> { { "EUR", 1.19m } };

        public static decimal FromUSD(string currency, decimal money)
        {
            return money / exchangeRate[currency];
        }

        public static decimal ToUSD(string currency, decimal money)
        {
            return exchangeRate[currency] * money;
        }
    }
}
