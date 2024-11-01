using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.order.CombinedTest
{
    public class OrderByIdCriteria : Criteria<Order>
    {
        public OrderByIdCriteria(int idOrder)
        {
            AddCriteria(order => order.Id == idOrder);
        }
    }
}
