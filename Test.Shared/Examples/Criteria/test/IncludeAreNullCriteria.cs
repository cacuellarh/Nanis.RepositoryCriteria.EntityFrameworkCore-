using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.test
{
    public class IncludeAreNullCriteria : Criteria<Client>
    {
        public IncludeAreNullCriteria()
        {
            AddInclude(null);
        }
    }
}
