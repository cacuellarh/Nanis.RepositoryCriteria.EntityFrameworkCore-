using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.Example.client;
using Nanis.Shared.Criteria.Example.order;
using Nanis.Shared.Criteria.Example.test;
using Nanis.Shared.Faker;

namespace Criteria.Test
{
    [TestClass]
    public class AddIncludeTest : StartUpTest
    {
        private DbSet<Client> _clientDbSet;
        private DbSet<Order> _orderDbSet;

        [TestInitialize]
        public void Setup()
        {
            _clientDbSet = Fixture.CreateContext().Set<Client>();
            _orderDbSet = Fixture.CreateContext().Set<Order>();
        }

        [TestMethod]
        public void AddInclude_ValidInput_ShouldClientWithAddress()
        {
            var criteria = new ClientIncludeAddressCriteria();

            var clients = _clientDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(clients);
            Assert.IsTrue(clients.Any());
            Assert.IsTrue(clients.All(client => client.Adress != null));  
        }

        [TestMethod]
        public void AddInclude_MoreThanOneInclude_ShouldOrderWithClientAndPaymentMethod()
        {
            var criteria = new OrderGetFullInformationCriteria();

            var orders = _orderDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());
            Assert.IsTrue(orders.All(order => order.Client != null));
            Assert.IsTrue(orders.All(order => order.PaymentMethod != null));
        }

        [TestMethod]
        public void ThenInclude_ValidInput_ShouldOrderWithClientCountries()
        {
            var criteria = new OrderWithClientCountryCriteria();

            var orders = _orderDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());
            Assert.IsTrue(orders.All(order => order.Client != null));
            Assert.IsTrue(orders.All(order => order.Client.Adress.country != null));
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddInclude_IncludeAreNull_ShouldThrowException()
        {
            var criteria = new IncludeAreNullCriteria();
            var clients = _clientDbSet.BuildCriteriaQuery(criteria).ToList();

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddInclude_OneIncludeAreNull_ShouldThrowException()
        {
            var criteria = new IncludeProviderAndIncludeNullCriteria();
            var clients = _clientDbSet.BuildCriteriaQuery(criteria).ToList();

        }
    }
}
