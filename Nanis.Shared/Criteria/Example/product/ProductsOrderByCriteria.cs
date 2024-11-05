using Nanis.Shared.Faker;
using Nanis.Shared.Types;

namespace Nanis.Shared.Criteria.Example.product
{
    public class ProductsOrderByCriteria : Criteria<Product>
    {
        public ProductsOrderByCriteria(OrderByType orderType) 
        {
            AddOrderBy(product => product.Price, orderType);
        }
    }
}
