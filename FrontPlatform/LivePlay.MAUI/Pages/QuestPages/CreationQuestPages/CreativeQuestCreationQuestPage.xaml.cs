using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Pages.AccountPages;
using LivePlayMAUI.Pages.AdminPages;
using LivePlayMAUI.Services;
using Microsoft.Maui.Controls;
using System.Reflection;
using System.Text.Json;

namespace LivePlayMAUI.Pages.QuestPages.CreationQuestPages;

public partial class CreativeQuestCreationQuestPage : ContentPage
{
    private DeviceStorage DeviceStorage { get; }

    public CreativeQuestCreationQuestPage()
	{
        InitializeComponent();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        
    }
}