using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.Example.client;
using Nanis.Shared.Criteria.Example.test;
using Nanis.Shared.Exceptions;
using Nanis.Shared.Faker;

namespace Criteria.Test
{
    [TestClass]
    public class AddCriteriaTest : StartUpTest
    {
        private DbSet<Client> _clientDbSet;

        [TestInitialize]
        public void Setup()
        {
            _clientDbSet = Fixture.CreateContext().Set<Client>();
        }

        [TestMethod]
        public void AddCriteria_ValidValues_ShouldClientsByName() 
        {
            string name = "Camilo";
            var criteria = new ClientByNameCriteria(name);

            var client = _clientDbSet.BuildCriteriaQuery(criteria).FirstOrDefault();

            Assert.IsNotNull(client);
            Assert.AreEqual(name, client.Name);
        }

        [ExpectedException(typeof(CriteriaNullException))]
        [TestMethod]
        public void AddCriteria_NullCriteria_ShouldThrowException()
        {

            var client = _clientDbSet.BuildCriteriaQuery(null).FirstOrDefault();

            Assert.IsNull(client);
        }

        [ExpectedException(typeof(CriteriaPropertiesAreNullException))]
        [TestMethod]
        public void AddCriteria_EmptyPropertiesCriteria_ShouldThrowException()
        {
            var criteria = new EmptyCriteria();
            var client = _clientDbSet.BuildCriteriaQuery(criteria);

            Assert.IsNull(client);
        }
    }
}
