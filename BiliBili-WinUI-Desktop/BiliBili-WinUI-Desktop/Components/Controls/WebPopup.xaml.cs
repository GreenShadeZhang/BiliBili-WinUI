﻿using BiliBili_WinUI_Desktop.Models.UI;
using BiliBili_WinUI_Desktop.Models.UI.Interface;
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
using Microsoft.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BiliBili_WinUI_Desktop.Components.Controls
{
    public sealed partial class WebPopup : UserControl, IAppPopup
    {
        public Popup _popup { get; set; }
        public Guid _popupId { get; set; }
        private string _url;
        public WebPopup()
        {
            this.InitializeComponent();
            UIHelper.PopupInit(this);
        }
        public void Init(string title,string url)
        {
            _url = url;
            //TitleBlock.Text = title;
            //LoadingRing.IsActive = true;
            //PopWebView.Navigate(new Uri(url));
        }
        public void ShowPopup()
        {
            //UIHelper.PopupShow(this,()=>
            //{
            //    DisplayContainer.Width = Window.Current.Bounds.Width > 900 ? Window.Current.Bounds.Width * 0.7 : 900;
            //    DisplayContainer.Height = Window.Current.Bounds.Height * 0.8;
            //});
            //DisplayContainer.Width = Window.Current.Bounds.Width > 900 ? Window.Current.Bounds.Width * 0.7 : 900;
            //DisplayContainer.Height = Window.Current.Bounds.Height * 0.8;
            //PopupIn.Begin();
        }
        public void HidePopup()
        {
            //PopWebView.NavigateToString("");
            //PopupOut.Begin();
            //PopupOut.Completed -= PopupOut_Completed;
            //PopupOut.Completed += PopupOut_Completed;
        }
        private void PopupOut_Completed(object sender, object e)
        {
            //App.AppViewModel.WindowsSizeChangedNotify.RemoveAll(p => p.Item1 == _popupId);
            _popup.IsOpen = false;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            HidePopup();
        }

        private async void NewWebButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(_url));
        }

        public void ShowPopup(XamlRoot xamlRoot)
        {
            throw new NotImplementedException();
        }

        //private void PopWebView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        //{
        //    LoadingRing.IsActive = false;
        //    if (string.IsNullOrEmpty(TitleBlock.Text))
        //    {
        //        TitleBlock.Text = PopWebView.DocumentTitle;
        //    }
        //}
    }
}
