using AutoMapper;
using Busniess;
using IBusniess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestResponse;
using RequestResponse;
using RequestResponseModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UtilSecurity;
using LoginRequest = RequestResponseModel.LoginRequest;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Declaracion de Variables 
        private readonly ILoginBussniess _loginBussniess;
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
            _loginBussniess = new LoginBussniess(mapper);
        }

        #endregion Fin Declaracion de Variabkles

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest entity)
        {
            LoginResponse responseLogin = _loginBussniess.Login(entity);
            if (responseLogin.Success)
            {
                responseLogin.Token = CreateToken(responseLogin);
                return Ok(responseLogin);
            }
            return Ok(responseLogin);
        }
        private string CreateToken(LoginResponse responseLogin)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]);
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("Id",  responseLogin.Usuario.Id.ToString()),
                        new Claim("Nombre", responseLogin.Persona.Nombre),
                        new Claim("Id",responseLogin.Rol.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(tiempoVida),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                                                                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDes);
            return tokenHandler.WriteToken(token);
        }
    }
}
//    public class AuthController : ControllerBase
//    {

//        /*INYECCIÓN DE DEPENDECIAS*/
//        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
//        private readonly IAuthbusniess _authbusniess;
//        private readonly IMapper _mapper;
//        private readonly UtilEncriptarDesencriptar _cripto;

//        public AuthController(IMapper mapper)
//        {
//            _mapper = mapper;
//            _authbusniess = new Authbusniess(mapper);
//            _cripto = new UtilEncriptarDesencriptar();
//        }

//        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR


//        /// <summary>
//        /// Valida que el servicio este activo
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
//        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
//        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
//        public IActionResult Get()
//        {
//            return Ok(true);
//        }

//        /// <summary>
//        /// Metodo para realizar el inicio de sesión
//        /// </summary>
//        /// <param name="request"></param>
//        /// <returns></returns>
//        [HttpPost]
//        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
//        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
//        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
//        public IActionResult Login([FromBody] LoginRequest request)
//        {
//            //

//            // if(request.usuario == "admin" && password == "123456")
//            //{
//            //userResponse.name = "";
//            //...
//            //...
//            //...
//            //...
//            //generas el token
//            //}

//            LoginResponse loginResponse = _authbusniess.Login(request);

//            loginResponse.Token = CreateToken(loginResponse);
//            return Ok(loginResponse);
//        }
//        #region INICIO GENERACIÓN DE TOKEN

//        private string CreateToken(LoginResponse oLoginResponse)
//        {
//            //obteniendo información de nuestro archivo appsettings.json
//            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
//            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
//            IConfiguration configurationFile = configurationBuild.Build();

//            //OBTENER EL TIEMPO DE VIDA DEL TOKEN
//            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);
//            //01 VAMOS A DETALLAR LOS CLAIMS
//            //==> INFORMACIÓN QUE SE PUEDE ALMACENAR DENTRO DEL TOKEN GENERADO

//            /**
//             * VAMOS A DECLARAR LOS CLAIMS - LA INFORMACIÓN QUE SE VA A CARGAR DENTRO DEL TOKEN
//             */


//            //string stringClaims = JsonConvert.SerializeObject(oLoginResponse);
//            //stringClaims = _cripto.AES_encriptar(stringClaims);

//            var claims = new[] {
//                        new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
//                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),// - UTC-0
//                        new Claim(ClaimTypes.Role, oLoginResponse.Rol.Id.ToString()),
//                        new Claim("UserId", oLoginResponse.Usuario.Id.ToString()),
//                        new Claim("DisplayName", oLoginResponse.Persona.NombreCompleto),
//                        new Claim("UserName", oLoginResponse.Usuario.Username),
//                        new Claim("RoleName", oLoginResponse.Rol.Descripcion),
//                    };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
//            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var token = new JwtSecurityToken(
//                configurationFile["Jwt:Issuer"],
//                configurationFile["Jwt:Audience"],
//                claims,
//                expires: DateTime.UtcNow.AddHours(tiempoVida),
//                signingCredentials: signIn

//                );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        #endregion FIN GENERACIÓN DE TOKEN


//    }