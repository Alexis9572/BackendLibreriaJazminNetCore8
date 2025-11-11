using CommonModel;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace ApiWeb.Middleware.Error
{
    public class HelperHttpContext : IHelperHttpContext
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public InfoRequest GetInfoRequest(HttpContext request)
        {
            InfoRequest Info = new InfoRequest();
            Info.Claims = GetTokenClaims(request);
            Info.RequestHttp = GetHttpContexInfo(request);
            return Info;
        }

        private ApiRequetsContext GetHttpContexInfo(HttpContext request)
        {
            ApiRequetsContext api = new();
            api.AbsolutePath = request.Request.GetEncodedUrl();
            api.AbsoluteUri = request.Request.GetEncodedPathAndQuery();
            api.Ip = request.Connection.RemoteIpAddress.ToString();
            api.Method = $"{request.Request.Method}";
            api.UserAgent = request.Request.Headers[HeaderNames.UserAgent];
            api.Controller = request.GetEndpoint().ToString();
            api.Host = request.Request.Headers[HeaderNames.Host];
            try
            {
                var reader = new StreamReader(request.Response.Body);
                reader.BaseStream.Seek(0,SeekOrigin.Begin);
                api.BodyRequest = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                api.BodyRequest = "";
            }
            return api;
        }

        private TokenClaims GetTokenClaims(HttpContext request)
        {
            TokenClaims Token = new TokenClaims();
            string? autorizacion = request.Request.Headers[HeaderNames.Authorization];
            if (autorizacion != null)
            {
                var identity = request.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> Claims = identity.Claims;
                    Token.IdUsuario = int.Parse(identity.Claims.Where(c => c.Type == "IdUsuario").Select(c => c.Value).SingleOrDefault());
                    Token.NombrePersona = identity.Claims.Where(c => c.Type == "NombrePersona").Select(c => c.Value).SingleOrDefault();
                    Token.NombreRol = identity.Claims.Where(c => c.Type == "NombreRol").Select(c => c.Value).SingleOrDefault();
                }
            }
            return Token;
        }
    }
}
