using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface.Check
{
    public class Checker
    {
        const int phoneNumberCount = 9;
        private class ConsoleCheck<T>
        {
            public delegate T Parser(string value);
            public static T CheckProperty(string value ,Parser parse)
            {
                var check = true;
                T numb = default;
                while (check)
                {
                    try
                    {
                        numb = parse(value);
                        check = false;
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect data");
                        value = Console.ReadLine();
                    }
                }
                return numb;
            }
        }
        public static int NumberCehck(string number)
        {
            int numb = default;
            if (number.Length == phoneNumberCount)
                numb = int.Parse(number);
            else
                throw new Exception(message:$"Number must have {phoneNumberCount} digits");
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
            return ConsoleCheck<int>.CheckProperty(value, NumberCehck);
        }
    }
}
