using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiliBili.Core
{
    public interface IVideoService
    {
        /// <summary>
        /// 加载默认的子分区视频内容
        /// </summary>
        /// <param name="rid">分区ID</param>
        /// <param name="ctime">偏移值</param>
        /// <returns></returns>
        Task<Tuple<int, List<RegionVideo>>> GetSubRegionDefaultAsync(int rid, int ctime = 0);
        /// <summary>
        /// 加载排序后的分区子内容
        /// </summary>
        /// <param name="rid">分区ID</param>
        /// <param name="order">排序方式</param>
        /// <param name="pn">页码</param>
        /// <returns></returns>
        Task<List<RegionVideo>> GetSubRegionSortVideoAsync(int rid, string order, int pn = 1);
        /// <summary>
        /// 获取分区排行榜数据
        /// </summary>
        /// <param name="rid">分区ID</param>
        /// <returns></returns>
        Task<List<WebVideo>> GetRegionRankAsync(int rid);
        /// <summary>
        /// 加载默认的分区内容
        /// </summary>
        /// <param name="rid">分区ID</param>
        /// <param name="ctime">偏移值</param>
        /// <returns></returns>
        Task<Tuple<List<RegionBanner>, int, List<RegionVideo>>> GetRegionSquareAsync(int rid, int ctime = 0);
        /// <summary>
        /// 获取视频分P
        /// </summary>
        /// <param name="aid">视频avid</param>
        /// <returns></returns>
        Task<List<VideoPart>> GetVideoPartsAsync(int aid);
        /// <summary>
        /// 获取视频详细信息（包括分P）
        /// </summary>
        /// <param name="aid">视频avid</param>
        /// <returns></returns>
        Task<VideoDetail> GetVideoDetailAsync(int aid, string fromSign = "", string bvId = "");
        /// <summary>
        /// 获取视频简易信息
        /// </summary>
        /// <param name="aid">视频avid</param>
        /// <returns></returns>
        Task<VideoSlim> GetVideoSlimAsync(int aid);
        /// <summary>
        /// 获取视频相关
        /// </summary>
        /// <param name="aid">视频avid</param>
        /// <returns></returns>
        Task<List<VideoDetail>> GetVideoRelatedAsync(int aid);
        /// <summary>
        /// 获取视频播放信息
        /// </summary>
        /// <param name="aid">视频avid</param>
        /// <param name="cid">视频分Pid</param>
        /// <param name="qn">分辨率ID</param>
        /// <returns></returns>
        Task<VideoPlayBase> GetVideoPlayAsync(int aid, int cid, int qn = 64);
        /// <summary>
        /// 检查视频状态（是否投币，点赞，收藏等）
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="type">检查类型</param>
        /// <returns></returns>
        Task<bool> CheckVideoStatusAsync(int aid, string type = "like");

        /// <summary>
        /// 视频点赞/取消点赞
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="isLike">是否点赞</param>
        /// <returns></returns>
        Task<bool> LikeVideoAsync(int aid, bool isLike);
        /// <summary>
        /// 视频投币
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="coin">投币数量</param>
        /// <param name="isLike">是否同时点赞</param>
        /// <returns></returns>
        Task<bool> GiveCoinToVideoAsync(int aid, int coin, bool isLike);
        /// <summary>
        /// 获取收藏夹
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        Task<List<FavoriteItem>> GetFavoritesAsync(int aid, int uid);
        /// <summary>
        /// 操作收藏夹
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="addIds">添加的收藏夹ID列表</param>
        /// <param name="delIds">移出的收藏夹ID列表</param>
        /// <returns></returns>
        Task<bool> AddVideoToFavoriteAsync(int aid, List<string> addIds, List<string> delIds);
        /// <summary>
        /// 一键三连
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <returns></returns>
        Task<bool> TripleVideoAsync(int aid);
        /// <summary>
        /// 添加观看视频的历史记录
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <returns></returns>
        Task AddVideoHistoryAsync(int aid, int cid, int seconds = 0);
        /// <summary>
        /// 获取互动视频的节点信息
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="graphVersion">标识值</param>
        /// <param name="edgeId">选项ID</param>
        /// <returns></returns>
        Task<InteractionVideo> GetInteractionVideoAsync(int aid, int graphVersion, int edgeId = 0);
        /// <summary>
        /// 发送弹幕
        /// </summary>
        /// <param name="message">弹幕信息</param>
        /// <param name="aid">视频ID</param>
        /// <param name="cid">弹幕块ID</param>
        /// <param name="progress">进度</param>
        /// <param name="color">颜色（已处理）</param>
        /// <param name="fontSize">文本大小</param>
        /// <param name="mode">模式</param>
        /// <returns></returns>
        Task<bool> SendDanmakuAsync(string message, int aid, int cid, double progress, string color, string fontSize, string mode);
        /// <summary>
        /// 不喜欢某视频
        /// </summary>
        /// <param name="arg">参数</param>
        /// <param name="reason_id">原因ID</param>
        /// <param name="go">类型</param>
        /// <param name="isFeedback">标识是反馈还是不感兴趣</param>
        /// <returns></returns>
        Task<bool> DislikeRecommendVideoAsync(Args arg, int reason_id, string go, bool isFeedback = false);
        /// <summary>
        /// 获取字幕文件索引
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="cid">分PID</param>
        /// <returns></returns>
        Task<List<SubtitleIndexItem>> GetVideoSubtitleIndexAsync(int aid, int cid);
        /// <summary>
        /// 获取字幕数据
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns></returns>
        Task<VideoSubtitle> GetSubtitlesAsync(string url);
        /// <summary>
        /// 转发视频
        /// </summary>
        /// <param name="content">转发内容</param>
        /// <param name="videoId">视频ID</param>
        /// <param name="atIds">At的人</param>
        /// <returns></returns>
        Task<bool> RepostVideoAsync(string content, int videoId, List<RepostLocation> atIds);
    }
}
