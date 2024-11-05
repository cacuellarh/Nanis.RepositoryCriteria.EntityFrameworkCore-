using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order
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
