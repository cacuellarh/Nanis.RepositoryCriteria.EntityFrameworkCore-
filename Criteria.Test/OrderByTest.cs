using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.Example.product;
using Nanis.Shared.Criteria.Example.test;
using Nanis.Shared.Faker;

namespace Criteria.Test
{
    [TestClass]
    public class OrderByTest : StartUpTest
    {
        private DbSet<Product> _productDbSet;

        [TestInitialize]
        public void Setup()
        {
            _productDbSet = Fixture.CreateContext().Set<Product>();
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

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void OrderBy_KeySelectorNull_ShouldThrowException()
        {
            var criteria = new KeySelectorAreNullCriteria();

            var result = _productDbSet.BuildCriteriaQuery(criteria).ToList();
        }

    }
}
