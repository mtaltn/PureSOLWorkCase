namespace PureSOLWorkCase.Domain;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByEMailAsync(string eMail);
}
