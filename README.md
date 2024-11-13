# Nanis Repository Library

Nanis.RepositoryCriteria.EntityFrameworkCore is a library designed to implement an abstraction of the **Repository** pattern using **Entity Framework**. This library also implements the **Unit of Work** pattern to manage database transactions and commits, and the **Criteria** pattern to build complex queries with logical operators and criteria composition.

## Key Features

- **Repository Pattern**: Provides an abstraction for data access using **Entity Framework**, enabling operations such as `Create`, `Read`, `Update`, and `Delete`.
- **Unit of Work Pattern**: Manages transactions centrally, allowing commits or rollbacks of changes to the database.
- **Criteria Pattern**: Allows building dynamic and robust queries with filters, sorting, pagination, and entity relationships.

## Installation

### Using NuGet

You can install this library directly from NuGet into your .NET project by running the following command:

dotnet add package Nanis.RepositoryCriteria.EntityFrameworkCore

## Manual Installation

git clone https://github.com/cacuellarh/Nanis.RepositoryCriteria.EntityFrameworkCore-

## Usage
# dependencies
```csharp

//Register the current Dbcontenttext in a container
services.AddDbContext<MyDbContext>(options =>
	options.UseInMemoryDatabase("MyDatabase"));


//Registering the Repository Factory
//An instance of IRepositoryFactory is registered, responsible for creating repositories.
//It uses the current assembly and DbContext to configure the factory.
//If the solution contains multiple layers or projects, the assembly where repositories are implemented must be specified, allowing the factory to retrieve them.

//repositories defined in the same project
services.AddSingleton<IRepositoryFactory>(provider =>
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var dbContext = provider.GetRequiredService<MyDbContext>();
        return new RepositoryFactory(currentAssembly, dbContext);
    });

//Assembly of an application layer using clean architecture

services.AddScoped<IRepositoryFactory>(provider =>
    {
        var applicationAssembly = Assembly.Load("Spa.Application");
        var dbContext = provider.GetRequiredService<SpaContext>();
        return new RepositoryFactory(applicationAssembly, dbContext);
    });

//Registering the Unit of Work Pattern
services.AddTransient<IUnitOfWork>(provider => {
    var dbContext = provider.GetRequiredService<MyDbContext>();
    var factory = provider.GetRequiredService<IRepositoryFactory>();
    return new UnitOfWork(dbContext, factory);
});

```

# Creating a New Entity and repository
```csharp
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

public interface IProductRepository : IRepository<Product>
{ 
    
}

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
}

public class Location
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

# Defining Criteria for Product Query
```csharp
    
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
```

# Complete example of how to use unit of work, repository and criteria application
```csharp

// Retrieves an instance of IUnitOfWork from the service provider.
// The Unit of Work pattern is used to manage transactions across multiple operations,
// allowing changes to be committed or rolled back as a single unit.
var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

// Retrieves the Product repository from the Unit of Work instance.
// This repository will be used to handle data access specifically for Product entities.
var productRepository = unitOfWork.Repository<Product, IProductRepository>();

// Creates a new Product entity with specific properties.
var newProduct = new Product
{
    Id = 4,
    Name = "Product D",
    CategoryId = 1,
    LocationId = 1,
    Description = "Description of Product D",
};

// Asynchronously adds the new product to the repository.
await productRepository.CreateAsync(newProduct);

// Commits all changes made within the current unit of work to the database.
await unitOfWork.Commit();

// Creates a criteria to filter products by the country "USA".
var productCriteria = new ProductByCountryCriteria("USA");

// Retrieves all products that match the specified criteria asynchronously.
var products = await productRepository.GetAllAsync(productCriteria);

// Creates a combined criteria to filter products by both name and country.
var productCombinedCriterias = new ProductByNameAndCountry("Product D", "USA");

// Retrieves a single product that matches the combined criteria,
// with a projection to select specific fields.
var productDto = await productRepository.GetAsyncWithProyection(productCombinedCriterias);

```
## Contributing
If you want to contribute to this project, please follow these steps:

Fork the repository.
Create a branch for your changes.
Submit a pull request with a detailed description of the changes.

