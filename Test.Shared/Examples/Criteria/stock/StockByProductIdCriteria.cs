using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.stock
{
    public class StockByProductIdCriteria : Criteria<Stock>
    {
        public StockByProductIdCriteria(int id)
        {
            AddCriteria(stock => stock.Product.Id == id);
        }
    }
}
