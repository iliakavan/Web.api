using Webapi.Persistance.Repositories;

namespace Webapi.Persistance;

public interface IUnitOfWork
{
    IProductRepository Products { get; }  
    IOrderRepository Orders { get; }  
    IWareHouseRepository WareHouses { get; }

    Task SaveChanges(); 
}

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IProductRepository Products 
    {
        get { return Products ?? new ProductRepository(_context); }
    }

    public IOrderRepository Orders 
    {
        get { return Orders ?? new OrderRepository(_context); }
    }

    public IWareHouseRepository WareHouses => throw new NotImplementedException();

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}