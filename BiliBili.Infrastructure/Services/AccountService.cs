using BiliBili.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBili.Infrastructure.Services
{
    internal class AccountService : IAccountService
    {
        public HttpClient Client { get; }
        public AccountService(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public Task<bool> AddViewLaterAsync(int aid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckTokenStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearHistoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearViewLaterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHistoryAsync(params int[] aids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteViewLaterAsync(params int[] aids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FollowUser(int uid)
        {
            throw new NotImplementedException();
        }

        public Task<FeedAtResponse> GetAtMeListAsync(long id, int atTime = 0)
        {
            throw new NotImplementedException();
        }

        public Task<List<FavoriteItem>> GetCollectListAsync(int uid, int pn = 1)
        {
            throw new NotImplementedException();
        }

        public Task<List<FavoriteId>> GetFavoriteIdsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FavoriteItem>> GetFavoritesAsync(int uid, int pn = 1)
        {
            throw new NotImplementedException();
        }

        public Task<List<FavoriteVideo>> GetFavoriteVideosAsync(IEnumerable<FavoriteId> ids)
        {
            throw new NotImplementedException();
        }

        public Task<FeedLikeResponse> GetLikeMeListAsync(long id, int likeTime = 0)
        {
            throw new NotImplementedException();
        }

        public Task<Me> GetMeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FanResponse> GetMyFansAsync(int page, long reversion = 0)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<int, List<FavoriteAnime>>> GetMyFavoriteAnimeAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<int, List<FavoriteAnime>>> GetMyFavoriteCinemaAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<List<FollowTag>> GetMyFollowTagsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<RelationUser>> GetMyFollowUserAsync(int tagId, int pn)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<FavoriteItem>, List<FavoriteItem>>> GetMyMainlyFavoritesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MyMessage> GetMyUnreadMessageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FeedReplyResponse> GetReplyMeListAsync(int replyTime = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ArchiveResponse> GetUserArchiveAsync(int uid, int page)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmojiReplyContainer>> GetUserEmojiAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> GetUserSpaceAsync(int uid)
        {
            throw new NotImplementedException();
        }

        public Task<List<VideoDetail>> GetVideoHistoryAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<List<VideoDetail>> GetViewLaterAsync(int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<LoginCallback> LoginAsync(string userName, string password, string captcha = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefreshTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFavoriteVideoAsync(int aid, int videoType, int listId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetLoginStatusAsync(string accessToken, string refreshToken = "", int expiry = 0)
        {
            throw new NotImplementedException();
        }

        public Task SSO()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnfollowUser(int uid)
        {
            throw new NotImplementedException();
        }
    }
}
