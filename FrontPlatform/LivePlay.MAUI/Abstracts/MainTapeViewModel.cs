
using LivePlayMAUI.Services;

namespace LivePlayMAUI.Abstracts;

public abstract partial class MainTapeViewModel(DeviceDesignSettings designSettings) : BaseViewModel(designSettings)
{
    //public ObservableCollection<object> TapeItems { get; protected set; } = [];

    public abstract Task GoToTapeItem(object item);
}
