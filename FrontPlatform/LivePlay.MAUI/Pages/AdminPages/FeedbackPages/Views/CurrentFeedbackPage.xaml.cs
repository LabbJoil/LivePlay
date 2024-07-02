
using CommunityToolkit.Maui.Views;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;

public partial class CurrentFeedbackPage : Popup
{
    private FeedbackContactInfo FeedbackContactInfoModel {  get; set; }

    public CurrentFeedbackPage(FeedbackContactInfo feedbackContactInfoModel)
	{
		InitializeComponent();
	}

    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }

    private void Popup_Opened(object sender, CommunityToolkit.Maui.Core.PopupOpenedEventArgs e)
    {
        Size = new Size(Window.Width, Window.Height);
    }
}