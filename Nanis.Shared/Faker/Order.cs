using Moq;

namespace Nanis.Shared.Faker
{
    public class Order
    {
        public Order()
        { }
        public Order(Client client, List<OrderItem> items, PaymentMethod paymentMethod)
        {
            Client = client;
            this.items = items;
            PaymentMethod = paymentMethod;
        }

        public int Id { get; set; }
        public Client Client { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int PaymentMethodId { get; set; }
        public List<OrderItem> items { get; set; }

        public decimal CalculateTotal()
        {
            decimal? total = 0;  

            foreach (var item in items)
            {
                total += item.CalculateTotalItem();
            }

            return total.Value;
        }
    }
}
