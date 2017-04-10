namespace EasyFlights.Web.Identity
{
    public class FacebookOauthResponse
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }
    }
}