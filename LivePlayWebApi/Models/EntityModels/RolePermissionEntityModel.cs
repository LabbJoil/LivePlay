using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("RolePermission")]
public class RolePermissionEntityModel
{
    [Required]
    public int RoleId { get; set; }
    [Required]
    public int PermissionId {  get; set; }
}
