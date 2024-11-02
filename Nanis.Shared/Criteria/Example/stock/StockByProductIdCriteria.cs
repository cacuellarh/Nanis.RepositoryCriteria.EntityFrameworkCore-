using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.stock
{
    public class StockByProductIdCriteria : Criteria<Stock>
    {
        public StockByProductIdCriteria(int id)
        {
            AddCriteria(stock => stock.Product.Id == id);
        }
    }
}
