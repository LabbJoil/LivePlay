
using LivePlay.Front.Core.Enums;

namespace LivePlay.Front.Core.Models;

public class QuestItem()
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string TotalDescription { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;

    public QuestStatus Status { get; set; }
    public TypeQuest Type { get; set; }

    public DateTime FinalDate { get; set; } = DateTime.Now;
    public int Price { get; set; }
}
