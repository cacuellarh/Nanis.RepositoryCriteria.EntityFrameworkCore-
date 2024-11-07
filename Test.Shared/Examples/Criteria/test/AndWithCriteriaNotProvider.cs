using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.test
{
    public class AndWithCriteriaNotProvider : Criteria<Client>
    {
        public AndWithCriteriaNotProvider(string name)
        {
            And(c => c.Name == name);
        }
    }
}
