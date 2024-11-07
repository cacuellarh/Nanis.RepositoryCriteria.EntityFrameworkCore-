using Nanis.Shared.Factory;
using System.Reflection;
using Nanis.Shared;
namespace Nanis.Test.Shared
{
    public abstract class StartUpTest : IClassFixture<TestDatabaseFixture>
    {
        public StartUpTest() 
        {
            Fixture = new TestDatabaseFixture();
            var context = Fixture.CreateContext();

            UnitOfWork = new UnitOfWork(context,
                new RepositoryFactory(Assembly.GetExecutingAssembly(),context));
        }
        public TestDatabaseFixture Fixture { get; private set; }
        public IUnitOfWork UnitOfWork { get; private set; }

    }
}
