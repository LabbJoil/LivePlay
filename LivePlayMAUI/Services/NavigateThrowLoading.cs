
using LivePlayMAUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Services;

public static class NavigateThrowLoading
{
    public static async Task GoToRootPage(this OverApplicationSettings appSettings, string nextPageRote)
    {
        Dictionary<string, object> navigationParameter = new()
        {
            { "LoadPageRoute", nextPageRote },
        };
        await Shell.Current.GoToAsync($"//{nameof(LoadingPage)}", navigationParameter);
    }
}
