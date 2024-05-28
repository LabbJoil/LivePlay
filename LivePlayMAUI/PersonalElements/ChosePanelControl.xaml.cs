using LivePlayMAUI.Models.Domain;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace LivePlayMAUI.PersonalElements;

public partial class ChoicePanelControl : ContentPage
{
    public static readonly BindableProperty PanelItemsProperty = BindableProperty.Create(
       propertyName: nameof(PanelItems),
       returnType: typeof(ObservableCollection<ChoicePanelItem>),
       declaringType: typeof(ChoicePanelControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public ObservableCollection<ChoicePanelItem>? PanelItems
    {
        get => (ObservableCollection<ChoicePanelItem>)GetValue(PanelItemsProperty);
        set { SetValue(PanelItemsProperty, value); }
    }

    public ChoicePanelControl()
	{
		InitializeComponent();
	}

}