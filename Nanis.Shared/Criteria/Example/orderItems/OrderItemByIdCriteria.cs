using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.orderItems
{
    public class OrderItemByIdCriteria : Criteria<OrderItem>
    {
        public OrderItemByIdCriteria(int id)
        {
            AddCriteria(orderItem => orderItem.Id == id);
        }
    }
}
