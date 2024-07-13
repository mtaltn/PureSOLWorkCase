using Microsoft.EntityFrameworkCore;
using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Data;

public class ActivityRepository : Repository<Activity>, IActivitiyRepository
{
    private readonly AppDbContext _context;

    public ActivityRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Activity>> GetUserActivitiesAsync(int userId)
    {
        return await _context.Activities
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }
}
