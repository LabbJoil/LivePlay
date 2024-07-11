
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.Core.Models;

public class Quest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? DescriptionMini { get; set; }
    public string DescriptionFull { get; set; } = string.Empty;
    public byte[] Image { get; set; } = [];
    public TypeQuest Type { get; set; }
    public int Reward { get; set; }
    public required DateTime FinalDate { get; set; }
}
