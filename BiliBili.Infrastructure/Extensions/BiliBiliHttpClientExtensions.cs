namespace BiliBili.Infrastructure
{
    public static class BiliBiliHttpClientExtensions
    {
        /// <summary>
        /// 从网页获取html文本
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns></returns>
        public static async Task<string> GetHtmlFromWebAsync(this HttpClient client, string url)
        {
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4115.0 Safari/537.36 Edg/84.0.488.1");

            using (client)
            {
                string html = await client.GetStringAsync(url);
                return html;
            }
        }
    }
}
