using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.product
{
    public class ProductGetInfoCriteria : Criteria<Product>
    {
        public ProductGetInfoCriteria()
        {
            Selector = product => new { product.Name, product.Price };
        }
    }
}
