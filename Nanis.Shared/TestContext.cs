using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared
{
    public class NanisTestContext : DbContext
    {
        public NanisTestContext(DbContextOptions<NanisTestContext> options) : base(options) { }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public  DbSet<Client> Clients { get; set; }
        public  DbSet<PaymentMethod> PaymentMethods { get; set; }
        public  DbSet<Address> Addresses { get; set; }
        public  DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Stock> Stock { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentMethod>()
                .HasMany(pm => pm.Orders)
                .WithOne(o => o.PaymentMethod) 
                .HasForeignKey(o => o.PaymentMethodId); 
        }
    }
}
