namespace Nanis.Shared.Faker
{
    public class PaymentMethod
    {
        public PaymentMethod() { }
        public PaymentMethod(string type)
        {
            Type = type;
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
