using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.client;

namespace Criteria.Test
{
    [TestClass]
    public class OrTest : StartUpTest
    {
        private DbSet<Client> _clientDbSet;

        [TestInitialize]
        public void Setup()
        {
            _clientDbSet = Fixture.CreateContext().Set<Client>();
        }

        [TestMethod]
        public void Or_ValidInput_ShouldClientsByCountryOrCity() 
        {
            string city = "Springfield";
            string country = "UK";

            var criteria = new ClientByCityOrCountryCriteria(country,city);

            var result = _clientDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Any(c => c.Adress.country == country || c.Adress.city == city));
        }
    }
}
