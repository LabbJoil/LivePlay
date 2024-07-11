
using LivePlay.Front.MAUI.Pages.EnterPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.EnterPages.Views;

public partial class BlackPage : ContentPage
{
	private readonly BlackViewModel _blackViewModel;

	public BlackPage(BlackViewModel blackViewModel)
	{
		_blackViewModel = blackViewModel;
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		await _blackViewModel.MakeDecision();
    }
}