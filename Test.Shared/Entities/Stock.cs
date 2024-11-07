namespace Nanis.Test.Shared.Faker
{
    public class Stock
    {
        public Stock() { }  
        public Stock(Product product, int cuantity)
        {
            Product = product;
            Cuantity = cuantity;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Cuantity { get; set; }
    }
}
