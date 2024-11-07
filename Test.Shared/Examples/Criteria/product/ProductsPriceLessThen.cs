using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.product
{
    public class ProductsPriceLessThen : Criteria<Product>
    {
        public ProductsPriceLessThen(decimal price)
        {
            AddCriteria(product => product.Price < price);
        }
    }
}
