
using LivePlay.Front.Core.Enums;

namespace LivePlay.Front.Infrastructure.Contracts.Base.QuestContracts;

public class QuestContract
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string DescriptionMini { get; set; }
    public string DescriptionFull { get; set; } = string.Empty;
    public byte[] Image { get; set; } = [];
    public int Reward { get; set; }

    public TypeQuest Type { get; set; }
    public QuestStatus Status { get; set; } = QuestStatus.NotStarted;       //TODO: приходит с сервера

    public DateTime FinalDate { get; set; } = DateTime.Now;
    public string FinalDateView { get => FinalDate.ToString("dd.MM.yyyy"); }
}
