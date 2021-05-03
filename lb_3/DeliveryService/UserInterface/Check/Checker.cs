using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface.Check
{
    public class Checker
    {
        public static string CheckByPattern(string number, Regex regex)
        {
            var match = regex.Matches(number);
            if (match.Count == 1)
            {
               if(match[0].ToString() != number)
                    throw new Exception();
            }
            else
                throw new Exception();

            return number;
        }
      
        public static int GetPropertyInt(string value)
        {
            return ConsoleCheck<int>.CheckProperty(value,int.Parse);
        }
        public static float GetPropertyFloat(string value)
        {
            return ConsoleCheck<float>.CheckProperty(value, float.Parse);
        }
        public static decimal GetPropertyDecimal(string value)
        {
            return ConsoleCheck<decimal>.CheckProperty(value,decimal.Parse);
        }
        public static string GetPropertyPhoneNumber(string value)
        {
            var phonePattern = new Regex(@"(\+38)?0((\(\d{2}\))|(\d{2}))\s?\d{3}\s?\d{2}\s?\d{2}");

            return ConsoleCheck<string>.CheckProperty(value, phonePattern, CheckByPattern);
        }
        public static string GetPropertyStreet(string value)
        {
            var streetPattern = new Regex(@"ул((\.)|(ица))\s?[А-Я][а-я]*(\.)?");

            return ConsoleCheck<string>.CheckProperty(value, streetPattern, CheckByPattern);
        }
        public static string GetPropertyHome(string value)
        {
            var homePattern = @"д((\.)|(ом))\s?\d+";
            var flatPattern = @"кв((\.)|(артира))\s?\d+?";

            var fullPattern = new Regex(homePattern + @"(\,\s?" + flatPattern + @")?(\.)?");

            return ConsoleCheck<string>.CheckProperty(value, fullPattern, CheckByPattern);
        }
    }
}
