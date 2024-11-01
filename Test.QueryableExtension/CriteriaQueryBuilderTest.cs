using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.order;
using Nanis.Shared.Criteria.product;
using Nanis.Shared.Faker;
using QueryableExtension;


namespace Test.QueryableExtension
{
    [TestClass]
    public class CriteriaQueryBuilderTest : StartUpTest
    {
        private DbSet<Order> _orderDbSet;
        [TestInitialize]
        public void Setup()
        {
            _orderDbSet = Fixture.CreateContext().Set<Order>();
        }
        [TestMethod]
        public void Get_OrderByIdClient()
        {
            var id = 2;
            var criteria = new OrderClientIdCriteria(id);
            var order = _orderDbSet.BuildCriteriaQuery(criteria).FirstOrDefault();

            Assert.IsNotNull(order);
            Assert.IsTrue(order.Client.Id == id);
        }

        [TestMethod]
        public void Or_SelectOrdersByIdClients_shouldTwoClients()
        {
            int firstClient = 1;
            int secondClient = 2;   
            var criteria = new OrderSelectTwoClientsCriteria(firstClient, secondClient);

            var orders = _orderDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());

            Assert.AreEqual(orders[0].Client.Id , firstClient);
            Assert.AreEqual(orders[1].Client.Id, secondClient);
        }

        [TestMethod]
        public void And_SelectOrdersByIdClientAndCountry_shouldClientByCountry()
        {
            int orderId = 1;
            string city = "Springfield";
            var criteria = new OrderByCityCriteria(orderId, city);

            var orders = _orderDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());

        }

        [TestMethod]
        public void ThenInclude_GetOrdersByPaymentMethod_ShouldGetAllInformation()
        {
            string paymentMethod = "Visa";
            var criteria = new OrderGetByMethodPaymentFullInformation(paymentMethod);

            var orders = _orderDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());

            foreach (var order in orders) 
            {
                Assert.IsTrue(order.Client is not null);
                Assert.IsTrue(order.Client.Adress is not null);
                Assert.IsTrue(order.PaymentMethod is not null);
            }
        }


    }
}
