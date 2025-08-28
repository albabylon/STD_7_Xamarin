using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HomeApp.MobileClient.Extensions
{
    public static class HttpExtension
    {
        /// <summary>
        /// Отключаем проверку ошибок SSL
        /// </summary>
        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}
