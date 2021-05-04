﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace BiliBili_WinUI_Desktop.Models.UI.Converter
{
    public class CollectionCountVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value is IEnumerable<object> collection)
            {
                if (parameter != null)
                    return collection.Count() == 0 ? Visibility.Visible : Visibility.Collapsed;
                else
                    return collection.Count() == 0 ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
