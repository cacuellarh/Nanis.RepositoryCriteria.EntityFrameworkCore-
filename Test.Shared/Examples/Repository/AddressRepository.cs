using Nanis.Repository;
using Nanis.Shared.Faker;
using Microsoft.EntityFrameworkCore;

namespace Nanis.Test.Shared.Examples.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {
        }
    }
}
