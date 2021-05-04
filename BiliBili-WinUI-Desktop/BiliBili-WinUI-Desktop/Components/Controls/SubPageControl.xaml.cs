using BiliBili_WinUI_Desktop.Models.UI.Interface;
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
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace BiliBili_WinUI_Desktop.Components.Controls
{
    public sealed partial class SubPageControl : UserControl
    {
        private List<Tuple<Type, object>> SubFrameHistoryList = new List<Tuple<Type, object>>();
        public SubPageControl()
        {
            this.InitializeComponent();
            //App.AppViewModel.CurrentSubPageControl = this;
        }
        public event EventHandler CloseButtonClick;
        public string SubPageTitle
        {
            get { return (string)GetValue(SubPageTitleProperty); }
            set { SetValue(SubPageTitleProperty, value); }
        }
        public static readonly DependencyProperty SubPageTitleProperty =
            DependencyProperty.Register("SubPageTitle", typeof(string), typeof(SubPageControl), new PropertyMetadata(""));

        public Visibility FrameVisibility
        {
            get { return (Visibility)GetValue(FrameVisibilityProperty); }
            set { SetValue(FrameVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FrameVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrameVisibilityProperty =
            DependencyProperty.Register("FrameVisibility", typeof(Visibility), typeof(SubPageControl), new PropertyMetadata(Visibility.Visible));



        public void NavigateToSubPage(Type page, object parameter = null, bool isBack = false)
        {
            //var last = SubFrameHistoryList.LastOrDefault();
            //bool isRepeat = false;
            //if (last != null && last.Item1 == page && last.Item2 == parameter)
            //    isRepeat = true;
            //NavigationTransitionInfo transitionInfo = null;
            //if (!App.AppViewModel.IsEnableAnimation)
            //    transitionInfo = new SuppressNavigationTransitionInfo();
            //else
            //    transitionInfo = new DrillInNavigationTransitionInfo();
            //SubPageFrame.Navigate(page, parameter, transitionInfo);
            //if (!isBack)
            //{
            //    if (!isRepeat)
            //    {
            //        if (page.Equals(typeof(Pages_Share.Sub.ReplyPage)))
            //            SubFrameHistoryList.RemoveAll(p => p.Item1 == page);
            //        SubFrameHistoryList.Add(new Tuple<Type, object>(page, parameter));
            //    }
            //    if (SubFrameHistoryList.Count > 1)
            //    {
            //        SubBackButton.Visibility = Visibility.Visible;
            //    }
            //}
        }
        public void SubPageBack()
        {
            if (SubFrameHistoryList.Count <= 1)
                return;
            int c = SubFrameHistoryList.Count - 2;
            var last = SubFrameHistoryList[c];
            var previousType = last.Item1;
            SubFrameHistoryList.RemoveAt(SubFrameHistoryList.Count - 1);
            if (SubFrameHistoryList.Count <= 1)
            {
                //SubBackButton.Visibility = Visibility.Collapsed;
            }
            NavigateToSubPage(previousType, last.Item2, true);
        }
        private void SubBackButton_Click(object sender, RoutedEventArgs e)
        {
            SubPageBack();
        }
        private async void SubRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //var sub = SubPageFrame.Content as IRefreshPage;
            //if (sub != null)
            //{
            //    SubRefreshButton.IsEnabled = false;
            //    await sub.Refresh();
            //    SubRefreshButton.IsEnabled = true;
            //}
        }

        public void JudgeBack()
        {
            if (SubFrameHistoryList.Count > 1)
            {
                SubPageBack();
            }
        }
        public bool CheckSubReplyPage()
        {
            bool needClose = false;
            //if (SubFrameHistoryList.Count > 0 && SubFrameHistoryList.Last().Item1 == typeof(Pages_Share.Sub.ReplyPage))
            //{
            //    if (SubFrameHistoryList.Count > 1)
            //        SubPageBack();
            //    else
            //    {
            //        SubPageFrame.Content = null;
            //        SubFrameHistoryList.Clear();
            //        needClose = true;
            //    }
            //}
            return needClose;
        }

        private void ClosePaneButton_Click(object sender, RoutedEventArgs e)
        {
            CloseButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
