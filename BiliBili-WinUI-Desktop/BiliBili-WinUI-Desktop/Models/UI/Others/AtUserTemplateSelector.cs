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
    public class AtUserTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate UserTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object data)
        {
            if (data is Owner user && user.mid>0)
                return UserTemplate;
            else
                return DefaultTemplate;
        }
    }
}
