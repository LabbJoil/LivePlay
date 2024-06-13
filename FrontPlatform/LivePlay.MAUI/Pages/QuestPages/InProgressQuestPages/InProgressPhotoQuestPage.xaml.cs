
using LivePlay.Front.MAUI.Models.Domain;
using LivePlay.Front.MAUI.Models.ViewModels;
using LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages;

//[QueryProperty(nameof(QuestItemProperty), nameof(QuestItemProperty))]
public partial class InProgressPhotoQuestPage : ContentPage
{
    //public QuestItem QuestItemProperty {
    //    set => InProgressPhotoVM.CurrentQuestItem = value;
    //}
    private readonly InProgressPhotoQuestViewModel InProgressPhotoVM;

    public InProgressPhotoQuestPage(InProgressPhotoQuestViewModel inProgressPhotoVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoVM;
        InProgressPhotoVM = inProgressPhotoVM;
    }
}