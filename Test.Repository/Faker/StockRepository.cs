using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Test.Repository.Faker
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(DbContext context) : base(context)
        {
        }
    }
}
