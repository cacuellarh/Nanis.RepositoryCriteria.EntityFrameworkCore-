using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order.CombinedTest
{
    public class OrderByIdAndPaymentMethodCriteria : Criteria<Order>
    {
        public OrderByIdAndPaymentMethodCriteria(int idOrder, string paymentMethod)
        {
            var orderById = new OrderByIdCriteria(idOrder);
            var orderByPaymentMethod = new OrderByPaymentMethod(paymentMethod);

            AddCriteria(orderById.GetCriteria);
            And(orderByPaymentMethod.GetCriteria);
        }
    }
}
