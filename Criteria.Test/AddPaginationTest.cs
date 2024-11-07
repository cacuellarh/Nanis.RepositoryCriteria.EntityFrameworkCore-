using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.product;

namespace Criteria.Test
{
    [TestClass]
    public class AddPaginationTest : StartUpTest
    {
        private DbSet<Product> _productDbSet;

        [TestInitialize]
        public void Setup()
        {
            _productDbSet = Fixture.CreateContext().Set<Product>();
        }

        [TestMethod]
        public void GetProducts_ShuldTake3()
        {
            int take = 5;
            int page = 1;

            var productsPage1 = _productDbSet.BuildCriteriaQuery(new ProductsPaginationCriteria(page, take)).ToList();
            var productsPage2 = _productDbSet.BuildCriteriaQuery(new ProductsPaginationCriteria(page + 1, take)).ToList();

            Assert.IsNotNull(productsPage1);
            Assert.IsNotNull(productsPage2);

            var x = 0;
            foreach (var product in productsPage1)
            {               
                Assert.AreEqual(product.Id, x+1);
                x++;
            }

            var j = 5;
            foreach (var product in productsPage2)
            {
                Assert.AreEqual(product.Id, x + 1);
                x++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPagination_NegativeSkip_ShouldThrowException()
        {
            var criteria = new ProductsPaginationCriteria(-1, 6);
            var productsPage1 = _productDbSet.BuildCriteriaQuery(criteria).ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPagination_NegativeTake_ShouldThrowException()
        {
            var criteria = new ProductsPaginationCriteria(3, -3);
            var productsPage1 = _productDbSet.BuildCriteriaQuery(criteria).ToList();
        }
    }
}
