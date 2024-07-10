
namespace LivePlay.Server.Core.Models;

public class Feedback
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Text { get; set; }
    public byte[]? Image { get; set; }
    public byte Rate { get; set; }
}
