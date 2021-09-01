using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiliBili.Core
{
    public interface IAccountService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="captcha">验证码</param>
        /// <returns></returns>
        Task<LoginCallback> LoginAsync(string userName, string password, string captcha = "");
        /// <summary>
        /// 登陆成功后设置令牌状态
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="mid">用户ID</param>
        /// <returns></returns>
        Task<bool> SetLoginStatusAsync(string accessToken, string refreshToken = "", int expiry = 0);
        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <returns></returns>
        Task<bool> RefreshTokenAsync();
        /// <summary>
        /// 检查令牌状态
        /// </summary>
        /// <returns></returns>
        Task<bool> CheckTokenStatusAsync();
        /// <summary>
        /// Cookie转化处理
        /// </summary>
        /// <returns></returns>
        Task SSO();
        /// <summary>
        /// 获取我的个人信息
        /// </summary>
        /// <returns></returns>
        Task<Me> GetMeAsync();
        /// <summary>
        /// 关注用户
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        Task<bool> FollowUser(int uid);
        /// <summary>
        /// 取消关注用户
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        Task<bool> UnfollowUser(int uid);
        /// <summary>
        /// 获取观看的历史记录
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        Task<List<VideoDetail>> GetVideoHistoryAsync(int page = 1);
        /// <summary>
        /// 清空观看历史记录
        /// </summary>
        /// <returns></returns>
        Task<bool> ClearHistoryAsync();
        /// <summary>
        /// 移出稍后再看
        /// </summary>
        /// <param name="aids">视频ID组</param>
        /// <returns></returns>
        Task<bool> DeleteHistoryAsync(params int[] aids);
        /// <summary>
        /// 获取我收藏的播单(最多20个)
        /// </summary>
        /// <returns>Item1: 我创建的；Item2: 我收藏的</returns>
        Task<Tuple<List<FavoriteItem>, List<FavoriteItem>>> GetMyMainlyFavoritesAsync();
        /// <summary>
        /// 获取收藏夹
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="pn">页码</param>
        /// <returns></returns>
        Task<List<FavoriteItem>> GetFavoritesAsync(int uid, int pn = 1);
        /// <summary>
        /// 获取收集列表
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="pn">页码</param>
        /// <returns></returns>
        Task<List<FavoriteItem>> GetCollectListAsync(int uid, int pn = 1);
        /// <summary>
        /// 获取我正在追的动漫
        /// </summary>
        /// <returns></returns>
        Task<Tuple<int, List<FavoriteAnime>>> GetMyFavoriteAnimeAsync(int page = 1);

        /// <summary>
        /// 获取我正在追的影视剧
        /// </summary>
        /// <returns></returns>
        Task<Tuple<int, List<FavoriteAnime>>> GetMyFavoriteCinemaAsync(int page = 1);
        /// <summary>
        /// 获取收藏夹的视频索引
        /// </summary>
        /// <param name="id">收藏夹Id</param>
        /// <returns></returns>
        Task<List<FavoriteId>> GetFavoriteIdsAsync(int id);
        /// <summary>
        /// 根据传入的id列表获取视频信息
        /// </summary>
        /// <param name="ids">Id列表</param>
        /// <returns></returns>
        Task<List<FavoriteVideo>> GetFavoriteVideosAsync(IEnumerable<FavoriteId> ids);

        /// <summary>
        /// 获取稍后观看列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        Task<List<VideoDetail>> GetViewLaterAsync(int page = 1);
        /// <summary>
        /// 清空稍后观看列表
        /// </summary>
        /// <returns></returns>
        Task<bool> ClearViewLaterAsync();
        /// <summary>
        /// 添加稍后再看
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <returns></returns>
        Task<bool> AddViewLaterAsync(int aid);
        /// <summary>
        /// 移出稍后再看
        /// </summary>
        /// <param name="aids">视频ID组</param>
        /// <returns></returns>
        Task<bool> DeleteViewLaterAsync(params int[] aids);
        /// <summary>
        /// 获取用户空间信息（经过删减）
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        Task<UserResponse> GetUserSpaceAsync(int uid);
        /// <summary>
        /// 获取用户的投稿
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        Task<ArchiveResponse> GetUserArchiveAsync(int uid, int page);
        /// <summary>
        /// 获取表情包
        /// </summary>
        /// <returns></returns>
        Task<List<EmojiReplyContainer>> GetUserEmojiAsync();
        /// <summary>
        /// 获取账户的未读消息
        /// </summary>
        /// <returns></returns>
        Task<MyMessage> GetMyUnreadMessageAsync();
        /// <summary>
        /// 获取我的粉丝
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="reversion">刷新标识</param>
        /// <returns></returns>
        Task<FanResponse> GetMyFansAsync(int page, long reversion = 0);
        /// <summary>
        /// 获取我的关注的分组
        /// </summary>
        /// <returns></returns>
        Task<List<FollowTag>> GetMyFollowTagsAsync();
        /// <summary>
        /// 获取我关注的用户（按分组）
        /// </summary>
        /// <param name="tagId">分组ID</param>
        /// <param name="pn">页码</param>
        /// <returns></returns>
        Task<List<RelationUser>> GetMyFollowUserAsync(int tagId, int pn);
        /// <summary>
        /// 删除收藏夹内视频
        /// </summary>
        /// <param name="aid">视频ID</param>
        /// <param name="videoType">视频类型</param>
        /// <param name="listId">收藏夹ID</param>
        /// <returns></returns>
        Task<bool> RemoveFavoriteVideoAsync(int aid, int videoType, int listId);
        /// <summary>
        /// 获取回复我的列表
        /// </summary>
        /// <param name="replyTime">偏移值（上次请求的底部时间戳）</param>
        /// <returns></returns>
        Task<FeedReplyResponse> GetReplyMeListAsync(int replyTime = 0);
        /// <summary>
        /// 获取At我的列表
        /// </summary>
        /// <param name="id">上次请求的Id</param>
        /// <param name="atTime">上次请求的底部时间戳</param>
        /// <returns></returns>
        Task<FeedAtResponse> GetAtMeListAsync(long id, int atTime = 0);
        /// <summary>
        /// 获取点赞的列表
        /// </summary>
        /// <param name="id">上次请求的Id</param>
        /// <param name="likeTime">上次请求的底部时间戳</param>
        /// <returns></returns>
        Task<FeedLikeResponse> GetLikeMeListAsync(long id, int likeTime = 0);
    }
}
