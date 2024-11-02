using Microsoft.EntityFrameworkCore;
using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order
{
    public class OrderSelectTwoClientsCriteria : Criteria<Order>
    {
        public OrderSelectTwoClientsCriteria(int firstClient, int secondClient)
        {
            AddCriteria(order => order.Client.Id == firstClient);
            Or(order => order.Client.Id == secondClient);
            AddInclude(query => query
            .Include(order => order.Client));
        }
    }
}
