using BiliBili_Core.Interfaces;
using BiliBili_Core.Models.Others;
using BiliBili_Lib.Service;
using BiliBili_WinUI_Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBili_WinUI_Desktop.IoC
{
    public static class MainContainer
    {
        public static IServiceProvider Container { get; private set; }
        public static void RegisterService()
        {
            var services = new ServiceCollection();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IBiliBiliClient, BiliBiliClient>();

            services.AddScoped<IAnimeService, AnimeService>();

            services.AddScoped<IChannelService, ChannelService>();

            services.AddScoped<ITopicService, TopicService>();

            services.AddScoped<IVideoService, VideoService>();

            services.AddScoped<DesktopMainViewModel>();

            services.AddScoped<LoginViewModel>();

            services.AddSingleton(new TokenPackage("","",0));

            Container = services.BuildServiceProvider();
        }
    }
}
