
namespace LivePlay.Front.Core.Models;

public class FeedbackContactInfo
{
    private const string FormatDate = "dd.mm.yyyy";

    public Guid IdFeedback { get; set; }
    public string NameUser { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }

    public string CreationDateText
    {
        get => CreationDate.ToString(FormatDate);
    }
}
