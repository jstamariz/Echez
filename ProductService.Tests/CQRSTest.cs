using System;
using ProductService.Persistence;

namespace ProductService.Tests;

public abstract class CQRSTest : IDisposable
{
    protected readonly ProductContext _productContext;
    public CQRSTest()
    {
        _productContext = TestDbContextFactory.CreateInMemoryDbContext();
    }

    public void Dispose()
    {
        _productContext.ChangeTracker.Entries().ToList().ForEach(x => x.State = Microsoft.EntityFrameworkCore.EntityState.Detached);
        _productContext.Database.EnsureDeleted();

        System.Console.WriteLine("Hello world");
    }
}
