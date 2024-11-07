using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.address
{
    public class AddressByIdCriteria : Criteria<Address>
    {
        public AddressByIdCriteria(int id)
        {
            AddCriteria(address => address.Id == id);
        }
    }
}
