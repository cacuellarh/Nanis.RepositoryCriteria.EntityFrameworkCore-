using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;
using Microsoft.EntityFrameworkCore;

namespace Nanis.Test.Shared.Examples.Criteria.client
{
    public class ClientByCityOrCountryCriteria : Criteria<Client>
    {
        public ClientByCityOrCountryCriteria(string country, string city)
        {
            AddCriteria(c => c.Adress.country == country);
            Or(c => c.Adress.city == city);
            AddInclude(q => q.Include(c => c.Adress));
        }
    }
}
