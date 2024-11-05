using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.test
{
    public class KeySelectorAreNullCriteria : Criteria<Product>
    {
        public KeySelectorAreNullCriteria()
        {
            AddOrderBy(null, Types.OrderByType.Ascending);
        }
    }
}
