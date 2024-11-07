using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;
using Nanis.Shared.Types;

namespace Nanis.Test.Shared.Examples.Criteria.client
{
    public class ClientOrderByNameAndStreet : Criteria<Client>
    {
        public ClientOrderByNameAndStreet(string name,OrderByType orderBy)
        {
            AddCriteria(c => c.Name == name);
            AddOrderBy(
                client => client.Name,
                client => client.Adress.street,
                orderBy);

            AddInclude(q => q.Include(c => c.Adress));
        }
    }
}
