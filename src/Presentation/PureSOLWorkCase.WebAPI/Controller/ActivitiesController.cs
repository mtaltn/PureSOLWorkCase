using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PureSOLWorkCase.Domain;
using PureSOLWorkCase.Service;

namespace PureSOLWorkCase.WebAPI.Controller;

[Route("api/v1.0/[controller]")]
[ApiController]
[Authorize]
public class ActivitiesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IActivitiyRepository _activitiyRepository;

    public ActivitiesController(IUnitOfWork unitOfWork, IMapper mapper, IActivitiyRepository activitiyRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _activitiyRepository = activitiyRepository;
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

        await _activitiyRepository.AddAsync(activity);
        await _unitOfWork.CompleteAsync();

        return Ok(activity);
    }

    [HttpGet("{activityId}/activity")]
    public async Task<IActionResult> GetByIdActivities(int activityId)
    {
        var activities = await _activitiyRepository.GetByIdAsync(activityId);

        if (activities is null)
        {
            return NotFound();
        }

        return Ok(activities);
    }

    [HttpGet("{userId}/userActivities")]
    public async Task<IActionResult> GetUserActivities(int userId)
    {
        var activities = await _activitiyRepository.GetUserActivitiesAsync(userId);
        return Ok(activities);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActivities()
    {
        var activities = await _activitiyRepository.GetAllAsync();
        return Ok(activities);
    }
}
