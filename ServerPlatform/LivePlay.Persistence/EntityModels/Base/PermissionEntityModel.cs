﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("Permission")]
public class PermissionEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<RoleEntityModel> Roles { get; set; } = [];
}
