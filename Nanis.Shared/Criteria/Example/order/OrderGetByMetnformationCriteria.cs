using Microsoft.EntityFrameworkCore;
using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.order
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
