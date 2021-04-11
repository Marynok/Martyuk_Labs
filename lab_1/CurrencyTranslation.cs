using System;
using System.Collections.Generic;
using System.Text;

namespace lab_1
{
    static class CurrencyTranslation
    {
        static public string value = "USD";
        static Dictionary<String, decimal> kyrs = new Dictionary<String, decimal> { { "EUR", 1.19m } };
        public static decimal FromUSD(string currency, decimal money)
        {
            return money / kyrs[currency];
        }
        public static decimal ToUSD(string currency, decimal money)
        {
            return kyrs[currency] * money;
        }
    }
}
