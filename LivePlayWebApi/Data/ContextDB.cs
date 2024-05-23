using LivePlayWebApi.Data.Configurations;
using LivePlayWebApi.Models.EntityModels;
using LivePlayWebApi.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LivePlayWebApi.Data;

public class ContextDB(DbContextOptions<ContextDB> options, IOptions<RolePermissionOptions> rolePermissionOptions) : DbContext(options)
{
    public DbSet<UserEntityModel> Users { get; set; }
    public DbSet<RoleEntityModel> Roles { get; set; }
    public DbSet<PermissionEntityModel> Permissions { get; set; }
    public DbSet<QuestEntityModel> Quests { get; set; }
    public DbSet<HotelEntityModel> Hotels { get; set; }
    public DbSet<FeedbackEntityModel> Feedback { get; set; }
    public DbSet<NewsEntityModel> News { get; set; }
    public DbSet<CouponEntityModel> Awards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDB).Assembly);
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(rolePermissionOptions.Value));
    }

    public void FF()
    {
        var f = rolePermissionOptions.Value;
    }
}
