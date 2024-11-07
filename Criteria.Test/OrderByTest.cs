using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nanis.Shared;
using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.client;
using Nanis.Test.Shared.Examples.Criteria.product;
using Nanis.Test.Shared.Examples.Criteria.test;

namespace Criteria.Test
{
    [TestClass]
    public class OrderByTest : StartUpTest
    {
        private DbSet<Product> _productDbSet;
        private DbSet<Client> _clientDbSet;

        [TestInitialize]
        public void Setup()
        {
            _productDbSet = Fixture.CreateContext().Set<Product>();
            _clientDbSet = Fixture.CreateContext().Set<Client>();
        }

        [TestMethod]
        public void GetProducts_ShouldOrderByAscending()
        {
            var criteria = new ProductsOrderByCriteria(Nanis.Shared.Types.OrderByType.Ascending);
            var products = _productDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(products);
            decimal? lastPrice = null;
            foreach (var product in products)
            {
                if (lastPrice.HasValue)
                {
                    Assert.IsTrue(lastPrice <= product.Price);
                }
                lastPrice = product.Price;
            }
        }

        [TestMethod]
        public void GetProducts_ShouldOrderByDescending()
        {
            var criteria = new ProductsOrderByCriteria(Nanis.Shared.Types.OrderByType.Descending);
            var products = _productDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(products);
            decimal? lastPrice = null;

            foreach (var product in products)
            {
                if (lastPrice.HasValue)
                {
                    Assert.IsTrue(lastPrice >= product.Price);
                }
                lastPrice = product.Price;
            }
        }

        [TestMethod]
        public void ThenBy_ValidInput_ShouldClientsOrderByAscendingByNameAndStreet()
        {
            var criteria = new ClientOrderByNameAndStreet("Albeiro",Nanis.Shared.Types.OrderByType.Ascending);
            var clients = _clientDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(clients);
            Assert.IsTrue(clients.Count > 0);

            string lastStreet = "";

            foreach (var client in clients)
            {
                if (!lastStreet.IsNullOrEmpty())
                {
                    Assert.IsTrue(lastStreet[0] < client.Adress.street[0]);
                }
                lastStreet = client.Adress.street;
            }
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void OrderBy_KeySelectorNull_ShouldThrowException()
        {
            var criteria = new KeySelectorAreNullCriteria();

            var result = _productDbSet.BuildCriteriaQuery(criteria).ToList();
        }

    }
}
