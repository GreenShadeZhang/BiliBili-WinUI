using BiliBili_Core.Models.BiliBili;
using BiliBili_WinUI_Desktop.Models.UI.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBili_WinUI_Desktop.ViewModels
{
    public class LoginViewModel : NotifyPropertyBase
    {
        public event EventHandler<Me> MyInfoChanged;

        public bool IsLogin { get; set; }

        public void ChangeUserInfo(Me me)
        {
            IsLogin = true;
            MyInfoChanged?.Invoke(this, me);
        }
    }
}
