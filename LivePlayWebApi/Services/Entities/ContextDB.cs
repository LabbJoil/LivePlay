
using LivePlayWebApi.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace LivePlayWebApi.Services.Entities;

public class ContextDB(DbContextOptions<ContextDB> options) : DbContext(options)
{
    public DbSet<UserEntityModel> Users { get; set; }
    public DbSet<QuestEntityModel> Quest { get; set; }
    public DbSet<HotelEntityModel> Hotel { get; set; }
    public DbSet<HotelQuestEntityModel> HotelQuest { get; set; }
    public DbSet<FeedbackEntityModel> Feedback { get; set; }
    public DbSet<NewsEntityModel> News { get; set; }
    public DbSet<DoneQuestEntityModel> DoneQuests { get; set; }
}
