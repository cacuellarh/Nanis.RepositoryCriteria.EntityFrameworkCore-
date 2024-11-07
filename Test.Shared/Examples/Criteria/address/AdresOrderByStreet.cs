using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;
using Nanis.Shared.Types;

namespace Nanis.Test.Shared.Examples.Criteria.address
{
    public class AdresOrderByStreet : Criteria<Address>
    {
        public AdresOrderByStreet()
        {
            AddOrderBy(addresses => addresses.street, OrderByType.Ascending);
        }
    }
}
