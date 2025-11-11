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
    public class DetallesReembolsoController : ControllerBase
    {
        /**
         * NO VAMOS A IMPLEMENTAR TRU CATCH EN CADA METODO
         * DEBIDO QUE VAMOS A HACER USO DE UN MIDDLEWARE
         * MIDDLEWARE ==> GESTIONAR LOS ERRORES DE TODA LA APLICACIÓN
         * PODEMOS HACER VALIDACIONES A NIVE LOS DE LOS PARAMETROS DEL HEADER
         */

        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IDetallesReembolsoBusniess _DetallesReembolsoBusniess;
        private readonly IMapper _mapper;
        public DetallesReembolsoController(IMapper mapper)
        {
            _mapper = mapper;
            _DetallesReembolsoBusniess = new DetallesReembolsoBusniess(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA DetallesReembolso
        /// </summary>
        /// <returns>List-DetallesReembolsoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DetallesReembolsoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_DetallesReembolsoBusniess.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>DetallesReembolsoResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetallesReembolsoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_DetallesReembolsoBusniess.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA DetallesReembolso
        /// </summary>
        /// <param name="request">DetallesReembolsoRequest</param>
        /// <returns>DetallesReembolsoResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetallesReembolsoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] DetallesReembolsoRequest request)
        {
            return Ok(_DetallesReembolsoBusniess.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA DetallesReembolso EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost("filter")]
        //public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        //{
        //    GenericFilterResponse<DetallesReembolsoResponse> res = _DetallesReembolsoBusniess.GetByFilter(request);

        //    return Ok(res);
        //}

        /// <summary>
        /// RETORNA LA TABLA DetallesReembolso EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<DetallesReembolsoRequest> request)
        {
            List<DetallesReembolsoResponse> res = _DetallesReembolsoBusniess.CreateMultiple(request);

            return Ok(res);
        }




        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA DetallesReembolso
        /// </summary>
        /// <param name="request">DetallesReembolsoRequest</param>
        /// <returns>DetallesReembolsoResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetallesReembolsoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] DetallesReembolsoRequest request)
        {
            return Ok(_DetallesReembolsoBusniess.Update(request));
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
            return Ok(_DetallesReembolsoBusniess.Delete(id));
        }
        #endregion CRUD METHODS


    }

}
