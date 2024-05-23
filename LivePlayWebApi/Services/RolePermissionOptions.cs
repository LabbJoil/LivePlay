
using LivePlayWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace LivePlayWebApi.Services;

public class RolePermissionOptions
{
    public RolePermissions[] RolePermissions { get; set; } = [];
}

public class RolePermissions
{
    [Required]
    public string Role { get; set; } = string.Empty;

    [Required]
    public string[] Permissions { get; set; } = [];
}
