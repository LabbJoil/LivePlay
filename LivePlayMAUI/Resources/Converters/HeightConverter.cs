
using System.Globalization;

namespace LivePlayMAUI.Resources.Converters;

public class HeightConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double doubleValue && parameter is string strParameter && double.TryParse(strParameter, out double divide))
            return doubleValue / divide;
        return null;
    }

    public object ConvertBack(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
    {
        throw new NotImplementedException();
    }
}
