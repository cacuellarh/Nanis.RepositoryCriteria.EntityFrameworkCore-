using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.client;

namespace Criteria.Test
{
    [TestClass]
    public class AndOrCombinationTest : StartUpTest
    {
        private DbSet<Client> _clientDbSet;

        [TestInitialize]
        public void Setup()
        {
            _clientDbSet = Fixture.CreateContext().Set<Client>();
        }

        [TestMethod]
        public void AndOr_ValidInput_ShouldClientWithNameAndEmailOrClientCountry()
        {
            string name = "Luis";
            string email = "luis@gmail.com";
            string country = "UK";

            var criteria = new ClientByNameAndEmailOrCountryCriteria(name,email,country);

            var clients = _clientDbSet.BuildCriteriaQuery(criteria).ToList();

            Assert.IsNotNull(clients);
            Assert.AreEqual(2, clients.Count);
        }
    }
}
