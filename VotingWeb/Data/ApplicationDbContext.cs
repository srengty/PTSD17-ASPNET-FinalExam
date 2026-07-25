using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VotingWeb.Models;

namespace VotingWeb.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<UserVote> UserVotes=>Set<UserVote>();
    public DbSet<VotingTopic> VotingTopics=>Set<VotingTopic>();
}
