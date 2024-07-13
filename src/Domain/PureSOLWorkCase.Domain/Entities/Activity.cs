namespace PureSOLWorkCase.Domain;

public class Activity
{
    public int ActivityId { get; set; }
    public int UserId { get; set; }
    public string ActivityType { get; set; }
    public DateTime ActivityDate { get; set; }
    public string Description { get; set; }
}