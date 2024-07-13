using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Service;

public class LoginActivityStrategy : IActivityStrategy
{
    public Task HandleActivityAsync(Activity activity)
    {
        // Handle login activity
        return Task.CompletedTask;
    }
}