namespace PureSOLWorkCase.Domain;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Activity> Activities { get; }
    Task<int> CompleteAsync();
}