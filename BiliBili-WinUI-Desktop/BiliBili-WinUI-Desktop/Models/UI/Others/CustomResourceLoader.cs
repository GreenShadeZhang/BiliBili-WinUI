using BiliBili_Core.Enums;
using BiliBili_Lib.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Resources;

namespace BiliBili_WinUI_Desktop.Models.UI.Others
{
    public class CustomResourceLoader: CustomXamlResourceLoader
    {
        protected override object GetResource(string resourceId, string objectType, string propertyName, string propertyType)
        {
            if (resourceId == "Basic")
            {
                return new FontFamily(AppTool.GetLocalSetting(Settings.FontFamily,"微软雅黑"));
            }
            else if (resourceId.Contains("Font"))
            {
                double NormalSize = Convert.ToDouble(AppTool.GetLocalSetting(Settings.BasicFontSize, "14"));
                if (resourceId == "BasicFontSize")
                    return NormalSize;
                else if (resourceId == "SmallFontSize")
                    return NormalSize * 0.85;
                else if (resourceId == "MiniFontSize")
                    return NormalSize * 0.7;
                else if (resourceId == "BodyFontSize")
                    return NormalSize * 1.1;
                else if (resourceId == "SubFontSize")
                    return NormalSize * 1.5;
                else if (resourceId == "HeaderFontSize")
                    return NormalSize * 2;
                else if (resourceId == "LargeFontSize")
                    return NormalSize * 2.5;
            }
            return null;
        }
    }
}
