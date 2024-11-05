using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.address
{
    public class AdresOrderByStreet : Criteria<Address>
    {
        public AdresOrderByStreet()
        {
            AddOrderBy(addresses => addresses.street, Types.OrderByType.Ascending);
        }
    }
}
