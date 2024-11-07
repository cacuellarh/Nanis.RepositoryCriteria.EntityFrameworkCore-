using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Repository
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(DbContext context) : base(context)
        {
        }
    }
}
