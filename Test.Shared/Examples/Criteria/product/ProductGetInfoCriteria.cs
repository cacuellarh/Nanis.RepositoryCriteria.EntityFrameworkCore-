using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.product
{
    public class ProductGetInfoCriteria : Criteria<Product>
    {
        public ProductGetInfoCriteria()
        {
            AddCriteria(p => p.Price > 2000);
            Select(p => new ProductInfoDto { NameDto = p.Name});
        }
    }
}

public class ProductInfoDto
{
    public string NameDto { get; set; }
}