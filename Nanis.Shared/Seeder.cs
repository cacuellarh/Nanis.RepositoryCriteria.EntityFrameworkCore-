using Nanis.Shared.Faker;

namespace Nanis.Shared
{
    public static class Seeder
    {
        private static List<Product> products = new List<Product>();
        public static List<Product> Products 
        { 
            get 
            { 
                return products; 
            } 
        }
        public static List<Client> Clients
        { 
            get 
            {
                return clients;
            }
        }
        private static List<Client> clients = new List<Client>();
        public static List<Order> Orders
        {
            get
            {
                return orders;
            }
        }
        private static List<Order> orders = new List<Order>();

        private static List<Address> addresses = new List<Address>();
        public static List<Address> AdDrresses

        {
            get
            {
                return addresses;
            }
        }

        private static List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
        public static List<PaymentMethod> PaymentMethods

        {
            get
            {
                return paymentMethods;
            }
        }

        private static List<OrderItem> orderItems = new List<OrderItem>();
        public static List<OrderItem> OrderItems

        {
            get
            {
                return orderItems;
            }
        }

        private static List<Stock> stock = new List<Stock>();
        public static List<Stock> Stock

        {
            get
            {
                return stock;
            }
        }

        static Seeder()
        {
            SeedPaymentMethods();
            SeedAddresses();
            SeedClients();
            SeedProducts();
            SeedStock();
            SeedOrderItems();
            SeedOrders();

        }
        public static void SeedProducts()
        {
            if (products.Count == 0)
            {
                products.Add(new Product("Iphone", 5000));
                products.Add(new Product("Play 5", 2000));
                products.Add(new Product("X-box", 6000));
                products.Add(new Product("GPU", 8000));
                products.Add(new Product("Laptop", 15000));
                products.Add(new Product("Tablet", 3000));
                products.Add(new Product("Smartwatch", 2000));
                products.Add(new Product("Auriculares", 6000));
                products.Add(new Product("Monitor", 3500));
                products.Add(new Product("Teclado Mecánico", 1200));
                products.Add(new Product("Mouse Gamer", 600));
                products.Add(new Product("Router WiFi", 1300));
                products.Add(new Product("Disco Duro Externo", 2200));
                products.Add(new Product("Cámara Web HD", 1500));
                products.Add(new Product("Conector", 1500));
                products.Add(new Product("Cable", 9500));
                products.Add(new Product("Quatum", 2000));
            }

        }

        public static void SeedAddresses()
        {
            if (addresses.Count == 0)
            {
                addresses.Add(new Address("123 Maple St", "Springfield", "USA"));
                addresses.Add(new Address("456 Oak Ave", "Shelbyville", "USA"));
                addresses.Add(new Address("789 Pine Blvd", "Capital City", "USA"));
                addresses.Add(new Address("101 Cedar Ln", "Ogdenville", "USA"));
                addresses.Add(new Address("202 Birch Rd", "North Haverbrook", "USA"));
                addresses.Add(new Address("202 Birch Rd", "West Haverbrook", "USA"));
            }

        }

        public static void SeedClients()
        {
            if (clients.Count == 0)
            {
                clients.Add(new Client("Camilo", "camilo@gmail.com", addresses[0]));
                clients.Add(new Client("Andres", "andres@gmail.com", addresses[1]));
                clients.Add(new Client("Mateo", "mateo@gmail.com", addresses[2]));
                clients.Add(new Client("Luis", "luis@gmail.com", addresses[3]));
                clients.Add(new Client("Luis", "luis@gmail.com", addresses[5]));
            }

        }

        public static void SeedOrders()
        {
            if (orders.Count == 0)
            {
                orders.Add(new Order(clients[0], orderItems, paymentMethods[0]));
                orders.Add(new Order(clients[4], orderItems, paymentMethods[0]));
                orders.Add(new Order(clients[1], orderItems, paymentMethods[0]));
                orders.Add(new Order(clients[2], orderItems, paymentMethods[1]));
                orders.Add(new Order(clients[3], orderItems, paymentMethods[1]));
                orders.Add(new Order(clients[3], orderItems, paymentMethods[0]));

            }
        }

        public static void SeedOrderItems()
        {
            if (orderItems.Count == 0)
            {
                orderItems.Add(new OrderItem(products[0],5));
                orderItems.Add(new OrderItem(products[1], 3));
            }
        }

        public static void SeedPaymentMethods()
        {
            if (paymentMethods.Count == 0)
            {
                paymentMethods.Add(new PaymentMethod("Visa"));
                paymentMethods.Add(new PaymentMethod("cash"));
            }
        }

        public static void SeedStock()
        {
            if (stock.Count == 0)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    stock.Add(new Stock(products[i],i + 5));
                }
            }
        }
    }
}
