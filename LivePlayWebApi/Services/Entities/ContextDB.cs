
using LivePlayWebApi.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace LivePlayWebApi.Services.Entities;

public class ContextDB(DbContextOptions<ContextDB> options) : DbContext(options)
{
    public DbSet<UserEntityModel> Users { get; set; }
    public DbSet<QuestEntityModel> Quests { get; set; }
    public DbSet<HotelEntityModel> Hotels { get; set; }
    public DbSet<HotelQuestEntityModel> HotelsQuests { get; set; }
    public DbSet<FeedbackEntityModel> Feedback { get; set; }
    public DbSet<NewsEntityModel> News { get; set; }
    public DbSet<QuestUserEntityModel> QuestsUsers { get; set; }
    public DbSet<AwardEntityModel> Awards { get; set; }
    public DbSet<AwardUserEntityModel> AwardsUsers { get; set; }
}
