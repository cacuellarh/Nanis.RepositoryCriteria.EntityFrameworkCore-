using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.product;

namespace Test.QueryableExtension
{
    [TestClass]
    public class SelectorTest : StartUpTest
    {
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
                .BuildCriteriaQueryWithProjection(new ProductGetInfoCriteria())
                .ToListAsync();

            Assert.IsNotNull(productsInfo);
            Assert.IsTrue(productsInfo.Any(obj => ((ProductInfoDto)obj).NameDto == "Iphone"));
        }
    }
}
