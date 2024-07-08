
using LivePlay.Front.MAUI.Models;

namespace LivePlay.Front.MAUI.PersonalElements;

public partial class ChoicePanelControl : ContentView
{
    public static readonly BindableProperty PanelItemsProperty = BindableProperty.Create(
        propertyName: nameof(PanelItems),
        returnType: typeof(IReadOnlyList<ChoicePanelItem>),
        declaringType: typeof(ChoicePanelControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);

    public IReadOnlyList<ChoicePanelItem> PanelItems
    {
        get => (IReadOnlyList<ChoicePanelItem>)GetValue(PanelItemsProperty);
        set => SetValue(PanelItemsProperty, value);
    }

    public ChoicePanelControl()
    {
        InitializeComponent();
    }
}