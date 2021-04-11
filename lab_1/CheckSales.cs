using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace lab_1
{
    class CheckSales
    {
        decimal saleForSimmilarStreet = 15;
        public enum PerCentSales
        {
            Infants = 50,
            Children = 25
        }

        public  Dictionary<Regex, decimal> sales = new Dictionary<Regex, decimal>
        { { new Regex(@"\w*Wayne Street\w*"), 10m },
           {new Regex(@"\w*North Heather Street\w*"), -5.36m} 
        };

       public int CheckCount(params IEnumerator[] list)
        {
            int lastCount;
            int currentCount = 0;
            for (int i = 0; i < list.Length; i++)
            {
                lastCount = currentCount;
                currentCount = 0;
                while (list[i].MoveNext())
                {
                    currentCount++;
                }
                if (i > 0)
                    if (currentCount != lastCount)
                        throw new Exception("Invalid datas");
            }
            return currentCount;
        }

        public void StreetChecks(IEnumerable<string> streets, decimal[] staticSale)
        {
            int i = 0;
            foreach (var str in streets)
            {
                foreach (KeyValuePair<Regex, decimal> s in sales)
                {
                    MatchCollection m = s.Key.Matches(str);
                    if (m.Count != 0)
                        staticSale[i] += s.Value;
                }
                i++;
            }
        }
        
        public void ChildrensChecks(IEnumerable<int> persons, decimal[] perCentSale, PerCentSales type)
        {
            foreach(var p in persons)
            {
                perCentSale[p] += (decimal)type;
            }
        }
        
        public void NextStreetChecks(IEnumerable<string> streets, decimal[] perCentSale)
        {
            Regex symbol = new Regex(@"(\D*)");
            Regex space = new Regex(@"(\S*)");
            string lastStreet = default;
            int i = 0;
            foreach (var s in streets)
            {
                String[] str = s.Split(',');
                string currentStr = "";
                MatchCollection m = symbol.Matches(str[str.Length - 1]);
                m = space.Matches(m[0].Value);

                if (m.Count > 0)
                {
                    foreach (Match match in m)
                        currentStr += match.Value;

                    if (lastStreet == currentStr)
                        perCentSale[i] += saleForSimmilarStreet;
                }
                i++;
                lastStreet = currentStr;
            }
        }

        public void finalPrice(IEnumerable<string> currencies, IEnumerable<decimal> prices, decimal[] fPrice,
                                         decimal[] perCentSale, decimal[] staticSale)
        {
            var currenc = currencies.GetEnumerator();
            var price = prices.GetEnumerator();
            for (int i = 0; i < fPrice.Length; i++)
            {
                currenc.MoveNext();
                price.MoveNext();
                decimal p = (decimal)price.Current;
                if ((string)currenc.Current != CurrencyTranslation.value)
                    fPrice[i] += p + CurrencyTranslation.FromUSD((string)currenc.Current, staticSale[i]);
                else
                    fPrice[i] += p + staticSale[i];

                fPrice[i] *= (100 - perCentSale[i]) / 100;
            }

        }
        public decimal finalSumPrice(IEnumerable<string> currencies,  decimal[] fPrice,
                                       decimal[] perCentSale, decimal[] staticSale)
        {
            decimal summ = default;
            int i = 0;
            foreach (var c in currencies)
            {
                if (c != CurrencyTranslation.value)
                    summ += CurrencyTranslation.ToUSD(c, fPrice[i]);
                else
                    summ += fPrice[i];
                i++;
            }
            return summ;
        }

    }
}
