using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;
using Nanis.Shared.Types;

namespace Nanis.Test.Shared.Examples.Criteria.test
{
    public class KeySelectorAreNullCriteria : Criteria<Product>
    {
        public KeySelectorAreNullCriteria()
        {
            AddOrderBy(null, OrderByType.Ascending);
        }
    }
}
