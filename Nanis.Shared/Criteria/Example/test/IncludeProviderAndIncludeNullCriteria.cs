using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.test
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
