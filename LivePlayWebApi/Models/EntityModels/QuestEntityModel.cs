﻿
using LivePlayWebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("Quest")]
public class QuestEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? DescriptionMini {  get; set; }
    [Required]
    public string? DescriptionFull { get; set; }
    [Required]
    public byte[]? Image { get; set; }
    [Required]
    public TypeQuest Type { get; set; }
    [Required]
    public int Reward { get; set; }
    [Required]
    public DateTime? CreatedDate { get; set; }
    [Required]
    public DateTime? FinalDate { get; set; }
}
