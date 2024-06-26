namespace LivePlay.Server.WebApi.Contracts.Base.Quest;

public class QRQuestContract
{
    public int Id { get; set; }
    public byte[] QRInfo { get; set; } = [];
}