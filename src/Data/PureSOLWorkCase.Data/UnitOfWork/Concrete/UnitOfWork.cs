using Microsoft.EntityFrameworkCore;
using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IRepository<User> Users { get; private set; }
    public IRepository<Activity> Activities { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new Repository<User>(_context);
        Activities = new Repository<Activity>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}