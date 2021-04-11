using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWork homeWork = new HomeWork();
            try
            {
                var sum = homeWork.InvokePriceCalculatiion();
                Console.WriteLine(Math.Round(sum,4));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
