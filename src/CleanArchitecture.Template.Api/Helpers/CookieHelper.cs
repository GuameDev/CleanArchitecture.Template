using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Template.Api.Helpers
{
    public static class CookieHelper
    {
        public static void SetCookie(HttpResponse response, string key, string value, DateTime expirationDate)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = expirationDate
            };
            response.Cookies.Append(key, value, cookieOptions);
        }
    }
}
