using Nanis.Shared.Faker;

namespace Nanis.Shared.Criteria.Example.invoice
{
    public class InvoiceByIdCriteria : Criteria<Invoice>
    {
        public InvoiceByIdCriteria(int id)
        {
            AddCriteria(invoice => invoice.Id == id);
        }
    }
}
