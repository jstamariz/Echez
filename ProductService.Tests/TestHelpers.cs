using Microsoft.EntityFrameworkCore;
using ProductService.Persistence;

namespace ProductService.Tests;

  public static class TestDbContextFactory
    {
        public static ProductContext CreateInMemoryDbContext()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            Console.WriteLine(dbName);

            var context = new ProductContext(options);
            context.Database.EnsureCreated();

            return context;
        }
    }