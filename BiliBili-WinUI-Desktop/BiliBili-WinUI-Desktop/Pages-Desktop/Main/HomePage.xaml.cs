using BiliBili_Core.Models.BiliBili;
using BiliBili_Lib.Tools;
using BiliBili_WinUI_Desktop.Components.Controls;
using BiliBili_WinUI_Desktop.Models.UI;
using BiliBili_WinUI_Desktop.Models.UI.Interface;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using BiliBili_WinUI_Desktop.IoC;
using BiliBili_Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace BiliBili_WinUI_Desktop.Pages.Main
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page, IRefreshPage
    {
        private bool _isInit = false;
        public ObservableCollection<VideoRecommend> RecommendCollection = new ObservableCollection<VideoRecommend>();
        private bool _isRecommendRequesting = false;
        private double _scrollOffset = 0;

        public HomePage()
        {
            this.InitializeComponent();
            //NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private async void IsLoginChanged(object sender, bool e)
        {
            await Refresh();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            PageContainer.Visibility = Visibility.Collapsed;
            if (_isInit || e.NavigationMode == NavigationMode.Back)
            {
                return;
            }
            await Refresh();
            _isInit = true;
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }
        public async Task Refresh()
        {
            if (PageContainer.Visibility == Visibility.Collapsed)
                PageContainer.Visibility = Visibility.Visible;
            await RefreshVideo();
        }

        private async Task LoadMoreRecommendVideo()
        {
            int idx = 0;
            VideoLoadingBar.Visibility = Visibility.Visible;
            if (RecommendCollection.Count > 0)
                idx = RecommendCollection.Last().idx;
            var client = MainContainer.Container.GetService<IBiliBiliClient>();
            var data = await client.GetRecommendVideoAsync(idx);
            data.ForEach(p => RecommendCollection.Add(p));
            CheckRecommendStatus();
            VideoLoadingBar.Visibility = Visibility.Collapsed;
        }

        private void CheckRecommendStatus()
        {
            HolderText.Visibility = RecommendCollection.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private async void ScrollViewerBottomHandle()
        {
            if (_isRecommendRequesting)
                return;
            _isRecommendRequesting = true;
            await LoadMoreRecommendVideo();
            _isRecommendRequesting = false;
        }

        private void RecommendVideoView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as VideoRecommend;
            var container = RecommendVideoView.ContainerFromItem(item);
            //if (item.card_goto == "av")
            //    App.AppViewModel.PlayVideo(item.args.aid, container, StaticString.SIGN_RECOMMEND);
            //else if (item.card_goto == "bangumi")
            //{
            //    var sp = item.uri.Split("#");
            //    if (sp.Length > 1)
            //        App.AppViewModel.PlayBangumi(Convert.ToInt32(sp.Last()), container, true);
            //    else
            //        App.AppViewModel.PlayBangumi(Convert.ToInt32(item.param), container, true);
            //}
        }

        private async Task RefreshVideo()
        {
            RecommendCollection.Clear();
            _scrollOffset = 0;
            int i = 0;
            while (i < 2)
            {
                await LoadMoreRecommendVideo();
                i++;
            }
        }

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            await RefreshVideo();
        }
        private void ScrollViewerChanged()
        {
            //double offset = App.AppViewModel.CurrentPagePanel.PageScrollViewer.VerticalOffset;
            //_scrollOffset = offset;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //PageContainer.Visibility = Visibility.Visible;
            //await Task.Delay(100);
            //if (_scrollOffset > 0)
            //{
            //    App.AppViewModel.CurrentPagePanel.PageScrollViewer.ChangeView(0, _scrollOffset, 1);
            //}
        }

        private void VideoContainer_NeedRemoveVideo(object sender, VideoRecommend e)
        {
            RecommendCollection.Remove(e);
        }

        private void RecommendVideoView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            args.Handled = true;
            RecommendVideoCard card = (RecommendVideoCard)args.ItemContainer.ContentTemplateRoot;
            card.RenderContainer(args);
        }
    }
}
