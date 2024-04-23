using System.IdentityModel.Tokens.Jwt;

namespace Starterkit.Services
{
    public class TokenService
    {
        private string _token;

        public string Token
        {
            get => _token;
            set => _token = value;
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(_token);

        public void SetToken(string token)
        {
            _token = token;
        }

        public void ClearToken()
        {
            _token = null;
        }

		public JWTTokenObject Parse(string token)
		{
			var handler = new JwtSecurityTokenHandler();
			var tokenSatinAlabilir = handler.CanReadToken(token);

			if (tokenSatinAlabilir)
			{
				var jwtToken = handler.ReadJwtToken(token);

				// İlgili claim'leri okuma
				var TenantId = jwtToken.Claims.First(claim => claim.Type == "TenantId").Value;
				var FullName = jwtToken.Claims.First(claim => claim.Type == "FullName").Value;
				var UserStatus = jwtToken.Claims.First(claim => claim.Type == "UserStatus").Value;
				var IsCompanyUser = jwtToken.Claims.First(claim => claim.Type == "IsCompanyUser").Value;

				// Token'ın son kullanma tarihini alma
				var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				var GecerlilikTarihi = unixEpoch.AddSeconds(Convert.ToInt64(jwtToken.Claims.First(claim => claim.Type == "exp").Value));
				if (DateTime.Now > GecerlilikTarihi)
				{
					return null;
				}
				return new JWTTokenObject()
				{
					FullName = FullName,
					GecerlilikTarihi = GecerlilikTarihi,
					IsCompanyUser = IsCompanyUser,
					TenantId = TenantId,
					UserStatus = UserStatus,
				};
			}
			else
			{
				return null;
			}
		}
		public class JWTTokenObject
		{
            public string TenantId { get; set; }
            public string FullName { get; set; }
            public string UserStatus { get; set; }
            public string IsCompanyUser { get; set; }
            public DateTime GecerlilikTarihi { get; set; }
		}
	}
}
