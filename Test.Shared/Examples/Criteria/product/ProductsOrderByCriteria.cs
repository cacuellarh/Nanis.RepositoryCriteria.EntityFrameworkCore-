using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;
using Nanis.Shared.Types;

namespace Nanis.Test.Shared.Examples.Criteria.product
{
    public class ProductsOrderByCriteria : Criteria<Product>
    {
        public ProductsOrderByCriteria(OrderByType orderType)
        {
            AddOrderBy(product => product.Price, orderType);
        }
    }
}
