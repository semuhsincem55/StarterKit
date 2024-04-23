namespace Starterkit.Models
{
    public class LoginResponseViewModel
    {
        public LoginResponseData data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public LoginResponseViewModel()
        {
            data = new LoginResponseData();
        }
    }

    public class LoginResponseData
    {
        public List<string> claims { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string refreshToken { get; set; }
        public LoginResponseData()
        {
            claims = new List<string>();
        }
    }
}
