namespace BiliBili.Core
{
    public class UriResult
    {
        public UriType Type { get; set; }
        public string Param { get; set; }
        public UriResult()
        {

        }
        public UriResult(UriType t, string p)
        {
            Type = t;
            Param = p;
        }
    }
}
