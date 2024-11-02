using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.product
{
    public class ProductsPriceLessThen : Criteria<Product>
    {
        public ProductsPriceLessThen(decimal price)
        {
            AddCriteria(product => product.Price < price);
        }
    }
}
