using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.client
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
