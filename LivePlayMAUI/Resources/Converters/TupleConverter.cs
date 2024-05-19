using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePlayMAUI.Models.Domain;

namespace LivePlayMAUI.Resources.Converters;

public class TupleConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is object tapeItem && parameter is ContentPage page)
            return new Tuple<object, ContentPage>(tapeItem, page);
        return null;
    }

    public object ConvertBack(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
    {
        throw new NotImplementedException();
    }
}
