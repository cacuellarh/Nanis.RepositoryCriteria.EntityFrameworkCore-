using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;
using Microsoft.EntityFrameworkCore;

namespace Nanis.Test.Shared.Examples.Criteria.test
{
    public class IncludeProviderAndIncludeNullCriteria : Criteria<Client>
    {
        public IncludeProviderAndIncludeNullCriteria()
        {
            AddInclude(
                query => query.Include(client => client.Adress),
                null
                );
        }
    }
}
