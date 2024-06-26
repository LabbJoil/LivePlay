﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlay.Server.Persistence.EntityModels.Base;

[Table("User")]
public class UserEntityModel
{
    [Key, Required]
    public Guid Id { get; set; }
    [Required]
    public required string PasswordHash { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required int Points { get; set; }
    public string? LastName { get; set; }
    [Required]
    public required DateTime JoinDate { get; set; } = DateTime.UtcNow;

    public ICollection<CouponEntityModel> Coupons { get; set; } = [];
    public ICollection<RoleEntityModel> Roles { get; set; } = [];
    public ICollection<QuestEntityModel> Quests { get; set; } = [];
    public ICollection<CreativeQuestEntityModel> CreativeQuests { get; set; } = [];
    public ICollection<FeedbackEntityModel> Feedbacks { get; set; } = [];
}
