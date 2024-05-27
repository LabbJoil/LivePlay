using LivePlayWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace LivePlayWebApi.Services.ConfigurationOptions;

public class RolePermissionOptions
{
    public RolePermissions[] RolePermissions { get; set; } = [];
}

public class RolePermissions
{
    public string Role { get; set; } = string.Empty;
    public string[] Permissions { get; set; } = [];
}
