using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.client
{
    public class ClientByNameAndEmailOrCountryCriteria : Criteria<Client>
    {
        public ClientByNameAndEmailOrCountryCriteria(string name, string email, string country)
        {
            AddCriteria(c => c.Name == name);
            And(c => c.Email == email);
            Or(c => c.Adress.country == country);
            AddInclude(q => q.Include(c => c.Adress));
        }
    }
}
