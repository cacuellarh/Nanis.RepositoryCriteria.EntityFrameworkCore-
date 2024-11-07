namespace Nanis.Test.Shared.Faker
{
    public class OrderItem
    {
        public OrderItem() { }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal? CalculateTotalItem() => Product.Price * Quantity;
        
    }
}