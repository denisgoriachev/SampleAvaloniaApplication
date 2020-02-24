using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using SampleAvaloniaApplication.Common;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SampleAvaloniaApplication.Client.Converters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(bool) || targetType == typeof(bool?))
                return value.ToString() == parameter.ToString();
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return BindingNotification.UnsetValue;
            var s = Enum.Parse(targetType, parameter.ToString(), true);
            return value.Equals(true) ? s : BindingOperations.DoNothing;
        }
    }
}
