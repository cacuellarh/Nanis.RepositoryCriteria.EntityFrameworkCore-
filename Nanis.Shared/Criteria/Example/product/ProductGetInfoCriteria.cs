using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.product
{
    public class ProductGetInfoCriteria : Criteria<Product>
    {
        public ProductGetInfoCriteria()
        {
            Selector = product => new { product.Name, product.Price };
        }
    }
}
