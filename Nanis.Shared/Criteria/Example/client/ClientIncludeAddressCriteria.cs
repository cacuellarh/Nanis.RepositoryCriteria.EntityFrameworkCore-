using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.client
{
    public class ClientIncludeAddressCriteria : Criteria<Client>
    {
        public ClientIncludeAddressCriteria() 
        {
            AddInclude(query => query
            .Include(client => client.Adress));
        }
    }
}
