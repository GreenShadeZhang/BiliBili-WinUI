using BiliBili_Core.Enums;
using BiliBili_Lib.Tools;
using BiliBili_WinUI_Desktop.Models.UI;
using BiliBili_WinUI_Desktop.Models.UI.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BiliBili_WinUI_Desktop.Components.Others
{
    public sealed partial class UpdatePopup : UserControl,IAppPopup
    {
        public Popup _popup { get; set; }
        public Guid _popupId { get; set; }
        string version = string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
        public UpdatePopup()
        {
            this.InitializeComponent();
            UIHelper.PopupInit(this);
        }
        public void ShowPopup()
        {
            VersionBlock.Text = version;
            UIHelper.PopupShow(this);
            PopupIn.Begin();
        }
        public void HidePopup()
        {
            PopupOut.Begin();
            PopupOut.Completed -= PopupOut_Completed;
            PopupOut.Completed += PopupOut_Completed;
        }
        public UpdatePopup(string content) : this()
        {
            MarkdownBlock.Text = content;
        }

        private async void MarkdownBlock_LinkClicked(object sender, CommunityToolkit.WinUI.UI.Controls.LinkClickedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(e.Link));
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            AppTool.WriteLocalSetting(Settings.LocalVersion, version);
            HidePopup();
        }
        private void PopupOut_Completed(object sender, object e)
        {
            //App.AppViewModel.WindowsSizeChangedNotify.RemoveAll(p => p.Item1 == _popupId);
            _popup.IsOpen = false;
        }

        public void ShowPopup(XamlRoot xamlRoot)
        {
            throw new NotImplementedException();
        }
    }
}
