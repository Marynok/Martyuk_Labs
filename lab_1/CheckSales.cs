using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab_1
{
    class CheckSales
    {
        const decimal  saleForSimmilarStreet = 15;
        public enum AgeDiscounts
        {
            Infants = 50,
            Children = 25
        }

        private Dictionary<string, decimal> sales = new Dictionary<string, decimal>
        { 
           {"Wayne Street", 10m },
           {"North Heather Street", -5.36m} 
        };

       public void CheckCount(params int[] sizes)
       {
            for (int i = 1; i < sizes.Length; i++)
            {
                if(sizes[i-1] != sizes[i])
                    throw new Exception("Invalid datas");
            }
       }

        public void SetStreetDiscount(IEnumerable<string> streets, decimal[] staticDiscounts)
        {
            for(int i = 0;i< streets.Count(); i++)
            {
                staticDiscounts[i] +=
                    sales.Where(
                        sale => streets.ElementAt(i).Contains(sale.Key)
                        ).Select(
                        sale => sale.Value)
                        .Sum();
            }
        }
        
        public void SetAgeDiscount(IEnumerable<int> persons, decimal[] percentageDiscounts , AgeDiscounts discountType)
        {
           
            foreach(var person in persons)
            {
                percentageDiscounts[person] += (decimal)discountType;
            }
        }
        
        public void SetNextStreetDiscount(IEnumerable<string> streets, decimal[] percentageDiscounts)
        {
            Regex symbol = new Regex(@"(\D*)");
            Regex space = new Regex(@"(\S*)");
            string lastStreet = default;
            string currentStr;
            int i = 0;

            foreach (var s in streets)
            {
                var str = s.Split(',');
                var m = symbol.Matches(str[str.Length - 1]);
                m = space.Matches(m[0].Value);
                currentStr = String.Concat(m);

                if (lastStreet == currentStr)
                    percentageDiscounts[i] += saleForSimmilarStreet;

                i++;
                lastStreet = currentStr;
            }
        }

        public void SetFinalPrice(IEnumerable<string> currencies, IEnumerable<decimal> prices, decimal[] fPrice,
                                     decimal[] percentageDiscounts, decimal[] staticDiscounts)
        {
            for (int i = 0; i < fPrice.Length; i++)
            {
                decimal p = prices.ElementAt(i);
                if (currencies.ElementAt(i) != CurrencyExchangeConvertation.Value)
                    fPrice[i] += p + CurrencyExchangeConvertation.FromUSD(currencies.ElementAt(i), staticDiscounts[i]);
                else
                    fPrice[i] += p + staticDiscounts[i];

                fPrice[i] *= (100 - percentageDiscounts[i]) / 100;
            }

        }

        public decimal GetFinalSumPrice(IEnumerable<string> currencies,  decimal[] fPrice)
        {
            decimal summ = default;
            for (int i = 0; i < currencies.Count(); i++)
            {
                if (currencies.ElementAt(i) != CurrencyExchangeConvertation.Value)
                    summ += CurrencyExchangeConvertation.ToUSD(currencies.ElementAt(i), fPrice[i]);
                else
                    summ += fPrice[i];
            }
            return summ;
        }

    }
}
