
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LivePlayMAUI.Pages;

namespace LivePlayMAUI.Models.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _userName;

    [ObservableProperty]
    private string? _password;

    [RelayCommand]
    private async Task Tap()
    {
        await Shell.Current.GoToAsync(nameof(QuestTapePage));
    }
}
