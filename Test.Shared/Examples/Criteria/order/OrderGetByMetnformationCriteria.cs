using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.order
{
    public class OrderGetByMethodPaymentFullInformation : Criteria<Order>
    {
        public OrderGetByMethodPaymentFullInformation(string paymentMethod)
        {
            AddCriteria(order => order.PaymentMethod.Type == paymentMethod);
            AddInclude(
                query => query.Include(order => order.Client)
                .ThenInclude(client => client.Adress),

                query => query.Include(order => order.PaymentMethod));
        }
    }
}
