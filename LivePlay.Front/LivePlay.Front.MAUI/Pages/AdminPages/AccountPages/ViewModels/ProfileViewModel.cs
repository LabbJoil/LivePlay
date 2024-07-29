
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.Pages.EnterPages.Views;

namespace LivePlay.Front.MAUI.Pages.AdminPages.AccountPages.ViewModels;

public partial class ProfileViewModel(IServiceScopeFactory serviceScopeFactory) : BaseViewModel(serviceScopeFactory)
{
    [RelayCommand]
    public async Task BackEnterPage()
    {
        DeleteStackPages();
        await Shell.Current.GoToAsync($"//{nameof(EnterPage)}");
    }
}
