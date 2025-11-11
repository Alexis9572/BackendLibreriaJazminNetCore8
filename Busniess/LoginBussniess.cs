using AutoMapper;
using DBLibreria;
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

namespace Busniess
{
    public class LoginBussniess : ILoginBussniess
    {
        #region INYECCION DE DEPENDENCIAS

        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly UtilEncriptarDesencriptar _cripto;
        private readonly IMapper _mapper;


        public LoginBussniess (IMapper mapper)
        {
            _mapper = mapper;
            _UsuarioRepository = new UsuarioRepository();
            _cripto = new UtilEncriptarDesencriptar();


        }

        #endregion INYECCION DE DEPENDENCIAS
        public LoginResponse Login(LoginRequest login)
        {
            LoginResponse responseLogin = new LoginResponse();
            Persona persona = new Persona();
            Usuario usuario = _UsuarioRepository.obtenerUsuario(login.UserName);
            Perfil perfil = _UsuarioRepository.perfil(login.UserName);
            if (usuario == null) 
            {
                responseLogin.Mensaje = "Usuarname y Contraseña incorrecta";
                return responseLogin;
            
            }
            string newPassword = _cripto.AES_encriptar(login.Password);
            if(newPassword == usuario.Contrasenia)
            {
                responseLogin.Success = true;
                responseLogin.Mensaje = "Usuario y contraseña correcto ";
                responseLogin.Usuario = new Usuario();
                responseLogin.Usuario.Usuario1 = usuario.Usuario1;
                responseLogin.Usuario.Id = usuario.Id;
                responseLogin.Usuario.RolId = usuario.RolId;
                responseLogin.Rol = new RolResponse();
                responseLogin.Rol.Id = usuario.RolId;
                responseLogin.Persona = new PersonaResponse();
                responseLogin.Persona.Nombre = usuario.Usuario1;
                responseLogin.Persona.Nombre = perfil.Nombre;
                responseLogin.Persona.Correo = perfil.Correo; 
                responseLogin.Persona.Direccion = perfil.Direccion;
                return responseLogin;
            }
            return responseLogin;
        }
    }
}
