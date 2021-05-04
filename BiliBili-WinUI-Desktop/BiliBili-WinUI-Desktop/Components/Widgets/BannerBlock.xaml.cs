using BiliBili_WinUI_Desktop.Models.Enums;
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

namespace BiliBili_WinUI_Desktop.Components.Widgets
{
    public sealed partial class BannerBlock : UserControl
    {
        public BannerBlock()
        {
            this.InitializeComponent();
        }
        public ColorType Color
        {
            get { return (ColorType)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(ColorType), typeof(BannerBlock), new PropertyMetadata(ColorType.PrimaryColor, new PropertyChangedCallback(Color_Changed)));

        private static void Color_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue && e.NewValue is ColorType type)
            {
                var instance = d as BannerBlock;
                instance.Container.Background = UIHelper.GetThemeBrush(type);
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(BannerBlock), new PropertyMetadata(""));

    }
}
