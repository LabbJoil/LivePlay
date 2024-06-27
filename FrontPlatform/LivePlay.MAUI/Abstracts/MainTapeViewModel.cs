
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI.Abstracts;

public abstract partial class MainTapeViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    //public ObservableCollection<object> TapeItems { get; protected set; } = [];

    public abstract Task GoToTapeItem(object item);
}
