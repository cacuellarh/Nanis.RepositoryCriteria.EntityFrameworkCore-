using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context)
        {
        }
    }
}
