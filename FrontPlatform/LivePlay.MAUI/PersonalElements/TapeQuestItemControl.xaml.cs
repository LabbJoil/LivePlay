
using CommunityToolkit.Mvvm.Input;
using LivePlay.Front.MAUI.Models.Domain;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace LivePlay.Front.MAUI.PersonalElements;

public partial class TapeQuestItemControl : ContentView
{
	public TapeQuestItemControl()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TapeItemProperty = BindableProperty.Create(
       propertyName: nameof(TapeItem),
       returnType: typeof(QuestionQuestModel),
       declaringType: typeof(TapeQuestItemControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public object TapeItem
    {
        get => (QuestionQuestModel)GetValue(TapeItemProperty);
        set { SetValue(TapeItemProperty, value as QuestionQuestModel);}
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