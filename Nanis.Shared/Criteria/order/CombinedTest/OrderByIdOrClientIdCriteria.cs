using Microsoft.EntityFrameworkCore;
using Nanis.Criteria;
using Nanis.Shared.Criteria.product;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.order.CombinedTest
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
