
namespace LivePlay.Front.Core.Models.FeedbackModels;

public class FeedbackContactInfo
{
    private const string FormatDate = "dd.mm.yyyy";

    public int Id { get; set; }
    public string NameUser { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }

    public string CreationDateText
    {
        get => CreationDate.ToString(FormatDate);
    }
}
