using BiliBili_Core.Models.BiliBili;
using BiliBili_Core.Models.Interface;
using CommunityToolkit.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;

namespace BiliBili_WinUI_Desktop.Models.UI.Converter
{
    public class ChannelHeaderMaskConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var data = value as IAlphaBackground;
            if (data != null)
            {
                Windows.UI.Color color = CommunityToolkit.WinUI.Helpers.ColorHelper.ToColor(data.theme_color);
                return new SolidColorBrush(color) { Opacity = data.alpha / 100d };
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
