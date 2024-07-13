using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Service;

public class TransactionActivityStrategy : IActivityStrategy
{
    public Task HandleActivityAsync(Activity activity)
    {
        // Handle transaction activity
        return Task.CompletedTask;
    }
}