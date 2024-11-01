using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.orderItems
{
    public class OrderItemByIdCriteria : Criteria<OrderItem>
    {
        public OrderItemByIdCriteria(int id) 
        {
            AddCriteria(orderItem => orderItem.Id == id);
        }
    }
}
