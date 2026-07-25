namespace VotingWeb.Models;
public class VotingTopic
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? TitleImage { get; set; }
    public List<string> Answers { get; set; }=[];
    public virtual List<UserVote> UserVotes { get; set; }=[];
    public List<int> Statistics
    {
        get {
            if (Answers.Any())
            {
                var answerCount = new List<int>(Answers.Count);
                Answers.ForEach(a=>answerCount.Add(0));
                for (var i=0; i< Answers.Count; i++)
                {
                    answerCount[i] = UserVotes.Count(uv=>uv.Answer==Answers[i]);
                }
                return answerCount;
            }
            return [];
        }
    }
}
//dotnet aspnet-codegenerator blazor CRUD -dbProvider sqlite -dc VotingWeb.Data.ApplicationDbContext -m VotingTopic -outDir Components/Pages