using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiliBili.Core
{
    public interface ITopicService
    {
        /// <summary>
        /// 获取话题动态
        /// </summary>
        /// <param name="topicId">话题ID</param>
        /// <param name="topicName">话题名</param>
        /// <param name="offset">偏移值，初次不需要，每次请求会返回下一次请求的偏移值</param>
        /// <returns>Item1:下次偏移值;Item2:视频列表</returns>
        Task<Tuple<string, List<Topic>>> GetTopicAsync(int topicId, string topicName, string offset = "");
        /// <summary>
        /// 获取新动态
        /// </summary>
        /// <returns>动态响应</returns>
        Task<NewDynamicResponse> GetNewDynamicAsync(string lastSeemId = "0");
        /// <summary>
        /// 获取历史动态
        /// </summary>
        /// <param name="offset">偏移值，初次不需要，每次请求会返回下一次请求的偏移值</param>
        /// <returns>Item1:下次偏移值;Item2:动态列表</returns>
        Task<Tuple<string, List<Topic>>> GetHistoryDynamicAsync(string offset);
        /// <summary>
        /// 设置动态点赞状态
        /// </summary>
        /// <param name="isLike">是否点赞</param>
        /// <param name="dynamicId">动态ID</param>
        /// <param name="rid">动态里的参数</param>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        Task<bool> SetDynamicLikeStatus(bool isLike, string dynamicId, string rid, string uid);
        /// <summary>
        /// 获取用户空间历史动态
        /// </summary>
        /// <param name="uid">要查看的用户ID</param>
        /// <param name="page">页码</param>
        /// <param name="offset_id">偏移值，初次不需要，每次请求会返回下一次请求的偏移值</param>
        /// <returns>Item1:下次偏移值;Item2:动态列表</returns>
        Task<Tuple<string, List<Topic>>> GetUserSpaceDynamicAsync(int uid, int page = 1, string offset_id = "0");
        /// <summary>
        /// 转发动态
        /// </summary>
        /// <param name="content">附加内容</param>
        /// <param name="dynamicId">被转发动态ID</param>
        /// <param name="rid">被转发动态评论ID</param>
        /// <param name="type">被转发动态类型</param>
        /// <param name="atIds">at的人</param>
        /// <returns></returns>
        Task<bool> RepostDynamicAsync(string content, string dynamicId, string rid, int type, List<RepostLocation> atIds);
    }
}
