using Microsoft.EntityFrameworkCore;

namespace Nanis.Shared
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=ECOPE-CACUELLAR\SQLEXPRESS;Database=NanisTest;Trusted_Connection=True;Encrypt=False;ConnectRetryCount=0";
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        { 
            lock (_lock) 
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context.AddRange(
                            Seeder.Products.ToArray());

                        context.AddRange(
                            Seeder.AdDrresses.ToArray());

                        context.AddRange(
                            Seeder.Clients.ToArray());

                        context.AddRange(
                            Seeder.PaymentMethods.ToArray());

                        context.AddRange(
                            Seeder.OrderItems.ToArray());

                        context.AddRange(
                            Seeder.Orders.ToArray());

                        context.AddRange(
                            Seeder.Stock.ToArray());
                        context.SaveChanges();
                    }
                    _databaseInitialized = true;
                }
            }
        }

        public NanisTestContext CreateContext()
        => new NanisTestContext(
            new DbContextOptionsBuilder<NanisTestContext>()
                .UseSqlServer(ConnectionString)
                .Options);
    }
}
