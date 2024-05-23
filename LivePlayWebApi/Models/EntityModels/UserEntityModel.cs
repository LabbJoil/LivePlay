﻿
using LivePlayWebApi.Enums;
using LivePlayWebApi.Models.CoreModels;
using LivePlayWebApi.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

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
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;

    public ICollection<RoleEntityModel> Roles { get; set; } = [];
    public ICollection<CouponEntityModel> Coupons { get; set; } = [];
    public ICollection<QuestEntityModel> Quests { get; set; } = [];
    public ICollection<FeedbackEntityModel> Feedbacks { get; set; } = [];

    public static UserEntityModel Create(string email, string password, string firstName)
        =>
        new()
        {
            Id = Guid.NewGuid(),
            PasswordHash = PasswordHasher.HashPassword(password),
            Email = email,
            FirstName = firstName
        };
}
