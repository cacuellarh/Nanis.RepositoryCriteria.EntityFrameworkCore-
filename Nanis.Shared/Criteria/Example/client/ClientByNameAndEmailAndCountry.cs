using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.client
{
    public class ClientByNameAndEmailAndCountry : Criteria<Client>
    {
        public ClientByNameAndEmailAndCountry(string name, string email, string country) 
        {
            AddInclude(q => q.Include(c => c.Adress));
            AddCriteria(c => c.Name == name);
            And(c => c.Email == email,
                c => c.Adress.country == country);
        }
    }
}
