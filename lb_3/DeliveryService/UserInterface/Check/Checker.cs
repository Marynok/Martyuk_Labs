using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface.Check
{
    public class Checker
    {
       private const int _phoneNumberCount = 9;
        
        public static int NumberCheck(string number)
        {
            int numb = default;
            if (number.Length == _phoneNumberCount)
                numb = int.Parse(number);
            else
                throw new Exception(message:$"Number must have {_phoneNumberCount} digits");
            return numb;
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
        public static int GetPropertyPhoneNumber(string value)
        {
            return ConsoleCheck<int>.CheckProperty(value, NumberCheck);
        }
    }
}
