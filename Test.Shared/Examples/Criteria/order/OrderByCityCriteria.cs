using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order
{
    public class OrderByCityCriteria : Criteria<Order>
    {
        public OrderByCityCriteria(int orderId, string city)
        {
            AddCriteria(order => order.Id == orderId);
            And(order => order.Client.Adress.city == city);
            AddInclude(
                query => query.Include(order => order.Client)
                .ThenInclude(client => client.Adress)
                );
        }
    }
}
