using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.Example.order;
using Nanis.Shared.Faker;
using Nanis.Shared.Criteria.Example.order.CombinedTest;

namespace Criteria.Test
{
    [TestClass]
    public class CompositionCriteaTest : StartUpTest
    {
        private DbSet<Order> _orderDbSet;

        [TestInitialize]
        public void Setup()
        {
            _orderDbSet = Fixture.CreateContext().Set<Order>(); 
        }

        [TestMethod]
        public void CombinedCriterias_shouldGetOrderByIdAndPaymentMethod()
        {
            var orderId = 2;
            var paymentMethod = "Visa";

            var criteriaCombined = new OrderByIdAndPaymentMethodCriteria(orderId, paymentMethod);

            var orders = _orderDbSet.BuildCriteriaQuery(criteriaCombined).ToList();

            Assert.IsNotNull(orders);
        }


        [TestMethod]
        public void CombinedCriterias_shouldOrderByIdOrOrderByClientId()
        {
            var orderId = 3;
            var clientId = 1;

            var criteriaCombined = new OrderByIdOrClientIdCriteria(orderId, clientId);

            var orders = _orderDbSet.BuildCriteriaQuery(criteriaCombined).ToList();

            Assert.IsNotNull(orders);

            Assert.IsTrue(orders.Any(order => order.Id == orderId || order.Client.Id == clientId));
        }
    }
}
