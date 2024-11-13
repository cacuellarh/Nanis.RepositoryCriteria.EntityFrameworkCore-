using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.product;
using Nanis.Test.Shared.Examples.Repository;

namespace Test.Repository
{
    [TestClass]
    public class CountTest : StartUpTest
    {
        private IProductRepository productRepository;
        [TestInitialize]
        public void Setup()
        {
            productRepository = UnitOfWork.Repository<Product, IProductRepository>();
        }

        [TestMethod]
        public void CountSync_ValidInput_ShouldProductsCount() 
        {
            var count = productRepository.Count();
            Assert.IsNotNull(count);
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public async Task CountAsync_ValidInput_ShouldProductsCount()
        {
            var count = await productRepository.CountAsync();
            Assert.IsNotNull(count);
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public async Task CountAsyncByCriteria_ValidInput_ShouldProductsCount()
        {
            var criteria = new ProductsPriceLessThen(2500);
            var count = await productRepository.CountAsync(criteria);
            Assert.IsNotNull(count);
            Assert.IsTrue(count >= 9);
        }

        [TestMethod]
        public void CountSyncByCriteria_ValidInput_ShouldProductsCount()
        {
            var criteria = new ProductsPriceLessThen(2500);
            var count =  productRepository.Count(criteria);
            Assert.IsNotNull(count);
            Assert.IsTrue(count >= 9);
        }
    }
}
