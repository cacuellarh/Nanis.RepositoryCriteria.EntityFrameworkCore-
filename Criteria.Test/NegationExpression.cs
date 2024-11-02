using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.Example.order;
using Nanis.Shared.Faker;

namespace Criteria.Test
{
    [TestClass]
    public class NegationExpression : StartUpTest
    {
        private DbSet<Order> _orderDbSet;

        [TestInitialize]
        public void Setup()
        {
            _orderDbSet = Fixture.CreateContext().Set<Order>();
        }

        [TestMethod]
        public void Negation_ShodulProductsPaymentMethodCash() 
        {
            int orderId = 1;

            var orderById = new OrderByIdCriteria(orderId).Not();

            var orders = _orderDbSet.BuildCriteriaQuery(orderById).ToList();

            Assert.IsNotNull(orders);

            Assert.IsTrue(orders.Any(order => order.Id != orderId));

        }
    }
}
