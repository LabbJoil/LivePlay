
using LivePlay.Persistence.EntityModels.Base;
using LivePlay.Persistence.EntityModels.ManyMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlay.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntityModel>
{
    public void Configure(EntityTypeBuilder<UserEntityModel> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRoleEntityModel>(
                ur => ur.HasOne<RoleEntityModel>().WithMany().HasForeignKey(r => r.RoleId),
                ur => ur.HasOne<UserEntityModel>().WithMany().HasForeignKey(u => u.UserId));

        builder.HasMany(u => u.Coupons)
            .WithMany(c => c.Users)
            .UsingEntity<UserCouponEntityModel>(
                uc => uc.HasOne<CouponEntityModel>().WithMany().HasForeignKey(c => c.CouponId),
                uc => uc.HasOne<UserEntityModel>().WithMany().HasForeignKey(u => u.UserId));

        builder.HasMany(u => u.Quests)
            .WithMany(c => c.Users)
            .UsingEntity<UserQuestEntityModel>(
                uq => uq.HasOne<QuestEntityModel>().WithMany().HasForeignKey(q => q.QuestId),
                uq => uq.HasOne<UserEntityModel>().WithMany().HasForeignKey(u => u.UserId));

        builder.HasMany(u => u.Feedbacks)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId);
    }
}
