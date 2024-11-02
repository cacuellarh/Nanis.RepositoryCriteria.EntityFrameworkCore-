using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.Example.product;
using Nanis.Shared.Faker;
using Test.Repository.Faker;

namespace Test.QueryableExtension
{
    [TestClass]
    public class SelectorTest : StartUpTest
    {
        private IUnitOfWork _unitOfWork;
        private DbSet<Product> _productDbSet;
        [TestInitialize]
        public void Setup()
        {
            _productDbSet = Fixture.CreateContext().Set<Product>();
        }

        [TestMethod]
        public async Task Selector_ShouldProductInfo()
        {
            var productsInfo = await _productDbSet
                .BuildCriteriaQuery(new ProductGetInfoCriteria())
                .ToListAsync();

            Assert.IsNotNull(productsInfo);
            Assert.IsTrue(productsInfo.Count > 1);
        }
    }
}
