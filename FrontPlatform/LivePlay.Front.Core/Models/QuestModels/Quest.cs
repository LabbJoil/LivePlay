
using LivePlay.Front.Core.Enums;

namespace LivePlay.Front.Core.Models.QuestModels;

public class Quest()
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string DescriptionMini { get; set; } = string.Empty;
    public string DescriptionFull { get; set; } = string.Empty;
    public byte[] Image { get; set; } = [];
    public int Reward { get; set; }

    public TypeQuest Type { get; set; }
    public QuestStatus Status { get; set; }

    public DateTime FinalDate { get; set; } = DateTime.Now;
    //public string FinalDateView { get => FinalDate.ToString("dd.MM.yyyy"); }   TODO: переместить в класс использующий
}
