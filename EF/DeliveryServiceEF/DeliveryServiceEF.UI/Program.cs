using DeliveryServiceEF.Data;
using DeliveryServiceEF.Domain;
using System;
using System.Linq;

namespace DeliveryServiceEF.UI
{
    class Program
    {
        private static DataContext _context;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            _context = new DataContext();
            _context.Database.EnsureCreated();
            AddClients();
            GetClients();

        }
        private static void AddClients()
        {
            var hum = new Client("Irina","Selova","0509672114");
            var hum2 = new Client("Valeria", "Valova", "0502368544");
            var hum3 = new Client("Vitalii", "Orlov", "0507051114");
            _context.Clients.AddRange(hum, hum2, hum3);
            _context.SaveChanges();

        }
        private static void GetClients()
        {
            var humans = _context.Clients.ToList();
            Console.WriteLine($"Humans in company {humans.Count}");

            foreach (var hum in humans)
            {
                Console.WriteLine($"{hum.Id} {hum.LastName} {hum.FirstName}");
            }
        }
    }
}
