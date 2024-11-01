using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.paymentMethod
{
    public class PaymentMethodByIdCriteria : Criteria<PaymentMethod>
    {
        public PaymentMethodByIdCriteria(int id)
        {
            AddCriteria(paymentMethod => paymentMethod.Id == id);
        }
    }
}
