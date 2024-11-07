using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using System.Reflection;

namespace Nanis.Shared.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private Assembly _currentAssembly;
        private DbContext _currentContext;
        public RepositoryFactory(Assembly currentAssembly,
            DbContext currentContext)
        {
            _currentAssembly = currentAssembly;
            _currentContext = currentContext;
        }
        public Dictionary<Type, object> GetRepositories()
        {
            var repositoryType = typeof(Repository<>);
            var allTypes = _currentAssembly.GetTypes();
            var typesFromBaseRepository = allTypes
            .Where(t => t.IsClass && !t.IsAbstract && t.BaseType != null &&
                        t.BaseType.IsGenericType &&
                        t.BaseType.GetGenericTypeDefinition() == repositoryType)
            .ToList();

            foreach (var type in typesFromBaseRepository)
            {
                var typeGenericBase = type.BaseType
                    .GetGenericArguments()
                    .FirstOrDefault();

                var repositoryInstance = Activator.CreateInstance(type, _currentContext);
                if (!repositories.ContainsKey(type))
                {
                    repositories.Add(typeGenericBase, repositoryInstance);
                }
            }

            return repositories;
        }
    }
}
