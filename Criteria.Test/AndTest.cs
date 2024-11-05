using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Criteria.Example.client;
using Nanis.Shared.Criteria.Example.test;
using Nanis.Shared.Exceptions;
using Nanis.Shared.Faker;

namespace Criteria.Test
{
    [TestClass]
    public class AndTest : StartUpTest
    {
        private DbSet<Client> _productDbSet;

        [TestInitialize]
        public void Setup()
        {
            _productDbSet = Fixture.CreateContext().Set<Client>();
        }

        [TestMethod]
        public void And_ValidInput_ShouldClientByNameAndEmail()
        {
            string name = "Camilo";
            string email = "camilo@gmail.com";
            var criteria = new ClientByNameAndEmailCriteria(name,email);

            var client = _productDbSet.BuildCriteriaQuery(criteria).FirstOrDefault();

            Assert.IsNotNull(client);
            Assert.AreEqual(name, client.Name);
            Assert.AreEqual(email, client.Email);
        }

        [TestMethod]
        public void And_ValidInput_ShouldClientByNameAndEmailandCountry()
        {
            string name = "Andres";
            string email = "andres@gmail.com";
            string country = "USA";

            var criteria = new ClientByNameAndEmailAndCountry(name, email,country);

            var client = _productDbSet.BuildCriteriaQuery(criteria).FirstOrDefault();

            Assert.IsNotNull(client);
            Assert.AreEqual(name, client.Name);
            Assert.AreEqual(email, client.Email);
            Assert.AreEqual(country, client.Adress.country);
        }

        [ExpectedException(typeof(CriteriaNullException))]
        [TestMethod]
        public void And_CriteriaNotProvider_ShouldThrowException()
        {
            string name = "Camilo";
            var criteria = new AndWithCriteriaNotProvider(name);

            var client = _productDbSet.BuildCriteriaQuery(criteria).FirstOrDefault();

        }
    }
}
