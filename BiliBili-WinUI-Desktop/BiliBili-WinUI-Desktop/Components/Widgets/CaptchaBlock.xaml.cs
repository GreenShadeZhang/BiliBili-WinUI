using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Imaging;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace BiliBili_WinUI_Desktop.Components.Widgets
{
    public sealed partial class CaptchaBlock : UserControl
    {
        public CaptchaBlock()
        {
            this.InitializeComponent();
        }

        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(CaptchaBlock), new PropertyMetadata(""));


        public async Task RefreshCode()
        {
            CaptchaImage.Visibility = Visibility.Collapsed;
            LoadingRing.IsActive = true;
            BitmapImage image = null;//await App.BiliViewModel._client.Account.GetCaptchaAsync();
            CaptchaImage.Source = image;
            LoadingRing.IsActive = false;
            CaptchaImage.Visibility = Visibility.Visible;
        }

        private async void CaptchaImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Code = "";
            await RefreshCode();
        }
    }
}
