using Microsoft.EntityFrameworkCore;
using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order
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
