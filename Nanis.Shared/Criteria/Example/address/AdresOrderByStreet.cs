using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.address
{
    public class AdresOrderByStreet : Criteria<Address>
    {
        public AdresOrderByStreet()
        {
            AddOrderBy(addresses => addresses.OrderBy(a => a.street));
        }
    }
}
