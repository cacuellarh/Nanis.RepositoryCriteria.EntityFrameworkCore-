using Nanis.Repository;
using Nanis.Shared.Faker;
using Microsoft.EntityFrameworkCore;

namespace Nanis.Test.Shared.Examples.Repository
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(DbContext context) : base(context)
        {
        }
    }
}
