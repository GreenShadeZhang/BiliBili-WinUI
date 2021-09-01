using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiliBili.Core
{
    public interface IAnimeService
    {
        /// <summary>
        /// 获取动漫区块综合信息
        /// </summary>
        /// <param name="isJp"><c>true</c>代表番剧，<c>false</c>代表国创</param>
        /// <returns></returns>
        Task<List<AnimeModule>> GetAnimeSquareAsync(bool isJp = true);
        /// <summary>
        /// 获取区块刷新信息
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="moduleId">模块ID</param>
        /// <returns></returns>
        Task<List<AnimeModuleItem>> GetAnimeSectionExchange(int type, int moduleId);
        /// <summary>
        /// 获取番剧、电影详情
        /// </summary>
        /// <param name="epid">标识ID</param>
        /// <returns></returns>
        Task<BangumiDetail> GetBangumiDetailAsync(int epid, bool isEp = false);
        /// <summary>
        /// 检查用户是否投币
        /// </summary>
        /// <param name="epid">标识ID</param>
        /// <returns></returns>
        Task<bool> CheckUserCoinAsync(int epid);
        /// <summary>
        /// 追番/追剧
        /// </summary>
        /// <param name="epid">标识ID</param>
        /// <returns></returns>
        Task<bool> FollowBangumiAsync(int epid);
        /// <summary>
        /// 取消追番/追剧
        /// </summary>
        /// <param name="epid">标识ID</param>
        /// <returns></returns>
        Task<bool> UnfollowBangumiAsync(int epid);
        /// <summary>
        /// 获取番剧播放信息
        /// </summary>
        /// <param name="aid">番剧类型标识</param>
        /// <param name="cid">视频分Pid</param>
        /// <param name="qn">分辨率ID</param>
        /// <returns></returns>
        Task<VideoPlayBase> GetBangumiPlayAsync(int type, int cid, int qn = 64);
        /// <summary>
        /// 添加观看视频的历史记录
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <returns></returns>
        Task AddVideoHistoryAsync(int aid, int cid, int epid, int seconds = 0, int sid = 0);
        /// <summary>
        /// 获取动漫索引限制条件
        /// </summary>
        /// <param name="type">分区类型</param>
        /// <returns></returns>
        Task<IndexCondition> GetBangumiIndexConditionAsync(int type);
        /// <summary>
        /// 获取动漫索引筛查结果
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="type">分区类型</param>
        /// <param name="conditions">限制条件</param>
        /// <returns></returns>
        Task<Tuple<bool, List<AnimeIndexResult>>> GetBangumiIndexResultsAsync(int page, int type, List<KeyValueModel> conditions);
        /// <summary>
        /// 获取动漫时间线
        /// </summary>
        /// <param name="type">区块类型，番剧：2，国创：3</param>
        /// <returns></returns>
        Task<List<Timeline>> GetTimelineAsync(int type);
        /// <summary>
        /// 不喜欢某番剧
        /// </summary>
        /// <param name="arg">参数</param>
        /// <returns></returns>
        Task<bool> DislikeRecommendVideoAsync(string bangumiId);
        /// <summary>
        /// 转发动漫/电影/电视剧等
        /// </summary>
        /// <param name="content">转发内容</param>
        /// <param name="videoId">视频ID</param>
        /// <param name="atIds">At的人</param>
        /// <param name="typeName">番剧：4097,影视:4098,电视剧:4099,国创:4100</param>
        /// <returns></returns>
        Task<bool> RepostBangumiAsync(string content, int epId, string typeName, List<RepostLocation> atIds);
    }
}
