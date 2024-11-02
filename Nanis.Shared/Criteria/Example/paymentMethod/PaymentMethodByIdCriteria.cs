using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.paymentMethod
{
    public class PaymentMethodByIdCriteria : Criteria<PaymentMethod>
    {
        public PaymentMethodByIdCriteria(int id)
        {
            AddCriteria(paymentMethod => paymentMethod.Id == id);
        }
    }
}
