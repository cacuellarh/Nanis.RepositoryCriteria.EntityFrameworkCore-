using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.client
{
    public class ClientByNameCriteria : Criteria<Client>
    {
        public ClientByNameCriteria(string name) 
        {
            AddCriteria(client => client.Name == name);
        }
    }
}
