using Microsoft.EntityFrameworkCore;
using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Data;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetUserByEMailAsync(string eMail)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == eMail);
    }
}
