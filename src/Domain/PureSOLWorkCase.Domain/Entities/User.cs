namespace PureSOLWorkCase.Domain;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime JoinDate { get; set; }
    public ICollection<Activity> Activities { get; set; }
}
