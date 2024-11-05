using Nanis.Shared.Faker;
using Nanis.Shared.Types;

namespace Nanis.Shared.Criteria.Example.client
{
    public class ClientOrderByNameAndEmail : Criteria<Client>
    {
        public ClientOrderByNameAndEmail(OrderByType orderBy)
        {
            AddOrderBy(client => client.Name, orderBy);
            AddThenBy(client => client.Email, orderBy);
        }
    }
}
