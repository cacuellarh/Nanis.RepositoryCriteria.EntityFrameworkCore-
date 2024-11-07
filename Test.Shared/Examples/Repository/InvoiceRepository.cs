using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;
namespace Nanis.Test.Shared.Examples.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {
        }
    }
}
