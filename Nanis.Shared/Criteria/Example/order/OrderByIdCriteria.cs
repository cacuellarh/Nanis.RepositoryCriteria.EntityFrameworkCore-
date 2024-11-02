using Microsoft.EntityFrameworkCore;
using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order
{
    public class OrderByIdCriteria : Criteria<Order>
    {
        public OrderByIdCriteria(int id)
        {
            AddCriteria(criteria => criteria.Id == id);
            AddInclude(query =>
            query.Include(criteria => criteria.items)
            .ThenInclude(items => items.Product)
            );
        }
    }
}
