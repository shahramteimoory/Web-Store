﻿namespace EndPoint.site.Utilities
{
    public class CookiesManeger
    {
        /// <summary>
        /// چک میکنه اگه توکن داشته باشه میخونه اگه نداشته باشه ادد میکنه
        /// </summary>
        /// <returns></returns>
        public Guid GetBrowserId(HttpContext context)
        {

            string browserId = GetValue(context, "BrowserId");
            if (browserId == null)
            {
                string value = Guid.NewGuid().ToString();
                Add(context, "BrowserId", value);
                browserId = value;
            }
            Guid guidbrowser;
            Guid.TryParse(browserId, out guidbrowser);
            return guidbrowser;
        }
        public void Add(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value, getCookieOptions(context));
        }

        public bool Contains(HttpContext context, string token)
        {
            return context.Request.Cookies.ContainsKey(token);
        }

        public string GetValue(HttpContext context, string token)
        {
            string cookieValue;
            if (!context.Request.Cookies.TryGetValue(token, out cookieValue))
            {
                return null;
            }
            return cookieValue;
        }

        public void Remove(HttpContext context, string token)
        {
            if (context.Request.Cookies.ContainsKey(token))
            {
                context.Response.Cookies.Delete(token);
            }
        }


        private CookieOptions getCookieOptions(HttpContext context)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                Expires = DateTime.Now.AddDays(100),
            };
        }
    }
}

