using Nanis.Repository;
using Nanis.Shared.Faker;
namespace Test.Repository.Faker
{
    public interface IProductRepository : IRepository<Product>
    {
        public int PRUEBA();
    }
}
