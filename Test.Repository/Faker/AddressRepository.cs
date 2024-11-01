using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Test.Repository.Faker
{
    public class AddressRepository : RepositoryBase<Address>, IAdressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {
        }
    }
}
