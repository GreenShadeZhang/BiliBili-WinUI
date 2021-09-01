namespace BiliBili.Core
{
    /// <summary>
    /// 用于处理包含自带主题色的条目
    /// </summary>
    public interface IAlphaBackground
    {
        string theme_color { get; set; }
        int alpha { get; set; }
    }
}
