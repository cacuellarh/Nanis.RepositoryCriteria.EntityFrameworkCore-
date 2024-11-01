using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Nanis.Repository.Factory
{
    public static class RepositoryFactory
    {
        private static Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public static Dictionary<Type, object> GetRepositories(Assembly _currentAssembly, DbContext currentContext)
        {
            var repositoryType = typeof(RepositoryBase<>);
            var allTypes = _currentAssembly.GetTypes();
            var typesFromBaseRepository = allTypes

            .Where(t => t.IsClass && !t.IsAbstract && t.BaseType != null &&
                        t.BaseType.IsGenericType &&
                        t.BaseType.GetGenericTypeDefinition() == repositoryType)
            .ToList();

            foreach (var type in typesFromBaseRepository)
            { 
                var repositoryInstance = Activator.CreateInstance(type, currentContext);
                if (!repositories.ContainsKey(type))
                { 
                    repositories.Add(type, repositoryInstance);
                }
            }

            return repositories;
        }
    }
}
