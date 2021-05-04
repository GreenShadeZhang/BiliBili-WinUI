using BiliBili_Core.Models.BiliBili;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BiliBili_WinUI_Desktop.Components.Widgets
{
    public sealed partial class EmojiPanel : UserControl
    {
        private ObservableCollection<EmojiReplyContainer> EmojiIndexCollection = new ObservableCollection<EmojiReplyContainer>();
        public EmojiPanel()
        {
            this.InitializeComponent();
        }
        public bool IsInit = false;
        public event EventHandler<Emote> EmojiSelected;
        public async Task Init()
        {
            IsInit = false;
            EmojiIndexCollection.Clear();
            //if (App.BiliViewModel.IsLogin)
            //{
            //    var emojis = await App.BiliViewModel._client.Account.GetUserEmojiAsync();
            //    if (emojis != null)
            //    {
            //        emojis.ForEach(p => EmojiIndexCollection.Add(p));
            //    }
            //    EmojiDetailView.ItemsSource = emojis.First().emote;
            //}
            IsInit = true;
        }

        private void EmojiDetailView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Emote;
            EmojiSelected?.Invoke(this, item);
        }

        private void IndexView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as EmojiReplyContainer;
            EmojiDetailView.ItemsSource = item.emote;
        }
    }
}
