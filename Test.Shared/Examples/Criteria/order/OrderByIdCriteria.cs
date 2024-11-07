using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order
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
