using LivePlayMAUI.Abstracts;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Models.ViewModels.ReviewViewModels;

public partial class ReviewViewModel : BaseViewModel
{
    public ReviewViewModel(DeviceDesignSettings designSettings) : base(designSettings)
    {
        // запрос к серверу
    }
}
