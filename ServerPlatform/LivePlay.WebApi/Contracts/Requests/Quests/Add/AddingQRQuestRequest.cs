
namespace LivePlay.Server.WebApi.Contracts.Requests.Quest.Add;

public class AddingQRQuestRequest
{
    public required AddingQuestContract BaseQuest { get; set; }
    public required AddingQRQuestContract QrQuest { get; set; }
}

public class AddingQRQuestContract
{
    public byte[] QRInfo { get; set; } = [];
}
