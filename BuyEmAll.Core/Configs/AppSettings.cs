namespace BuyEmAll.Core.Configs
{
    public class AppSettings
    {
        public string APIUrl { get; set; }
        public Token Token { get; set; }
    }

    public class Token
    {
        public string JWTKey { get; set; }
        public string JWTIssuer { get; set; }
    }
}
