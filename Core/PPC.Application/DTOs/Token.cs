namespace PPC.Application.DTOs
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
