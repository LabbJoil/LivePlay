
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Pages;

//[QueryProperty(nameof(QuestItemProperty), nameof(QuestItemProperty))]
public partial class InProgressQuizQuestPage : ContentPage
{
    //public QuestItem QuestItemProperty
    //{
    //    set => BaseQuestVM.CurrentQuestItem = value;
    //}
    private readonly BaseQuestViewModel BaseQuestVM;

    public InProgressQuizQuestPage(BaseQuestViewModel inProgressPhotoVM)
	{
		InitializeComponent();
        BindingContext = inProgressPhotoVM;
        BaseQuestVM = inProgressPhotoVM;
    }
}