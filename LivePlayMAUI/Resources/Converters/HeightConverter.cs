using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePlayMAUI.Models.Domain;

namespace LivePlayMAUI.Resources.Converters;

public class HeightConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double doubleValue)
            return doubleValue / 1.8;
        return null;
    }

    public object ConvertBack(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
    {
        throw new NotImplementedException();
    }
}
