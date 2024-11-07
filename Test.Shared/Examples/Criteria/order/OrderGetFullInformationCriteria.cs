using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order
{
    public class OrderGetFullInformationCriteria : Criteria<Order>
    {
        public OrderGetFullInformationCriteria()
        {
            AddInclude(
                query => query.Include(order => order.Client),
                query => query.Include(order => order.PaymentMethod));
        }
    }
}
