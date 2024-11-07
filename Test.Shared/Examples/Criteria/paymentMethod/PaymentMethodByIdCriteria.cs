using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.paymentMethod
{
    public class PaymentMethodByIdCriteria : Criteria<PaymentMethod>
    {
        public PaymentMethodByIdCriteria(int id)
        {
            AddCriteria(paymentMethod => paymentMethod.Id == id);
        }
    }
}
