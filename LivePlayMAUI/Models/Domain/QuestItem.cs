using LivePlayMAUI.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.Domain;

public class QuestItem(string title, string description, string image, QuestStatus questStatus, TypeQuest questType)
{
    public string Title { get; } = title;
    public string? Description { get; set; } = description;
    public QuestStatus Status { get; set; } = questStatus;
    public TypeQuest Type { get; set; } = questType;
    public string Image { get; set; } = image;

    private string? TotalDescription;
    private DateTime? FinalDate;
    private int Reward;
}
