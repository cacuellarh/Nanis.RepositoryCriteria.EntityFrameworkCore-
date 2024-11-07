using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order.CombinedTest
{
    public class OrderByPaymentMethod : Criteria<Order>
    {
        public OrderByPaymentMethod(string paymentMethod, bool negate = false)
        {

            AddCriteria(order => order.PaymentMethod.Type == paymentMethod);

        }
    }
}
