using System;
using System.Data;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace DataTableGrid.Converters;

public class DataRowViewConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Console.WriteLine($"Converter called with value: {value}, parameter: {parameter}");
        if (value is DataRowView rowView && parameter is string columnName)
        {
            return rowView[columnName]?.ToString();
        }
        return AvaloniaProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value != null && parameter is string columnName)
        {
            return value;
        }
        return AvaloniaProperty.UnsetValue;
    }
}



