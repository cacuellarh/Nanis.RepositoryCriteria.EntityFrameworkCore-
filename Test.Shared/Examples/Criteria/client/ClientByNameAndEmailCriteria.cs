using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.client
{
    public class ClientByNameAndEmailCriteria : Criteria<Client>
    {
        public ClientByNameAndEmailCriteria(string name, string email)
        {
            AddCriteria(client => client.Name == name);
            And(client => client.Email == email);
        }
    }
}
