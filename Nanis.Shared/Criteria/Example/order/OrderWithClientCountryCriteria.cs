using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order
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
