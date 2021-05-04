using BiliBili_Lib.Services;
using BiliBili_WinUI_Desktop.Components.Layout;
using BiliBili_WinUI_Desktop.Helpers;
using BiliBili_WinUI_Desktop.Models.UI;
using BiliBili_WinUI_Desktop.Models.UI.Others;
using BiliBili_WinUI_Desktop.Pages.Main;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BiliBili_WinUI_Desktop.ViewModels
{
    public class DesktopMainViewModel : NotifyPropertyBase
    {
        private bool _isBackEnabled;

        private ObservableCollection<AppMenuItem> _menuItemCollection;
        public DesktopMainViewModel()
        {

        }

        private ICommand _loadedCommand;
        public bool IsBackEnabled
        {
            get { return _isBackEnabled; }
            set { Set(ref _isBackEnabled, value); }
        }
        public ObservableCollection<AppMenuItem> MenuItemCollection
        {
            get
            {
                return _menuItemCollection;
            }
            set
            {
                Set(ref _menuItemCollection, value);
            }
        }

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand<object>(OnLoaded));

        private void OnLoaded(object obj)
        {
            var pagePanel = obj as PagePanel;

            var rootFrame = (Frame)pagePanel.FindName("PageFrame");

            if (rootFrame == null)
            {
                throw new Exception("Root frame not found");
            }

            NavigationService.Frame = rootFrame;
            NavigationService.NavigationFailed += Frame_NavigationFailed;
            NavigationService.Navigated += Frame_Navigated;

            var list = AppMenuItem.GetSideMenuItems(false);

            MenuItemCollection = new ObservableCollection<AppMenuItem>(list);

            rootFrame.Navigate(typeof(HomePage));
        }
        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
