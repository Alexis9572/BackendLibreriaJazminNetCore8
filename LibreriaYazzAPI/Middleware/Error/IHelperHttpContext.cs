using CommonModel;

namespace ApiWeb.Middleware.Error
{
    public interface IHelperHttpContext:IDisposable
    {
        InfoRequest GetInfoRequest(HttpContext request);
    }
}
