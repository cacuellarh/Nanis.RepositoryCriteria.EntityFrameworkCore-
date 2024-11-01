using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.product
{
    public class ProductsPriceLessThen : Criteria<Product>
    {
        public ProductsPriceLessThen(decimal price)
        {
            AddCriteria(product => product.Price < price);
        }
    }
}
