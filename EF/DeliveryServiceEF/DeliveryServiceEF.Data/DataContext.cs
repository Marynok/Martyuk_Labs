using DeliveryServiceEF.Domain;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace DeliveryServiceEF.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryMan> DeliveryMens { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderFoodData> OrderFoodDatas { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Delivery>()
               .HasOne(d => d.DeliveryMan)
               .WithMany(dm => dm.Deliveries)
               .HasForeignKey(d => d.DeliveryManId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DeliveryMan>()
                .HasOne(a => a.CurrentDelivery)
                .WithOne()  
                .HasForeignKey<DeliveryMan>(a => a.CurrentDeliveryId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<OrderFoodData>()
               .HasOne(of => of.Order)
               .WithMany(o => o.OrderFoods)
               .HasForeignKey(of => of.OrderId);

            builder.Entity<OrderFoodData>()
                .HasOne(of =>of.Food)
                .WithMany(f => f.OrderFoodDatas)
                .HasForeignKey(of => of.FoodId);

            builder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

            builder.Entity<Order>()
                 .Property(o => o.Date)
                 .HasDefaultValueSql("GETDATE()"); 
        }
    }
}
