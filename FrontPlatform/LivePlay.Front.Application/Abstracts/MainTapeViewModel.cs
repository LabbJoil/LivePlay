
using LivePlay.Front.Application.DeviceSettings;

namespace LivePlay.Front.Application.Abstracts;

public abstract partial class MainTapeViewModel(AppDesign designSettings) : BaseViewModel(designSettings)
{
    //public ObservableCollection<object> TapeItems { get; protected set; } = [];

    public abstract Task GoToTapeItem(object item);
}
