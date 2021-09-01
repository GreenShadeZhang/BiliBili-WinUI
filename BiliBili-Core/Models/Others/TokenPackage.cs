namespace BiliBili.Core
{
    public class TokenPackage
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int Expiry { get; set; }
        public TokenPackage()
        {
            AccessToken = "";
            RefreshToken = "";
            Expiry = 0;
        }
        public TokenPackage(string acc, string refe, int exp)
        {
            AccessToken = acc;
            RefreshToken = refe;
            Expiry = exp;
        }
    }
}
