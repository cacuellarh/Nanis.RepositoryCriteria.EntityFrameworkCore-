using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Test.Repository.Faker
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemsRepository
    {
        public OrderItemRepository(DbContext context) : base(context)
        {
        }
    }
}
