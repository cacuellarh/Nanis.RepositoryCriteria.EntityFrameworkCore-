namespace Nanis.Test.Shared.Faker
{
    public class Client
    {
        public Client()
        { }
        public Client(string name, string email, Address address)
        {
            Name = name;
            Email = email;
            Adress = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Address Adress { get; set; }
    }
}
