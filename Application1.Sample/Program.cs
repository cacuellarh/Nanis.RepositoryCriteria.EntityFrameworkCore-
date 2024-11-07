
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nanis.Repository;
using Nanis.Shared;
using Nanis.Shared.Criteria;
using Nanis.Shared.Factory;
using System.Reflection;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<MyDbContext>(options =>
            options.UseInMemoryDatabase("MyDatabase"));

        services.AddSingleton<IRepositoryFactory>(provider =>
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var dbContext = provider.GetRequiredService<MyDbContext>();
            return new RepositoryFactory(currentAssembly, dbContext);
        });

        services.AddTransient<IUnitOfWork>(provider => {
            var dbContext = provider.GetRequiredService<MyDbContext>();
            var factory = provider.GetRequiredService<IRepositoryFactory>();
            return new UnitOfWork(dbContext, factory);
        });

        var serviceProvider = services.BuildServiceProvider();

        var dbContext = serviceProvider.GetRequiredService<MyDbContext>();
        dbContext.Database.EnsureCreated();

        var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        var productRepository = unitOfWork.Repository<Product,IProductRepository>();

        var newProduct = new Product
        {
            Id = 4,
            Name = "Product D",
            CategoryId = 1,
            LocationId = 1,
            Description = "Description of Product D",
        };

        await productRepository.CreateAsync(newProduct);
        await unitOfWork.Commit();

        var productCriteria = new ProductByCountryCriteria("USA");
        var products = await productRepository.GetAllAsync(productCriteria);

        var productCombinedCriterias = new ProductByNameAndCountry("Product D", "USA");
        var productDto = await productRepository.GetAsyncWithProyection(productCombinedCriterias);
    }

}

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Tecnology" },
            new Category { Id = 2, Name = "Sports" }
        );

        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, City = "New York", Country = "USA" },
            new Location { Id = 2, City = "Madrid", Country = "Spain" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product A",
                Description = "Description of Product A",
                CategoryId = 1, 
                LocationId = 1  
            },
            new Product
            {
                Id = 2,
                Name = "Product B",
                Description = "Description of Product B",
                CategoryId = 2, 
                LocationId = 2  
            },
            new Product
            {
                Id = 3,
                Name = "Product C",
                Description = "Description of Product C",
                CategoryId = 1, 
                LocationId = 1  
            }
        );
    }
}
public interface IProductRepository : IRepository<Product>
{ 
    
}

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public int LocationId { get; set; }
    public Category Category { get; set; }
    public Location Location { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Location
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

//Defining Query Criteria
public class ProductByCountryCriteria : Criteria<Product>
{
    public ProductByCountryCriteria(string country)
    {
        AddCriteria(p => p.Location.Country == country);

    }
}
public class ProductByNameCriteria : Criteria<Product>
{
    public ProductByNameCriteria(string productName)
    {
        AddCriteria(p => p.Name == productName);
        
    }
}

public class ProductByNameAndCountry : Criteria<Product>
{
    public ProductByNameAndCountry(string name, string country)
    {
        AddCriteria(new ProductByNameCriteria(name).GetCriteria);
        And(new ProductByCountryCriteria(country).GetCriteria);
        AddInclude(
            q => q.Include(p => p.Location),
            q => q.Include(p => p.Category)
        );
        Select(p => new { description = p.Description, name = p.Name });

    }
}