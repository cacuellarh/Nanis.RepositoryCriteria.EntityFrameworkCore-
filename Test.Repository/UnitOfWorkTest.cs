using Nanis.Repository;
using Nanis.Shared;
using Nanis.Shared.Faker;
using Test.Repository.Faker;

namespace Test.Repository
{
    [TestClass]
    public class UnitOfWorkTest : StartUpTest
    {
        [TestMethod]
        public void Repository_ShouldRepositoryInstance()
        {
            IUnitOfWork uow = new UnitOfWork(Fixture.CreateContext());

            var productRepository = uow.Repository<Product>();
            var orderRepository = uow.Repository<Order>();
            
            Assert.IsNotNull(productRepository);
            Assert.IsTrue(productRepository.GetType() == typeof(ProductRepository));

            Assert.IsNotNull(orderRepository);
            Assert.IsTrue(orderRepository.GetType() == typeof(OrderRepository));
        }
    }
}