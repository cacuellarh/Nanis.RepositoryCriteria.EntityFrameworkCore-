using Nanis.Repository;
using Nanis.Shared;
using Nanis.Shared.Criteria.address;
using Nanis.Shared.Criteria.order.CombinedTest;
using Nanis.Shared.Faker;

namespace Test.Repository
{
    [TestClass]
    public class RepositoryCrudTest : StartUpTest
    {
        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _unitOfWork = new UnitOfWork(Fixture.CreateContext());
        }

        [TestMethod]
        public void Get_ShouldProducts()
        { 
            var productRepository = _unitOfWork.Repository<Product>();
            var products = productRepository.GetAll();

            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Get_WithCriteriaShouldProductPriceGreaterThan3000()
        {

            var productRepository = _unitOfWork.Repository<Product>();
            var products = productRepository.GetAll();

            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public async Task Get_WithCriteria_shouldOrderByIdAndPaymentMethod()
        {
            int idOrder = 1;
            int clientId = 1;
            var orderRepository = _unitOfWork.Repository<Order>();
            var orderCriteria = new OrderByIdOrClientIdCriteria(idOrder, clientId);
            var products = await orderRepository.GetAsync(orderCriteria);

            Assert.IsNotNull(products);

        }

        [TestMethod]
        public async Task GetAllAsync_GetAdressOrderByStreet()
        {
            var addressRepository = _unitOfWork.Repository<Address>();
            var addresByStreet = new AdresOrderByStreet();
            var orders = await addressRepository.GetAllAsync(addresByStreet);

            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 1);

        }

        [TestMethod]
        public async Task CreateAsync_ShouldCreatedAddress()
        {
            var address = new Address("Cll 67 - 90","Armenia","Colombia");
            var addressRepository = _unitOfWork.Repository<Address>();
            var operation = addressRepository.CreateAsync(address);
            int entitiesAffect = await _unitOfWork.Commit();

            Assert.AreEqual(1, entitiesAffect);
        }

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateAddress()
        {
            var addressRepository = _unitOfWork.Repository<Address>();
            var getAddressById = new AddressByIdCriteria(1);
            var addressToUpdate = await addressRepository.GetAsync(getAddressById);

            addressToUpdate.city = "Medellin";

            await addressRepository.UpdateAsync(addressToUpdate);

            int rowAffected = await _unitOfWork.Commit();

            Assert.AreEqual(1, rowAffected);

            var getAddressUpdated = await addressRepository.GetAsync(getAddressById);

            Assert.AreEqual(getAddressUpdated.city, "Medellin");

        }

    }
}
