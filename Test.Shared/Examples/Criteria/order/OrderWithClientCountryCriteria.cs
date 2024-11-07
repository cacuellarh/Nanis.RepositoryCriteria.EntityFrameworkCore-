using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order
{
    public class OrderWithClientCountryCriteria : Criteria<Order>
    {
        public OrderWithClientCountryCriteria()
        {
            AddInclude(
                query => query.Include(order => order.Client)
                .ThenInclude(client => client.Adress));
        }
    }
}
