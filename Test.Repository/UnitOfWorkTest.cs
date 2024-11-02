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
            IUnitOfWork uow = UnitOfWork;

            var productRepository = uow.Repository<Product,IProductRepository>();
            var orderRepository = uow.Repository<Order, IOrderRepository>();
            
            Assert.IsNotNull(productRepository);
            Assert.IsTrue(productRepository.GetType() == typeof(ProductRepository));

            Assert.IsNotNull(orderRepository);
            Assert.IsTrue(orderRepository.GetType() == typeof(OrderRepository));
        }
    }
}