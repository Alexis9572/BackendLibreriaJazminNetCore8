using AutoMapper;
using CommonModel;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RequestResponse.Response;
using System.Runtime.CompilerServices;

namespace ApiWeb.Middleware.Error
{
    public class ApiMiddleware
    {
        #region Inyeccion de dependencias
        private readonly RequestDelegate next;
        private readonly IHelperHttpContext _helperHttpContext;
        private readonly IMapper _mapper;
        public ApiMiddleware(RequestDelegate next, IMapper mapper)
        {
            this.next = next;
            _helperHttpContext = new HelperHttpContext();
            _mapper = mapper;
        }
        #endregion Inyeccion de dependencias
        #region
        public async Task Invoke(HttpContext contex)
        {
            try
            {
                contex.Request.EnableBuffering();
                await next(contex);
            }
            catch(SqlException ex)
            {
                CustomException exx = new("001","Error de base de datos");
                await HandleExceptionAsyn(contex,exx);
            }
            catch (DbUpdateException ex)
            {
                CustomException exx = new("002", "Error al actualizar registros");
                await HandleExceptionAsyn(contex, exx);
            }
            catch (DivideByZeroException ex)
            {
                CustomException exx = new("003", "Error al division entre 0");
                await HandleExceptionAsyn(contex, exx);
            }
            catch (ArithmeticException ex)
            {
                CustomException exx = new("004", "Error al hacer algun calculo");
                await HandleExceptionAsyn(contex, exx);
            }
            catch (Exception ex)
            {
                CustomException exx = new("005", "Error no controlado");
                await HandleExceptionAsyn(contex, exx);
            }
        }

        private Task HandleExceptionAsyn(HttpContext contex, CustomException ex)
        {
            var controllerActionDescriptor = contex.GetEndpoint().Metadata.GetMetadata<ControllerActionDescriptor>();
            InfoRequest info = _helperHttpContext.GetInfoRequest(contex);
            ResponseGeneric error = new();
            contex.Response.ContentType = "application/json";
            contex.Response.StatusCode = 500;
            return contex.Response.WriteAsJsonAsync(error);
        }
        #endregion
    }
}
