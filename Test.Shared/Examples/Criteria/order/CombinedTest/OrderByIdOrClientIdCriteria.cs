using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order.CombinedTest
{
    public class OrderByIdOrClientIdCriteria : Criteria<Order>
    {
        public OrderByIdOrClientIdCriteria(int orderId, int ClientId)
        {
            var OrderById = new OrderByIdCriteria(orderId);
            var orderByClientId = new OrderClientIdCriteria(ClientId);

            AddCriteria(OrderById.GetCriteria);
            AddInclude(query => query.Include(order => order.Client));
            Or(orderByClientId.GetCriteria);
        }
    }
}
