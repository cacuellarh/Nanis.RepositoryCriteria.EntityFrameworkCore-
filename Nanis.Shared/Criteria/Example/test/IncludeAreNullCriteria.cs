using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.test
{
    public class IncludeAreNullCriteria : Criteria<Client>
    {
        public IncludeAreNullCriteria() 
        {
            AddInclude(null);
        }
    }
}
