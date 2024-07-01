
using LivePlay.Server.Core.Options;
using LivePlay.Server.Persistence.Configurations;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LivePlay.Server.Persistence;

public class LivePlayDbContext(DbContextOptions<LivePlayDbContext> options, IOptions<RolePermissionOptions> rolePermissionOptions) : DbContext(options)
{
    public DbSet<UserEntityModel> Users { get; set; }
    public DbSet<RoleEntityModel> Roles { get; set; }
    public DbSet<PermissionEntityModel> Permissions { get; set; }
    public DbSet<QuestEntityModel> Quests { get; set; }
    public DbSet<QuestionQuestEntityModel> QuestionQuests { get; set; }
    public DbSet<QRQuestEntityModel> QRQuests { get; set; }
    public DbSet<CreativeQuestEntityModel> CreativeQuests { get; set; }
    public DbSet<HotelEntityModel> Hotels { get; set; }
    public DbSet<FeedbackEntityModel> Feedback { get; set; }
    public DbSet<NewsEntityModel> News { get; set; }
    public DbSet<CouponEntityModel> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivePlayDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(rolePermissionOptions.Value));
    }
}
