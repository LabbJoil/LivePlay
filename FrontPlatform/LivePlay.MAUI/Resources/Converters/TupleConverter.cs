﻿
using System.Globalization;

namespace LivePlayMAUI.Resources.Converters;

public class TupleConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is object tapeItem && parameter is ContentView page)
            return new Tuple<object, ContentView>(tapeItem, page);
        return null;
    }

    public object ConvertBack(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
    {
        throw new NotImplementedException();
    }
}
