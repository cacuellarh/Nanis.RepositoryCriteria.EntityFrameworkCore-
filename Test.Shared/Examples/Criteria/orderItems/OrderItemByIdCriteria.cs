using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.orderItems
{
    public class OrderItemByIdCriteria : Criteria<OrderItem>
    {
        public OrderItemByIdCriteria(int id)
        {
            AddCriteria(orderItem => orderItem.Id == id);
        }
    }
}
