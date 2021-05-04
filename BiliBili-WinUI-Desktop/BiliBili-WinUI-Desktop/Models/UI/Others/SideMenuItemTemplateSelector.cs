using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BiliBili_WinUI_Desktop.Models.UI.Others
{
    public class SideMenuItemTemplateSelector: DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate LineTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object data)
        {
            var item = data as AppMenuItem;
            return item.Type == Enums.AppMenuItemType.Line ? LineTemplate : DefaultTemplate;
        }
    }
}
