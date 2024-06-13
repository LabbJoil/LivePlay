
using CommunityToolkit.Maui.Views;
using LivePlay.Front.MAUI.Models.Domain;
using LivePlay.Front.MAUI.Models.ViewModels;

namespace LivePlay.Front.MAUI.Pages.AdminPages;

public partial class CurrentFeedbackPage : Popup
{
    private FeedbackContactInfoModel FeedbackContactInfoModel {  get; set; }

    public CurrentFeedbackPage(FeedbackContactInfoModel feedbackContactInfoModel)
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void Popup_Opened(object sender, CommunityToolkit.Maui.Core.PopupOpenedEventArgs e)
    {
        Size = new Size(Window.Width, Window.Height);
    }
}