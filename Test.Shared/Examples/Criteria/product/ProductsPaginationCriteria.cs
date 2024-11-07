using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.product
{
    public class ProductsPaginationCriteria : Criteria<Product>
    {
        public ProductsPaginationCriteria(int page, int take)
        {
            int skip = (page - 1) * take;
            AddPagination(skip, take);
        }
    }
}
