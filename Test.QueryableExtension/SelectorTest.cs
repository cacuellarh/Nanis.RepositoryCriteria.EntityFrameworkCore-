using Nanis.Repository;
using Nanis.Shared;
using Nanis.Shared.Criteria.product;
using Nanis.Shared.Faker;
using Test.Repository.Faker;

namespace Test.QueryableExtension
{
    [TestClass]
    public class SelectorTest : StartUpTest
    {
        private IUnitOfWork _unitOfWork;
        private IProductRepository productRepository;
        [TestInitialize]
        public void Setup()
        {
            _unitOfWork = new UnitOfWork(Fixture.CreateContext());
            productRepository = (IProductRepository)_unitOfWork.Repository<Product>();
        }

        [TestMethod]
        public async Task Selector_ShouldProductInfo()
        {
            var productsInfo = await productRepository.GetAllAsync(new ProductGetInfoCriteria());

            Assert.IsNotNull(productsInfo);
        }
    }
}
