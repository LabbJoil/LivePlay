
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Options;
using LivePlay.Server.Persistence.EntityModels.ManyMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivePlay.Server.Persistence.Configurations;

public class RolePermissionConfiguration(RolePermissionOptions rolePermissionOptions) : IEntityTypeConfiguration<RolePermissionEntityModel>
{
    private readonly RolePermissionOptions RPOptions = rolePermissionOptions;

    public void Configure(EntityTypeBuilder<RolePermissionEntityModel> builder)
    {
        builder.HasKey(p => new { p.RoleId, p.PermissionId });

        var t = RPOptions.RolePermissions.GroupBy(x => x);
        if (RPOptions.RolePermissions.GroupBy(x => x).Any(g => g.Count() > 1))
            throw new Exception("Несколько одинаковых элементов в <RolePermissionOptions>");

        var rolePermission = RPOptions.RolePermissions
            .SelectMany(rp => rp.Permissions
            .Select(p => new RolePermissionEntityModel
            {
                RoleId = (int)Enum.Parse<Role>(rp.Role),
                PermissionId = (int)Enum.Parse<Permission>(p)
            })).ToArray();

        builder.HasData(rolePermission);
    }
}
