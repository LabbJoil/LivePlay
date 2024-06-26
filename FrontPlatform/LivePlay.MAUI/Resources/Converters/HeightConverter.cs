﻿
using System.Globalization;

namespace LivePlay.Front.MAUI.Resources.Converters;

public class HeightConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double doubleValue && parameter is string strParameter && double.TryParse(strParameter, CultureInfo.InvariantCulture, out double divide))
            return doubleValue / divide;
        return null;
    }

    public object ConvertBack(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
    {
        throw new NotImplementedException();
    }
}
