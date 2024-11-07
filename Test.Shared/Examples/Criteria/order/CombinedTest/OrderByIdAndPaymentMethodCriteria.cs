using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order.CombinedTest
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
