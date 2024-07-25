
namespace LivePlay.Front.Core.Models;

public class News()
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public byte[] Image { get; set; } = [];
}
