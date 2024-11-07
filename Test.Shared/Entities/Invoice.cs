namespace Nanis.Test.Shared.Faker
{
    public class Invoice
    {
        public Invoice(Client client, decimal total)
        {
            Client = client;
            Total = total;
        }

        public Invoice() { }
        public int Id { get; set; }
        public Client Client { get; set; }
        public decimal Total { get; set; }
    }
}
