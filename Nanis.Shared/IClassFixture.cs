namespace Nanis.Shared
{
    public interface IClassFixture<T>
    {
        public T Fixture { get; }
    }
}
