using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.client
{
    public class ClientByNameCriteria : Criteria<Client>
    {
        public ClientByNameCriteria(string name)
        {
            AddCriteria(client => client.Name == name);
        }
    }
}
