using AutoMapper;
using DBLibreria;
using DBLibreria.DBLibreria;
using RequestResponse;

namespace UtilAutoMaper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Calificacione, CalificacioneRequest>().ReverseMap();
            CreateMap<Calificacione, CalificacioneResponse>().ReverseMap();
            CreateMap<CalificacioneRequest, CalificacioneResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<DetallesDevolucione, DetallesDevolucioneRequest>().ReverseMap();
            CreateMap<DetallesDevolucione, DetallesDevolucioneResponse>().ReverseMap();
            CreateMap<DetallesDevolucioneRequest, DetallesDevolucioneResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<DetallesPedido, DetallesPedidoRequest>().ReverseMap();
            CreateMap<DetallesPedido, DetallesPedidoResponse>().ReverseMap();
            CreateMap<DetallesPedidoRequest, DetallesPedidoResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<DetallesPromocione, DetallesPromocioneRequest>().ReverseMap();
            CreateMap<DetallesPromocione, DetallesPromocioneResponse>().ReverseMap();
            CreateMap<DetallesPromocioneRequest, DetallesPromocioneResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<DetallesReembolso, DetallesReembolsoRequest>().ReverseMap();
            CreateMap<DetallesReembolso, DetallesReembolsoResponse>().ReverseMap();
            CreateMap<DetallesReembolsoRequest, DetallesReembolsoResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Devolucione, DevolucioneRequest>().ReverseMap();
            CreateMap<Devolucione, DevolucioneResponse>().ReverseMap();
            CreateMap<DevolucioneRequest, DevolucioneResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Envio, EnvioRequest>().ReverseMap();
            CreateMap<Envio, EnvioResponse>().ReverseMap();
            CreateMap<EnvioRequest, EnvioResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Imagene, ImageneRequest>().ReverseMap();
            CreateMap<Imagene, ImageneResponse>().ReverseMap();
            CreateMap<ImageneRequest, ImageneResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Pedido, PedidoRequest>().ReverseMap();
            CreateMap<Pedido, PedidoResponse>().ReverseMap();
            CreateMap<PedidoRequest, PedidoResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Persona, PersonaRequest>().ReverseMap();
            CreateMap<Persona, PersonaResponse>().ReverseMap();
            CreateMap<PersonaRequest, PersonaResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Producto, ProductoRequest>().ReverseMap();
            CreateMap<Producto, ProductoResponse>().ReverseMap();
            CreateMap<ProductoRequest, ProductoResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Promocione, PromocioneRequest>().ReverseMap();
            CreateMap<Promocione, PromocioneResponse>().ReverseMap();
            CreateMap<PromocioneRequest, PromocioneResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Proveedore, ProveedoreRequest>().ReverseMap();
            CreateMap<Proveedore, ProveedoreResponse>().ReverseMap();
            CreateMap<ProveedoreRequest, ProveedoreResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<ProveedorProducto, ProveedorProductoRequest>().ReverseMap();
            CreateMap<ProveedorProducto, ProveedorProductoResponse>().ReverseMap();
            CreateMap<ProveedorProductoRequest, ProveedorProductoResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Rol, RolRequest>().ReverseMap();
            CreateMap<Rol, RolResponse>().ReverseMap();
            CreateMap<RolRequest, RolResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<TipoDocumento, TipoDocumentoRequest>().ReverseMap();
            CreateMap<TipoDocumento, TipoDocumentoResponse>().ReverseMap();
            CreateMap<TipoDocumentoRequest, TipoDocumentoResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<Usuario, Usuario>().ReverseMap();
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            //CreateMap<GenericFilterResponse<PersonaResponse>, GenericFilterResponse<Persona>>().ReverseMap();

            CreateMap<ProductoResponse, VwProducto>().ReverseMap();
            CreateMap<VwProducto, ProductoResponse>().ReverseMap();

            #region PERFIL
            CreateMap<Perfil, UsuarioResponse>().ReverseMap();
            CreateMap<UsuarioResponse, Perfil>().ReverseMap();

            #endregion PERFIL

        }
    }
}
