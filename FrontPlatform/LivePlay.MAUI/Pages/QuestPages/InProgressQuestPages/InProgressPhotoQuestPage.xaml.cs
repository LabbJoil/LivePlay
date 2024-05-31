
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.ViewModels.QuestViewModels;

namespace LivePlayMAUI.Pages;

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