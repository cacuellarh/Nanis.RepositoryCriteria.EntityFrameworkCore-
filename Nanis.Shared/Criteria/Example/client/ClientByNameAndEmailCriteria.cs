using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.client
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
