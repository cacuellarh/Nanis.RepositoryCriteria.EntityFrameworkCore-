using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order.CombinedTest
{
    public class OrderByPaymentMethod : Criteria<Order>
    {
        public OrderByPaymentMethod(string paymentMethod, bool negate = false)
        {

            AddCriteria(order => order.PaymentMethod.Type == paymentMethod);

        }
    }
}
