using Nanis.Criteria;
using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.invoice
{
    public class InvoiceByIdCriteria : Criteria<Invoice>
    {
        public InvoiceByIdCriteria(int id) 
        {
            AddCriteria(invoice => invoice.Id == id);
        }
    }
}
