namespace PureSOLWorkCase.Domain;

public interface IActivitiyRepository : IRepository<Activity>
{
    Task<IEnumerable<Activity>> GetUserActivitiesAsync(int userId);
}
