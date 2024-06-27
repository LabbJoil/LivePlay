using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("Role")]
public class RoleEntityModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<UserEntityModel> Users { get; set; } = [];
    public ICollection<PermissionEntityModel> Permissions { get; set; } = [];
}
