using Nanis.Criteria;
using Nanis.Shared.Faker;
namespace Nanis.Shared.Criteria.address
{
    public class AddressByIdCriteria : Criteria<Address>
    {
        public AddressByIdCriteria(int id)
        {
            AddCriteria(address => address.Id == id);
        }
    }
}
