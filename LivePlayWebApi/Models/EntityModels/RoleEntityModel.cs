using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("Role")]
public class RoleEntityModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public ICollection<UserEntityModel> Users { get; set; } = [];

    [Required]
    public ICollection<PermissionEntityModel> Permissions { get; set; } = [];
}
