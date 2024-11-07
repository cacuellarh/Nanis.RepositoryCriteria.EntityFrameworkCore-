using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order
{
    public class OrderClientIdCriteria : Criteria<Order>
    {
        public OrderClientIdCriteria(int id)
        {
            AddCriteria(order => order.Client.Id == id);
            AddInclude(query => query.Include(order => order.Client));
        }
    }
}
