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
                staticDiscounts[i] += sales.Where(sale => streets.ElementAt(i).Contains(sale.Key))
                                           .Select(sale => sale.Value)
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
            string lastStreet = String.Empty;
            string currentStr;
  
            foreach (var s in streets.Select((value, index) => new { value, index }))
            {
                var str = s.value.Split(' ');
                str[0] = String.Empty;
                currentStr = String.Concat(str);

                if (lastStreet == currentStr)
                    percentageDiscounts[s.index] += saleForSimmilarStreet;
 
                lastStreet = currentStr;
            }
        }

        public decimal SetFinalPrice(IEnumerable<string> currencies, IEnumerable<decimal> prices,
                                     decimal[] percentageDiscounts, decimal[] staticDiscounts)
        {
            decimal summ = default;
            for (int i = 0; i < prices.Count(); i++)
            {
                decimal lastPrice = 0;
                decimal p = prices.ElementAt(i);
                if (currencies.ElementAt(i) != CurrencyExchangeConvertation.Value)
                    p = CurrencyExchangeConvertation.ToUSD(currencies.ElementAt(i), p);

                lastPrice += p + staticDiscounts[i];
                lastPrice *= (100 - percentageDiscounts[i]) / 100;
               
                summ += lastPrice;
            }
            return summ;

        }

    }
}
