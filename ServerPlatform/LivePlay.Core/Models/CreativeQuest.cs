
using System.ComponentModel.DataAnnotations;

namespace LivePlay.Server.Core.Models;

public class CreativeQuest
{
    public int Id { get; set; }
    public byte[] PictureInfo { get; set; } = [];
}
