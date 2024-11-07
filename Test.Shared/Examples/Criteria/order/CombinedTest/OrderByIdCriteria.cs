using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order.CombinedTest
{
    public class OrderByIdCriteria : Criteria<Order>
    {
        public OrderByIdCriteria(int idOrder)
        {
            AddCriteria(order => order.Id == idOrder);
        }
    }
}
