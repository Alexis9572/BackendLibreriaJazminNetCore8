using AutoMapper;
using Busniess;
using IBusniess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponse;
using RequestResponseModel;
using System.Net;

namespace LibreriaYazzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucioneController : ControllerBase
    {
        /**
         * NO VAMOS A IMPLEMENTAR TRU CATCH EN CADA METODO
         * DEBIDO QUE VAMOS A HACER USO DE UN MIDDLEWARE
         * MIDDLEWARE ==> GESTIONAR LOS ERRORES DE TODA LA APLICACIÓN
         * PODEMOS HACER VALIDACIONES A NIVE LOS DE LOS PARAMETROS DEL HEADER
         */

        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IDevolucioneBusniess _DevolucioneBusniess;
        private readonly IMapper _mapper;
        public DevolucioneController(IMapper mapper)
        {
            _mapper = mapper;
            _DevolucioneBusniess = new DevolucioneBusniess(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Devolucione
        /// </summary>
        /// <returns>List-DevolucioneResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DevolucioneResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_DevolucioneBusniess.listaDevoluciones());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>DevolucioneResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DevolucioneResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_DevolucioneBusniess.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Devolucione
        /// </summary>
        /// <param name="request">DevolucioneRequest</param>
        /// <returns>DevolucioneResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DevolucioneResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] DevolucioneRequest request)
        {
            return Ok(_DevolucioneBusniess.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA Devolucione EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost("filter")]
        //public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        //{
        //    GenericFilterResponse<DevolucioneResponse> res = _DevolucioneBusniess.GetByFilter(request);

        //    return Ok(res);
        //}

        /// <summary>
        /// RETORNA LA TABLA Devolucione EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<DevolucioneRequest> request)
        {
            List<DevolucioneResponse> res = _DevolucioneBusniess.CreateMultiple(request);

            return Ok(res);
        }




        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Devolucione
        /// </summary>
        /// <param name="request">DevolucioneRequest</param>
        /// <returns>DevolucioneResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DevolucioneResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] DevolucioneRequest request)
        {
            return Ok(_DevolucioneBusniess.Update(request));
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
            return Ok(_DevolucioneBusniess.Delete(id));
        }
        #endregion CRUD METHODS


    }

}
