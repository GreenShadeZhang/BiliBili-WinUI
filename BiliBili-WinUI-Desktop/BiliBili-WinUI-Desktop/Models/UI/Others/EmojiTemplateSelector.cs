﻿using BiliBili_Core.Models.BiliBili;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BiliBili_WinUI_Desktop.Models.UI.Others
{
    public class EmojiTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Default { get; set; }
        public DataTemplate Text { get; set; }
        protected override DataTemplate SelectTemplateCore(object data)
        {
            var emo = data as Emote;
            if (string.IsNullOrEmpty(emo.url) || !emo.url.StartsWith("http"))
                return Text;
            return Default;
        }
    }
}
