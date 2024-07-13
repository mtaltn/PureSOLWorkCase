using PureSOLWorkCase.Domain;

namespace PureSOLWorkCase.Service;

public interface IActivityStrategy
{
    Task HandleActivityAsync(Activity activity);
}