using Nanis.Shared.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Criteria.invoice
{
    public class InvoiceByIdCriteria : Criteria<Invoice>
    {
        public InvoiceByIdCriteria(int id)
        {
            AddCriteria(invoice => invoice.Id == id);
        }
    }
}
