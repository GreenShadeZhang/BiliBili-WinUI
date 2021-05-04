using BiliBili_Core.Models.BiliBili;
using BiliBili_WinUI_Desktop.Components.Widgets;
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
    public sealed partial class SubscribeChannelPanel : UserControl
    {
        //public BiliViewModel channelVM = App.BiliViewModel;
        public SubscribeChannelPanel()
        {
            this.InitializeComponent();
            //channelVM.MyChannelChanged += ChannelChanged;
        }
        private void ChannelChanged(object sender, bool e)
        {
            //ChannelListView.Visibility = channelVM.MySubscribeChannelCollection.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            //HolderText.Visibility = channelVM.MySubscribeChannelCollection.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
            //MoreSign.Visibility = e ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SearchChannelButton_Click(object sender, RoutedEventArgs e)
        {
            //if (App.BiliViewModel.IsLogin)
            //    App.AppViewModel.NavigateToSubPage(typeof(Pages_Share.Sub.Channel.ChannelListPage));
            //else
            //    new TipPopup("请先登录").ShowError();
        }

        private void ChannelListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var item = e.ClickedItem as ChannelSlim;
            //if(item.@goto=="channel")
            //    App.AppViewModel.NavigateToSubPage(typeof(Pages_Share.Sub.Channel.ChannelDetailPage), item.id);
            //else if(item.@goto=="tag")
            //    App.AppViewModel.NavigateToSubPage(typeof(Pages_Share.Sub.Channel.TagDetailPage), item.id);
        }
    }
}
