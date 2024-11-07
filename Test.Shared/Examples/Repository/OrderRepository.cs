using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
    }
}
