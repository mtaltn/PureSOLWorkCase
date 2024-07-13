using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Service;

public class ActivityContext
{
    private readonly IActivityStrategy _strategy;

    public ActivityContext(IActivityStrategy strategy)
    {
        _strategy = strategy;
    }

    public Task ExecuteStrategyAsync(Activity activity)
    {
        return _strategy.HandleActivityAsync(activity);
    }
}