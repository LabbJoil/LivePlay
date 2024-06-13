
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Persistence.EntityModels.Base;
using LivePlay.Server.Persistence.EntityModels.ManyMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlay.Server.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntityModel>
{
    public void Configure(EntityTypeBuilder<RoleEntityModel> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity<RolePermissionEntityModel>(
                rp => rp.HasOne<PermissionEntityModel>().WithMany().HasForeignKey(p => p.PermissionId),
                rp => rp.HasOne<RoleEntityModel>().WithMany().HasForeignKey(r => r.RoleId));

        var roles = Enum
            .GetValues<Role>()
            .Select(r => new RoleEntityModel
            {
                Id = (int)r,
                Name = r.ToString()
            });

        builder.HasData(roles);
    }
}
