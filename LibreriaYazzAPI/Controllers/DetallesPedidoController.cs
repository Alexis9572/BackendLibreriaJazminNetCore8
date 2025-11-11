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
    public class DetallesPedidoController : ControllerBase
    {
        /**
         * NO VAMOS A IMPLEMENTAR TRU CATCH EN CADA METODO
         * DEBIDO QUE VAMOS A HACER USO DE UN MIDDLEWARE
         * MIDDLEWARE ==> GESTIONAR LOS ERRORES DE TODA LA APLICACIÓN
         * PODEMOS HACER VALIDACIONES A NIVE LOS DE LOS PARAMETROS DEL HEADER
         */

        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IDetallesPedidoBusniess _DetallesPedidoBusniess;
        private readonly IMapper _mapper;
        public DetallesPedidoController(IMapper mapper)
        {
            _mapper = mapper;
            _DetallesPedidoBusniess = new DetallesPedidoBusniess(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA DetallesPedido
        /// </summary>
        /// <returns>List-DetallesPedidoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DetallesPedidoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_DetallesPedidoBusniess.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>DetallesPedidoResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetallesPedidoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_DetallesPedidoBusniess.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA DetallesPedido
        /// </summary>
        /// <param name="request">DetallesPedidoRequest</param>
        /// <returns>DetallesPedidoResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetallesPedidoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] DetallesPedidoRequest request)
        {
            return Ok(_DetallesPedidoBusniess.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA DetallesPedido EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost("filter")]
        //public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        //{
        //    GenericFilterResponse<DetallesPedidoResponse> res = _DetallesPedidoBusniess.GetByFilter(request);

        //    return Ok(res);
        //}

        /// <summary>
        /// RETORNA LA TABLA DetallesPedido EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<DetallesPedidoRequest> request)
        {
            List<DetallesPedidoResponse> res = _DetallesPedidoBusniess.CreateMultiple(request);

            return Ok(res);
        }




        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA DetallesPedido
        /// </summary>
        /// <param name="request">DetallesPedidoRequest</param>
        /// <returns>DetallesPedidoResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DetallesPedidoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] DetallesPedidoRequest request)
        {
            return Ok(_DetallesPedidoBusniess.Update(request));
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
            return Ok(_DetallesPedidoBusniess.Delete(id));
        }
        #endregion CRUD METHODS


    }

}
