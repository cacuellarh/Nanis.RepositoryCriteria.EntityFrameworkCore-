using Moq;

namespace Nanis.Shared
{
    public abstract class StartUpTest : IClassFixture<TestDatabaseFixture>
    {
        protected Mock<NanisTestContext> _context;
        public StartUpTest() 
        {
            Fixture = new TestDatabaseFixture();    
        }

        public TestDatabaseFixture Fixture { get; private set; }

    }
}
