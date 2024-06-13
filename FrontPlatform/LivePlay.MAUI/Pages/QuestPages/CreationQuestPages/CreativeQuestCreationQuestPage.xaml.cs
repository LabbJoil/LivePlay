
using LivePlay.Front.MAUI.Models.Domain;
using LivePlay.Front.MAUI.Pages.AccountPages;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.Services;
using Microsoft.Maui.Controls;
using System.Reflection;
using System.Text.Json;

namespace LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;

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