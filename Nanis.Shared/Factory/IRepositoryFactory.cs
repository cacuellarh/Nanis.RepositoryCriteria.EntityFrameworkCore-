
namespace Nanis.Shared.Factory
{
    public interface IRepositoryFactory
    {
        Dictionary<Type, object> GetRepositories();
    }
}