
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.ViewModels;

namespace LivePlay.Front.MAUI.Pages.UserPages.CouponPages.Views;

public partial class MyCouponsPage : ContentPage
{
	private readonly MyCouponsViewModel ProfileVM;
    public MyCouponsPage(MyCouponsViewModel profileViewModel)
	{
		InitializeComponent();
        BindingContext = profileViewModel;
        ProfileVM = profileViewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        //    ProfileVM.ChangeColorBars(MainGrid.BackgroundColor, StatusBarColor.BarWhite, null);
        //    DeviceDesignSettings.OpacityAnimation(this, ShadowRectangle, 20, 500, 0);
        //await QuestTapePageVM.GetQuestItems();    //��������� ����� ������
    }
}