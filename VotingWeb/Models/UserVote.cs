using VotingWeb.Data;

namespace VotingWeb.Models;
public class UserVote
{
    public int Id { get; set; }
    public virtual ApplicationUser User { get; set; }=default!;
    public string Answer { get; set; }="";
    public virtual VotingTopic Topic { get; set; }=default!;
    
}