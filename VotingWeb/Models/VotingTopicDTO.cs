using Humanizer;

namespace VotingWeb.Models;
public class VotingTopicDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? TitleImage { get; set; }
    public string Answers { get; set; }="";

    public VotingTopic ToVotingTopic()
    {
        return new()
        {
            Id=Id,
            Answers=Answers.Split(",").ToList(),
            Title=Title,
            TitleImage=TitleImage,

        };
    }
    public static VotingTopicDTO? FromVotingTopic(VotingTopic? topic)
    {
        if(topic == null) return null;
        return new()
        {
            Answers=string.Join(",",topic.Answers),
            Id=topic.Id,
            Title=topic.Title,
            TitleImage=topic.TitleImage,
        };
    }
}
//dotnet aspnet-codegenerator blazor CRUD -dbProvider sqlite -dc VotingWeb.Data.ApplicationDbContext -m VotingTopic -outDir Components/Pages