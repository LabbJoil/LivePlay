using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("UserRole")]
public class UserRoleEntityModel
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public int RoleId { get; set; }
}
