using LivePlayWebApi.Models.EntityModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LivePlayWebApi.Enums;

namespace LivePlayWebApi.Data.Configurations;

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
