using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface
{
    public class BaseConsoleFunction
    {
        const int phoneNumberCount = 9;
        public static void WithdrawList(object[] list)
        {
            for (int i = 0; i < list.Length; i++)
                Console.WriteLine($"{i + 1}. {list[i]}");
        }
        public static string GetProperty(string name)
        {
            Console.WriteLine(name);
            return Console.ReadLine();
        }
        public static bool CheckAreae(string message, string expectedResponse)
        {
            var responce = GetProperty(message);
            var result = (responce.ToLower() == expectedResponse.ToLower() ? true : false);
            return result;
        }
        public static void ConsoleDelimiter()
        {
            Console.WriteLine("===============================================>");
        }
    }
}
