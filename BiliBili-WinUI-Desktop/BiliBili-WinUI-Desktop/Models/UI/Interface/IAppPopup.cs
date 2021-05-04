using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media.Animation;

namespace BiliBili_WinUI_Desktop.Models.UI.Interface
{
    public interface IAppPopup
    {
        Guid _popupId { get; set; }
        Popup _popup { get; set; }
        void ShowPopup();
        void ShowPopup(XamlRoot xamlRoot);
        void HidePopup();
        double Width { get; set; }
        double Height { get; set; }
    }
}
