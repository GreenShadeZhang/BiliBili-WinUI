using BiliBili_Core.Interfaces;
using BiliBili_Lib.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Extensions.DependencyInjection;
using BiliBili_Lib.Extensions;
using BiliBili_WinUI_Desktop.Pages.Main;
using BiliBili_WinUI_Desktop.ViewModels;
using System.ComponentModel;
using BiliBili_WinUI_Desktop.IoC;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BiliBili_WinUI_Desktop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DesktopMainPage : Page
    {
        public DesktopMainViewModel ViewModel { get; } = MainContainer.Container.GetService<DesktopMainViewModel>();
        public DesktopMainPage()
        {
            this.InitializeComponent();           
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            if (width < 1000)
            {
                if (AppSplitView.DisplayMode != SplitViewDisplayMode.CompactOverlay)
                    AppSplitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            else
            {
                if (AppSplitView.DisplayMode != SplitViewDisplayMode.CompactInline)
                    AppSplitView.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
        }
    }
}
