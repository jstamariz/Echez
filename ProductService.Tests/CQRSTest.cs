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
        _productContext.ChangeTracker.Clear();
        _productContext.Database.EnsureDeleted();
    }
}
