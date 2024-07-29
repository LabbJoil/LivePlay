
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Abstracts;

public abstract partial class BaseTapeViewModel(IServiceScopeFactory serviceScopeFactory) : BaseViewModel(serviceScopeFactory)
{
    //public ObservableCollection<object> TapeItems { get; protected set; } = [];

    public abstract Task GoToTapeItem(object item);
}
