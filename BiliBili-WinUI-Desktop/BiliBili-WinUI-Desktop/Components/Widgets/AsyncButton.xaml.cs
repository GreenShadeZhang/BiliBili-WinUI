using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BiliBili_WinUI_Desktop.Components.Widgets
{
    public sealed partial class AsyncButton : Button
    {
        public AsyncButton()
        {
            this.InitializeComponent();
        }
        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Padding.  This enables animation, styling, binding, etc...
        public static new readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(AsyncButton), new PropertyMetadata(new Thickness(6, 2, 6, 5)));


        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(AsyncButton), new PropertyMetadata("", new PropertyChangedCallback(Icon_Changed)));

        private static void Icon_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var instance = d as AsyncButton;
            //if (e.NewValue != null && e.NewValue is string icon)
            //{
            //    instance.IconBlock.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    instance.IconBlock.Visibility = Visibility.Collapsed;
            //}
        }


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AsyncButton), new PropertyMetadata(""));


        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(AsyncButton), new PropertyMetadata(false, new PropertyChangedCallback(IsLoading_Changed)));

        private static void IsLoading_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as AsyncButton;
            if (e.NewValue != e.OldValue && e.NewValue is bool isload)
            {
                if (isload)
                {
                    instance.IconBlock.Visibility = Visibility.Collapsed;
                    instance.LoadingRing.Visibility = Visibility.Visible;
                }
                else
                {
                    instance.LoadingRing.Visibility = Visibility.Collapsed;
                    if (!string.IsNullOrEmpty(instance.Icon))
                        instance.IconBlock.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
