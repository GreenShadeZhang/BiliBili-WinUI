using BiliBili_Core.Models.BiliBili;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiliBili_Core.Interfaces
{
    public interface IChannelService
    {
        /// <summary>
        /// 获取热门频道
        /// </summary>
        /// <returns></returns>
        Task<List<ChannelBase>> GetHotChannelAsync();
        /// <summary>
        /// 获取频道页综合信息
        /// </summary>
        /// <returns></returns>
        Task<ChannelSquare> GetSquareAsync();
        /// <summary>
        /// 获取频道的详细信息
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        Task<ChannelDetail> GetChannelDetailInfoAsync(int channelId);
        /// <summary>
        /// 获取频道下的视频信息
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <param name="sort">排序方式，可选值(hot,view,new)</param>
        /// <param name="offset">偏移值，初次不需要，每次请求会返回下一次请求的偏移值</param>
        /// <returns>Item1:下次偏移值;Item2:榜一视频（如果有）;Item3:视频列表</returns>
        Task<Tuple<string, VideoBase, List<VideoChannel>>> GetChannelVideosAsync(int channelId, string sort = "hot", string offset = "");
        /// <summary>
        /// 取消订阅频道
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <returns></returns>
        Task<bool> UnsubscribeChannelAsync(int channelId);
        /// <summary>
        /// 订阅频道
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <returns></returns>
        Task<bool> SubscribeChannelAsync(int channelId);
        /// <summary>
        /// 获取频道分类索引
        /// </summary>
        /// <returns></returns>
        Task<List<ChannelTab>> GetChannelTabsAsync();
        /// <summary>
        /// 获取我订阅的频道
        /// </summary>
        /// <returns></returns>
        Task<List<ChannelListItem>> GetMySubscibeChannelsAsync(string offset = "");
        /// <summary>
        /// 获取某分类下的频道列表
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <param name="offset">偏移值</param>
        /// <returns></returns>
        Task<List<ChannelListItem>> GetChannelListAsync(int id, string offset = "");
        /// <summary>
        /// 获取频道搜索结果
        /// </summary>
        /// <param name="search">搜索文本</param>
        /// <param name="pn">页码</param>
        /// <param name="ps">每页条目数</param>
        /// <returns></returns>
        Task<List<ChannelListItem>> GetChannelSearchResult(string search, int pn = 1, int ps = 20);
        /// <summary>
        /// 获取标签下的推荐视频
        /// </summary>
        /// <param name="tagId">标签ID</param>
        /// <param name="offset">偏移值，每次+1</param>
        /// <returns></returns>
        Task<List<VideoRecommend>> GetTagRecommendVideo(int tagId, int offset = 1);
        /// <summary>
        /// 获取标签信息
        /// </summary>
        /// <param name="tagId">标签ID</param>
        /// <returns></returns>
        Task<ChannelTag> GetTagDetail(int tagId);
    }
}
