using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.client
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
