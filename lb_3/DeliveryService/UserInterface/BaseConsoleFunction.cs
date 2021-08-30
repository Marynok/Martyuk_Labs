using System;

namespace DeliveryService.UserInterface
{
    public class BaseConsoleFunction
    {
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
        public static bool CheckArea(string message, string expectedResponse)
        {
            var responce = GetProperty(message);
            var result = (responce.ToLower() == expectedResponse.ToLower());
            return result;
        }
        public static void ConsoleDelimiter()
        {
            Console.WriteLine("===============================================>");
        }
        public static void ConsoleWriteOnPosition(int x, int y, string message)
        {
            var oldX = Console.CursorLeft;
            var oldY = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
            Console.SetCursorPosition(oldX, oldY);
        }
    }
}
