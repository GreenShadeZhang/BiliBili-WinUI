using BiliBili_Core.Interfaces;
using BiliBili_Core.Models.Others;
using BiliBili_Lib.Tools;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BiliBili_Lib.Extensions
{
    public static class AccountServiceExtensions
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public async static Task<BitmapImage> GetCaptchaAsync(this IAccountService accountService)
        {
            var stream = await BiliTool.GetStreamFromWebAsync($"{Api.PASSPORT_CAPTCHA}?ts=${AppTool.GetNowSeconds()}");
            if (stream != null)
            {
                var bitmap = new BitmapImage();
                await bitmap.SetSourceAsync(stream.AsRandomAccessStream());
                return bitmap;
            }
            return new BitmapImage(new Uri("ms-appx:///Assets/captcha_refresh.png"));
        }
    }
}
