namespace Nanis.Test.Shared.Faker
{
    public class Address
    {
        public int Id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public Address() { }
        public Address(string street, string city, string country)
        {
            this.street = street;
            this.city = city;
            this.country = country;
        }
    }
}
