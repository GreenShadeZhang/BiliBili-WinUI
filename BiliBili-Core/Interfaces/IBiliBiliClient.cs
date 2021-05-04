using BiliBili_Core.Models.BiliBili;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiliBili_Core.Interfaces
{
    public interface IBiliBiliClient
    {
        public IAccountService Account { get; }
        public IChannelService Channel { get; }
        public ITopicService Topic { get; }
        public IVideoService Video { get; }
        public IAnimeService Anime { get; }
        /// <summary>
        /// 获取分区索引
        /// </summary>
        /// <returns></returns>
        Task<List<RegionContainer>> GetRegionIndexAsync();
        /// <summary>
        /// 获取首页推荐视频
        /// </summary>
        /// <param name="idx">上一次刷新最后一个视频的标识</param>
        /// <returns></returns>
        Task<List<VideoRecommend>> GetRecommendVideoAsync(int idx = 0);
        /// <summary>
        /// 获取热搜列表
        /// </summary>
        /// <returns></returns>
        Task<List<HotSearch>> GetHotSearchAsync();
        /// <summary>
        /// 综合搜索
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="order">排序方式（default,view,new,danmaku）</param>
        /// <param name="pn">页码</param>
        /// <returns></returns>
        Task<SearchResult> GetComplexSearchResult(string keyword, string order = "default", int pn = 1, string region = "", string duration = "");
        /// <summary>
        /// 搜索指定区块的内容
        /// </summary>
        /// <typeparam name="T">内容类型</typeparam>
        /// <param name="keyword">关键词</param>
        /// <param name="type">区块ID</param>
        /// <param name="order">排序方式</param>
        /// <param name="pn">页码</param>
        /// <param name="param">可选参数</param>
        /// <returns></returns>
        Task<T> SearchTypeItems<T>(string keyword, int type, string order, int pn = 1, Dictionary<string, string> param = null) where T : class;
        Task<List<Owner>> SearchUserAsync(string keyword, bool isFromDynamic = true);
        /// <summary>
        /// 获取搜索建议
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        Task<List<SearchSuggestion>> GetSearchSuggestionAsync(string keyword);
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="oid">源ID</param>
        /// <param name="next">下一页偏移值</param>
        /// <param name="mode">排序方式：3-按热度，2-按时间</param>
        /// <returns>Item1：下一次偏移值，Item2：评论总数，Item3：评论列表，Item4: 是否到了结尾，Item5: 置顶回复</returns>
        Task<Tuple<int, int, List<Reply>, bool, Reply>> GetReplyAsync(string oid, int next, int mode, string type = "1");
        /// <summary>
        /// 获取评论详情
        /// </summary>
        /// <param name="replyId">评论ID</param>
        /// <param name="oid">源ID</param>
        /// <param name="next">偏移值</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<ReplyDetailResponse> GetReplyDetailAsync(string replyId, string oid, int next, string type = "1");
        /// <summary>
        /// 点赞/取消点赞评论
        /// </summary>
        /// <param name="isLike">是否点赞</param>
        /// <param name="oid">源ID</param>
        /// <param name="rpid">评论ID</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<bool> LikeReplyAsync(bool isLike, string oid, string rpid, string type = "1");
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="oid">源ID</param>
        /// <param name="message">信息</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<bool> AddReplyAsync(string oid, string message, string type = "1");
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="oid">源ID</param>
        /// <param name="message">信息</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<Reply> AddReplyAsync(string oid, string message, string parentId, string rootId, string type = "1");
        /// <summary>
        /// 获取Emoji表情列表
        /// </summary>
        /// <returns></returns>
        Task<List<EmojiContainer>> GetTotalEmojiAsync();
        /// <summary>
        /// 获取关注者的未读消息数
        /// </summary>
        /// <returns></returns>
        Task<int> GetFollowerUnreadCountAsync();
        /// <summary>
        /// 测试请求，验证网络是否可访问
        /// </summary>
        /// <returns></returns>
        Task<bool> ValidateRequestAsync();
    }
}
