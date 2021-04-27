using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface.Check
{
    public class ConsoleCheck<T>
    {
        public delegate T Parser(string value);
        public static T CheckProperty(string value, Parser parser)
        {
            var check = true;
            T numb = default;
            while (check)
            {
                try
                {
                    numb = parser(value);
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
}
