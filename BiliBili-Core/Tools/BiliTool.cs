using BiliBili_Core.Models.BiliBili;
using BiliBili_Core.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BiliBili_Core.Tools
{
    public class BiliTool
    {
        public static ApiKeyInfo AndroidKey = new ApiKeyInfo("4409e2ce8ffd12b8", "59b43e04ad6965f34319062b478f83dd");
        public static ApiKeyInfo AndroidVideoKey = new ApiKeyInfo("iVGUTjsxvpLeuDCf", "aHRmhWMLkdeMuILqORnYZocwMBpMEOdt");
        public static ApiKeyInfo WebVideoKey = new ApiKeyInfo("84956560bc028eb7", "94aba54af9065f71de72f5508f1cd42e");
        public static ApiKeyInfo VideoKey = new ApiKeyInfo("", "1c15888dc316e05a15fdd0a02ed6584f");
        public static ApiKeyInfo IosKey = new ApiKeyInfo("4ebafd7c4951b366", "8cb98205e9b2ad3669aad0fce12a4c13");
        public const string BuildNumber = "5520400";
        public static string _accessToken = "";
        public static string sid = "";
        public static string mid = "";

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="apiKeyInfo">取用的Api密钥</param>
        /// <returns></returns>
        public static string GetSign(string url, ApiKeyInfo apiKeyInfo = null)
        {
            if (apiKeyInfo == null)
            {
                apiKeyInfo = AndroidKey;
            }
            string result;
            if (url.StartsWith("http"))
                url.Substring(url.IndexOf("?", 4) + 1);
            List<string> list = url.Split('&').ToList();
            list.Sort();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str1 in list)
            {
                stringBuilder.Append((stringBuilder.Length > 0 ? "&" : string.Empty));
                stringBuilder.Append(str1);
            }
            stringBuilder.Append(apiKeyInfo.Secret);
            result = MD5Tool.GetMd5String(stringBuilder.ToString()).ToLower();
            return result;
        }
        /// <summary>
        /// 请求地址拼接
        /// </summary>
        /// <param name="_baseUrl">请求url</param>
        /// <param name="parameters">查询参数</param>
        /// <param name="hasAccessKey">是否包含令牌</param>
        /// <returns></returns>
        public static string UrlContact(string _baseUrl, Dictionary<string, string> parameters = null, bool hasAccessKey = false, bool useWeb = false,
            bool useiPhone = false)
        {
            if (parameters == null)
                parameters = new Dictionary<string, string>();

            parameters.Add("build", BuildNumber);
            if (useiPhone)
            {
                parameters.Add("appkey", IosKey.Appkey);
                parameters.Add("mobi_app", "iphone");
                parameters.Add("platform", "ios");
                parameters.Add("ts", AppTool.GetNowSeconds().ToString());
            }
            else if (!useWeb)
            {
                parameters.Add("appkey", AndroidKey.Appkey);
                parameters.Add("mobi_app", "android");
                parameters.Add("platform", "android");
                parameters.Add("ts", AppTool.GetNowSeconds().ToString());
            }
            else
            {
                parameters.Add("appkey", WebVideoKey.Appkey);
                parameters.Add("ts", AppTool.GetNowMilliSeconds().ToString());
            }
            if (hasAccessKey && !string.IsNullOrEmpty(_accessToken))
                parameters.Add("access_key", _accessToken);
            string param = string.Empty;
            foreach (var item in parameters)
            {
                param += $"{item.Key}={item.Value}&";
            }
            param = param.TrimEnd('&');
            string sign = useWeb ? GetSign(param, WebVideoKey) : GetSign(param);
            param += $"&sign={sign}";
            return !string.IsNullOrEmpty(_baseUrl) ? _baseUrl + $"?{param}" : param;
        }

        /// <summary>
        /// 分析URL指向的结果
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static UriResult GetResultFromUri(string url)
        {
            var uri = new Uri(url);
            string path = uri.AbsolutePath;
            if (path.Contains("/ep", StringComparison.OrdinalIgnoreCase))
            {
                var regex_ep = new Regex(@"ep(\d+)");
                if (regex_ep.IsMatch(url))
                {
                    string epId = regex_ep.Match(path).Value.Replace("ep", "");
                    return new UriResult(Enums.UriType.Bangumi, epId);
                }
            }
            else if (path.Contains("/cv", StringComparison.OrdinalIgnoreCase))
            {
                var regex_cv = new Regex(@"cv(\d+)");
                if (regex_cv.IsMatch(url))
                {
                    string cId = regex_cv.Match(path).Value.Replace("cv", "");
                    return new UriResult(Enums.UriType.Document, cId);
                }
            }
            else if (path.Contains("video/", StringComparison.OrdinalIgnoreCase))
            {
                var regex_av = new Regex(@"av(\d+)");
                var regex_bv = new Regex(@"BV(.*)");

                if (regex_av.IsMatch(path))
                {
                    string aid = regex_av.Match(path).Value.Replace("av", "");
                    return new UriResult(Enums.UriType.VideoA, aid);
                }
                else if (regex_bv.IsMatch(path))
                {
                    string bid = regex_bv.Match(path).Value;
                    return new UriResult(Enums.UriType.VideoB, bid);
                }
            }
            return new UriResult(Enums.UriType.Web, url);
        }
    }
}
