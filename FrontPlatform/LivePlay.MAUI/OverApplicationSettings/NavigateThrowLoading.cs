
using LivePlay.Front.MAUI.Pages;

namespace LivePlay.Front.MAUI.OverApplicationSettings;

public class NavigateThrowLoading
{
    public async Task GoToRootPage(string nextPageRote)
    {
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "LoadPageRoute", nextPageRote },
        };
        await Shell.Current.GoToAsync($"//{nameof(LoadingPage)}", navigationParameter);
    }
}
