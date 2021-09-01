using System.Collections.Generic;

namespace BiliBili.Core
{
    public class FeedAtResponse
    {
        public FeedCursor cursor { get; set; }
        public List<FeedAtDetail> items { get; set; }
    }

    public class FeedAtDetail : FeedDetail
    {
        public FeedItem item { get; set; }
        public int at_time { get; set; }
    }
}
