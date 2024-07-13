using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PureSOLWorkCase.Domain;
using PureSOLWorkCase.Service;

namespace PureSOLWorkCase.WebAPI.Controller;

[Route("api/v1.0/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ActivitiesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(ActivityDto activitydto)
    {
        var activity = _mapper.Map<Activity>(activitydto);

        IActivityStrategy strategy = activity.ActivityType switch
        {
            "Login" => new LoginActivityStrategy(),
            "PageView" => new PageViewActivityStrategy(),
            "Transaction" => new TransactionActivityStrategy(),
            _ => throw new ArgumentException("Invalid activity type")
        };

        await strategy.HandleActivityAsync(activity);

        await _unitOfWork.Activities.AddAsync(activity);
        await _unitOfWork.CompleteAsync();

        return Ok(activity);
    }

    [HttpGet("users/{activityId}/activity")]
    public async Task<IActionResult> GetByIdActivities(int activityId)
    {
        var activities = await _unitOfWork.Activities.GetByIdAsync(activityId);

        if (activities == null)
        {
            return NotFound();
        }

        return Ok(activities);
    }

    [HttpGet("users/{userId}/userActivities")]
    public async Task<IActionResult> GetUserActivities(int userId)
    {
        var activities = await _unitOfWork.Activities.GetUserActivitiesAsync(userId);
        return Ok(activities);
    }



    [HttpGet]
    public async Task<IActionResult> GetAllActivities()
    {
        var activities = await _unitOfWork.Activities.GetAllAsync();
        return Ok(activities);
    }
}
