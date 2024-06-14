
using LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;

namespace LivePlay.Front.MAUI.Pages;

//[QueryProperty(nameof(QuestItemProperty), nameof(QuestItemProperty))]
public partial class InProgressPhotoQuestPage : ContentPage
{
    //public QuestItem QuestItemProperty {
    //    set => InProgressPhotoVM.CurrentQuestItem = value;
    //}
    private readonly InProgressPhotoQuestPageViewModel InProgressPhotoVM;

    public InProgressPhotoQuestPage(InProgressPhotoQuestPageViewModel inProgressPhotoVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoVM;
        InProgressPhotoVM = inProgressPhotoVM;
    }
}