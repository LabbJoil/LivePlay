
using System.ComponentModel.DataAnnotations;

namespace LivePlay.Server.Core.Models;

public class QuestionQuest
{
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? FirstAnswer { get; set; }
    public string? SecondAnswer { get; set; }
    public string? ThirdAnswer { get; set; }
    public string? FourthAnswer { get; set; }
    public int RightAnswer { get; set; }
}
