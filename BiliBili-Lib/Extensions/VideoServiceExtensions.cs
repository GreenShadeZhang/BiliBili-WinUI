using BiliBili_Core.Interfaces;
using BiliBili_Core.Models.BiliBili.Video;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Streaming.Adaptive;
using Windows.Web.Http;

namespace BiliBili_Lib.Extensions
{
    public static class VideoServiceExtensions
    {
        /// <summary>
        /// 根据分片条目创建媒体来源
        /// </summary>
        /// <param name="video">视频</param>
        /// <param name="audio">音频</param>
        /// <returns></returns>
        public async static Task<MediaSource> CreateMediaSourceAsync(this IVideoService videoService, VideoDashItem video, VideoDashItem audio)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Referer = new Uri("https://www.bilibili.com");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
                var mpdStr = $@"<MPD xmlns=""urn:mpeg:DASH:schema:MPD:2011""  profiles=""urn:mpeg:dash:profile:isoff-on-demand:2011"" type=""static"">
                                  <Period  start=""PT0S"">
                                    <AdaptationSet>
                                      <ContentComponent contentType=""video"" id=""1"" />
                                      <Representation bandwidth=""{video.bandwidth}"" codecs=""{video.codecs}"" height=""{video.height}"" id=""{video.id}"" mimeType=""{video.mimeType}"" width=""{video.width}"">
                                        <BaseURL></BaseURL>
                                        <SegmentBase indexRange=""{video.segment_base.index_range}"">
                                          <Initialization range=""{video.segment_base.initialization}"" />
                                        </SegmentBase>
                                      </Representation>
                                    </AdaptationSet>
                                    {{audio}}
                                  </Period>
                                </MPD>
                                ";
                if (audio == null)
                    mpdStr = mpdStr.Replace("{audio}", "");
                else
                    mpdStr = mpdStr.Replace("{audio}", $@"<AdaptationSet>
                                      <ContentComponent contentType=""audio"" id=""2"" />
                                      <Representation bandwidth=""{audio.bandwidth}"" codecs=""{audio.codecs}"" id=""{audio.id}"" mimeType=""{audio.mimeType}"" >
                                        <BaseURL></BaseURL>
                                        <SegmentBase indexRange=""{audio.segment_base.index_range}"">
                                          <Initialization range=""{audio.segment_base.initialization}"" />
                                        </SegmentBase>
                                      </Representation>
                                    </AdaptationSet>");
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(mpdStr)).AsInputStream();
                var soure = await AdaptiveMediaSource.CreateFromStreamAsync(stream, new Uri(video.baseUrl), "application/dash+xml", httpClient);
                var s = soure.Status;
                soure.MediaSource.DownloadRequested += (sender, args) =>
                {
                    if (args.ResourceContentType == "audio/mp4" && audio != null)
                    {
                        args.Result.ResourceUri = new Uri(audio.baseUrl);
                    }
                };
                return MediaSource.CreateFromAdaptiveMediaSource(soure.MediaSource);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
