
using Nanis.Criteria;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;
using Microsoft.EntityFrameworkCore;

namespace Nanis.Test.Shared.Examples.Criteria.order
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
