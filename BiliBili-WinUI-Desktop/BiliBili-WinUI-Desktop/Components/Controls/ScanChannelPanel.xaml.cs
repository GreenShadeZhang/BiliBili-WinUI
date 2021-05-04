using BiliBili_Core.Models.BiliBili;
using BiliBili_WinUI_Desktop.Models.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace BiliBili_WinUI_Desktop.Components.Controls
{
    public sealed partial class ScanChannelPanel : UserControl
    {
        //public BiliViewModel channelVM = App.BiliViewModel;
        public ScanChannelPanel()
        {
            this.InitializeComponent();
            //channelVM.MyChannelChanged += ChannelChanged;
        }

        private void ChannelChanged(object sender, bool e)
        {
            //ScanPanel.HolderVisibility = channelVM.MyScanedChannelCollection.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ChannelListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as ChannelView;
            //App.AppViewModel.NavigateToSubPage(typeof(Pages_Share.Sub.Channel.ChannelDetailPage), item.id);
        }
    }
}
