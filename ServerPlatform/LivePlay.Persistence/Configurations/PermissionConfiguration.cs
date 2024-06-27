
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlay.Server.Persistence.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntityModel>
{
    public void Configure(EntityTypeBuilder<PermissionEntityModel> builder)
    {
        builder.HasKey(p => p.Id);

        var permissions = Enum
            .GetValues<Permission>()
            .Select(p => new PermissionEntityModel
            {
                Id = (int)p,
                Name = p.ToString()
            });

        builder.HasData(permissions);
    }
}
