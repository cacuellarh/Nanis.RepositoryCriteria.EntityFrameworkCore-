using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.client;
using Nanis.Test.Shared.Examples.Criteria.order;

namespace Criteria.Test
{
    [TestClass]
    public class NotTest : StartUpTest
    {
        private DbSet<Order> _orderDbSet;
        private DbSet<Client> _clientDbSet;

        [TestInitialize]
        public void Setup()
        {
            _orderDbSet = Fixture.CreateContext().Set<Order>();
            _clientDbSet = Fixture.CreateContext().Set<Client>();
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

        [TestMethod]
        public void Not_ValidCriteria_ShouldClients()
        {
            string name = "Luis";
            string email = "luis@gmail.com";
            string country = "UK";

            var criteria = new ClientByNameAndEmailOrCountryCriteria(name, email, country);

            var clients = _clientDbSet.BuildCriteriaQuery(criteria.Not()).ToList();

            Assert.IsNotNull(clients);
            Assert.IsTrue(clients.Any());
            Assert.IsTrue(clients.All(c => c.Name != name && c.Email != email && c.Adress.country != country));
        }
    }
}
