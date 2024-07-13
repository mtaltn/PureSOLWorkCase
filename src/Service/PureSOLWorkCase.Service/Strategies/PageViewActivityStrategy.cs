using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Service;

public class PageViewActivityStrategy : IActivityStrategy
{
    public Task HandleActivityAsync(Activity activity)
    {
        // Handle page view activity
        return Task.CompletedTask;
    }
}