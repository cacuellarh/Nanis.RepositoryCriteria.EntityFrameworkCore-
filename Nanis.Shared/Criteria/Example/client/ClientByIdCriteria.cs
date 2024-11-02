using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.client
{
    public class ClientByIdCriteria : Criteria<Client>
    {
        public ClientByIdCriteria(int id)
        {
            AddCriteria(criteria => criteria.Id == id);
            AddInclude(query => query.Include(client => client.Adress));
        }
    }
}
