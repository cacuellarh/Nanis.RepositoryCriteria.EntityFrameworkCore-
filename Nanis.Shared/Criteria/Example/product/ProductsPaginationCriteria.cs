using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.product
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
