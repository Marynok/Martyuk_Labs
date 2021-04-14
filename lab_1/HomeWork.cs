using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace lab_1
{
    internal class HomeWork
    {
        CheckSales _priceChecks;
        public HomeWork()
        {
            _priceChecks = new CheckSales();
        }
        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;
  
            _priceChecks.CheckCount(destinations.Count(), clients.Count(), 
                 prices.Count(), currencies.Count());

            var len = prices.Count();

            var staticDiscounts = new decimal[len];
            var percentageDiscounts = new decimal[len];

            _priceChecks.SetStreetDiscount(destinations, staticDiscounts);
            _priceChecks.SetAgeDiscount(infantsIds, percentageDiscounts, CheckSales.AgeDiscounts.Infants);
            _priceChecks.SetAgeDiscount(childrenIds, percentageDiscounts, CheckSales.AgeDiscounts.Children);
            _priceChecks.SetNextStreetDiscount(destinations, percentageDiscounts);

            var fPrice = new decimal[len];
            _priceChecks.FinalPrice(currencies, prices, fPrice, percentageDiscounts, staticDiscounts);

            fullPrice = _priceChecks.FinalSumPrice(currencies, fPrice);

                return fullPrice;
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910  Wayne Street North Heather Street, Cocoa, FL RP 32927",
                "911 North Heather Street, Cocoa, FL  RP 32927",
                "706 Tarkiln Hill Ave, Middleburg, F L R P 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125};
            var currencies = new[] { "USD", "USD", "EUR", "USD","USD"};
            
            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
       
    }
}
