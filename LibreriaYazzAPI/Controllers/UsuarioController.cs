using AutoMapper;
using Busniess;
using IBusniess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestResponse;
using System.Security.Claims;
using RequestResponseModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using LoginRequest = RequestResponseModel.LoginRequest;
namespace LibreriaYazzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /**
         * NO VAMOS A IMPLEMENTAR TRU CATCH EN CADA METODO
         * DEBIDO QUE VAMOS A HACER USO DE UN MIDDLEWARE
         * MIDDLEWARE ==> GESTIONAR LOS ERRORES DE TODA LA APLICACIÓN
         * PODEMOS HACER VALIDACIONES A NIVE LOS DE LOS PARAMETROS DEL HEADER
         */

        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IUsuarioBusniess _UsuarioBusniess;
        private readonly ILoginBussniess _loginBussniess;
        private readonly IUsuarioVBussniess _UsuarioVBusniess;
        private readonly IMapper _mapper;
        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
            _UsuarioBusniess = new UsuarioBusniess(mapper);
            _UsuarioVBusniess = new UsuarioVBussniess(mapper);
            _loginBussniess = new LoginBussniess(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Usuario
        /// </summary>
        /// <returns>List-UsuarioResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_UsuarioBusniess.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>UsuarioResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_UsuarioBusniess.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Usuario
        /// </summary>
        /// <param name="request">UsuarioRequest</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult Create([FromBody] UsuarioVRequest request)
        {
            UsuarioVResponse usuarioVResponse = _UsuarioVBusniess.Create(request);
            if(usuarioVResponse!=null)
            {
                LoginRequest loginRequest = new LoginRequest();
                loginRequest.UserName = request.Usuario1;
                loginRequest.Password = request.Contrasenia;
                LoginResponse responseLogin = _loginBussniess.Login(loginRequest);
                if (responseLogin.Success)
                {
                    responseLogin.Token = CreateToken(responseLogin);
                    usuarioVResponse.LoginResponse = _mapper.Map<LoginResponse>(responseLogin);

                    return Ok(usuarioVResponse);
                }
            }

            return Ok(usuarioVResponse);

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
        /// <summary>
        /// RETORNA LA TABLA Usuario EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost("filter")]
        //public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        //{
        //    GenericFilterResponse<UsuarioResponse> res = _UsuarioBusniess.GetByFilter(request);

        //    return Ok(res);
        //}

        /// <summary>
        /// RETORNA LA TABLA Usuario EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<UsuarioRequest> request)
        {
            List<UsuarioResponse> res = _UsuarioBusniess.CreateMultiple(request);

            return Ok(res);
        }




        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Usuario
        /// </summary>
        /// <param name="request">UsuarioRequest</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] UsuarioRequest request)
        {
            return Ok(_UsuarioBusniess.Update(request));
        }

        /// <summary>
        /// ELIMINA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>cantidad de registros eliminados</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult Delete(int id)
        {
            return Ok(_UsuarioBusniess.Delete(id));
        }
        #endregion CRUD METHODS


    }

}
