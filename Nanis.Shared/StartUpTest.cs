using Nanis.Shared.Factory;
using System.Reflection;

namespace Nanis.Shared
{
    public abstract class StartUpTest : IClassFixture<TestDatabaseFixture>
    {
        public StartUpTest() 
        {
            Fixture = new TestDatabaseFixture();
            var context = Fixture.CreateContext();

            UnitOfWork = new UnitOfWork(context,
                new RepositoryFactory(Assembly.GetCallingAssembly(),context));
        }
        public TestDatabaseFixture Fixture { get; private set; }
        public IUnitOfWork UnitOfWork { get; private set; }

    }
}
