using LivePlay.Front.Core.Models.QuestModels;
using System.Windows.Input;

namespace LivePlay.Front.MAUI.PersonalElements;

public partial class TapeQuestItemControl : ContentView
{
	public TapeQuestItemControl()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TapeItemProperty = BindableProperty.Create(
       propertyName: nameof(TapeItem),
       returnType: typeof(Quest),
       declaringType: typeof(TapeQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public Quest TapeItem
    {
        get => (Quest)GetValue(TapeItemProperty);
        set { SetValue(TapeItemProperty, value);}
    }

    public static readonly BindableProperty CommandTapProperty = BindableProperty.Create(
       propertyName: nameof(CommandTap),
       returnType: typeof(ICommand),
       declaringType: typeof(TapeQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public ICommand CommandTap
    {
        get => (ICommand)GetValue(CommandTapProperty);
        set { SetValue(CommandTapProperty, value); }
    }
}