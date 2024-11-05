using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.test
{
    public class AndWithCriteriaNotProvider : Criteria<Client>
    {
        public AndWithCriteriaNotProvider(string name) 
        {
            And(c => c.Name == name);
        }
    }
}
