﻿namespace Nanis.Test.Shared.Faker
{
    public class Product
    {
        public Product() { }    
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public string? Name { get; set; } 
        public decimal? Price { get; set; }
    }
}
