
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.WebApi.Contracts.Requests.QuestRequests.Add;

public class AddingQuestContract
{
    public required string Title { get; set; }
    public required string DescriptionMini { get; set; }
    public string DescriptionFull { get; set; } = string.Empty;
    public byte[] Image { get; set; } = [];
    public TypeQuest Type { get; set; }
    public int Reward { get; set; }
}
