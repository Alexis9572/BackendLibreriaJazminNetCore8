using AutoMapper;
using DBLibreria.DBLibreria;
using IBusniess;
using IRepository;
using Repository;
using RequestResponse;
using RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilSecurity;


namespace busniess
{
    public class Authbusniess : IAuthbusniess
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IUsuarioBusniess _usuariobusniess;
        private readonly IUsuarioRepository _usuarioRespository;
        private readonly IMapper _mapper;
        //private readonly IRolbusniess _rolbusniess;
        private readonly UtilEncriptarDesencriptar _cripto;
        public Authbusniess(IMapper mapper)
        {
            _mapper = mapper;
            //_usuariobusniess = new Usuariobusniess(mapper);
            _usuarioRespository = new UsuarioRepository();
            //_rolbusniess = new Rolbusniess(mapper);
            _cripto = new UtilEncriptarDesencriptar();
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
     
        public LoginResponse Login(LoginRequest request)
        {
           
                LoginResponse result = new LoginResponse();

                //01 VALIDAMOS QUE EL USUARIO EXISTA
                Usuario usuario = _usuarioRespository.obtenerUsuario(request.UserName);
                if (usuario == null)
                {
                    return result;
                }


                //02 VALIDAMOS QUE EL USUARIO EXISTA
                //02.01 ==> proceso de encriptar un texto
                string newPassword = _cripto.AES_encriptar(request.Password);

                if (newPassword != usuario.Contrasenia)
                {
                    return result;
                }

                result.Success = true;
                result.Mensaje = "LOGIN CORRECTO";
                result.Usuario = new Usuario();
                result.Usuario.Usuario1 = usuario.Usuario1;
                result.Usuario.Id = usuario.Id;
                result.Persona = new PersonaResponse();
                result.Persona.Nombre = usuario.Usuario1;
                result.Usuario.RolId = usuario.RolId;
                //result.Usuario = new UsuarioLoginResponse();
                //result.Usuario.Id = usuario.Id;
                //result.Usuario.Username = usuario.Username;
                //result.Usuario.IdEstado = usuario.IdEstado;
                //result.Usuario.ChangePassword = usuario.ChangePassword;
                //result.Usuario.IdPersona = usuario.IdPersona;
                //result.Usuario.IdentificadorCelular = "";
                //result.Usuario.ChangePassword = usuario.ChangePassword;
                //result.Usuario.Email = usuario.Email;
                //result.Rol = new RolResponse();
                //result.Rol.Id = usuario.IdRol;
                //result.Rol.Codigo = usuario.RolCodigo;
                //result.Rol.Descripcion = usuario.RolDescripcion;
                //result.Persona = new PersonaResponse();
                //result.Persona.NombreCompleto = usuario.NombreCompleto;

            /*ESTE TIPO DE IMPLEMENTACIÓN NO ES LA MAS OPTIMA*/
            /*
             * VAMOS A REALIZAR CONSULTAS INDEPENDIENTES
             * _rolbusniess
             * _personabusniess
             */

            //result.Usuario = new UsuarioLoginResponse();
            //result.Rol = new RolResponse();
            //busqueda del usuario
            //busqueda del rol
                return result;
            }

        
    }
}
