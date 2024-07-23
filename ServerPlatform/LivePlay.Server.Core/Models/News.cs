
namespace LivePlay.Server.Core.Models;

public class News
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Text { get; set; }
    public byte[]? Image { get; set; }
}
