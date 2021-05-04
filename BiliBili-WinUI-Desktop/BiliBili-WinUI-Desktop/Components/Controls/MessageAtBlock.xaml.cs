﻿using BiliBili_Core.Models.BiliBili.Feedback;
using BiliBili_Lib.Tools;
using BiliBili_WinUI_Desktop.Models.UI.Others;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BiliBili_WinUI_Desktop.Components.Controls
{
    public sealed partial class MessageAtBlock : UserControl
    {
        public MessageAtBlock()
        {
            this.InitializeComponent();
        }
        public FeedAtDetail Data
        {
            get { return (FeedAtDetail)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(FeedAtDetail), typeof(MessageAtBlock), new PropertyMetadata(null, new PropertyChangedCallback(Data_Changed)));

        private static void Data_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is FeedAtDetail data)
            {
                var instance = d as MessageAtBlock;
                instance.UserAvatar.ProfilePicture = new BitmapImage(new Uri(data.user.avatar + "@40w.jpg")) { DecodePixelWidth = 40 };
                instance.ShowUserBlock.Text = data.user.nickname;
                instance.TimeBlock.Text = AppTool.GetReadDateString(data.at_time);
                instance.TypeBlock.Text = $"在{data.item.business}中@了我";
                instance.DetailBlock.Text = data.item.source_content;
                instance.TitleBlock.Text = string.IsNullOrEmpty(data.item.title) ? "数据蜜汁消失了" : data.item.title;
            }
        }

        private async void Container_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (e.OriginalSource is Grid && Data != null)
            {
                var uri = Data.item.native_uri;
                if (Data.item.type == "reply")
                {
                    //App.AppViewModel.ShowReplyDetailPopup(Data.item.source_id.ToString(), Data.item.subject_id.ToString(), Data.item.business_id.ToString());
                }
                else
                {
                    await Launcher.LaunchUriAsync(new Uri(Data.item.uri));
                }
            }
        }

        private void Title_Tapped(object sender, TappedRoutedEventArgs e)
        {
            e.Handled = true;
            //App.AppViewModel.HandleUri(Data.item.uri, TitleBlock.Text);
        }

        private void UserAvatar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            e.Handled = true;
            //App.AppViewModel.NavigateToSubPage(typeof(Pages_Share.Sub.Account.DetailPage), Data.user.mid);
        }
    }
}
