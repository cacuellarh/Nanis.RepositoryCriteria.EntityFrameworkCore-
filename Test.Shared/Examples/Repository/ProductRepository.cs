using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
