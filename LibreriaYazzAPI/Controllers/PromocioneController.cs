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
    public class PromocioneController : ControllerBase
    {
        /**
         * NO VAMOS A IMPLEMENTAR TRU CATCH EN CADA METODO
         * DEBIDO QUE VAMOS A HACER USO DE UN MIDDLEWARE
         * MIDDLEWARE ==> GESTIONAR LOS ERRORES DE TODA LA APLICACIÓN
         * PODEMOS HACER VALIDACIONES A NIVE LOS DE LOS PARAMETROS DEL HEADER
         */

        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IPromocioneBusniess _PromocioneBusniess;
        private readonly IMapper _mapper;
        public PromocioneController(IMapper mapper)
        {
            _mapper = mapper;
            _PromocioneBusniess = new PromocioneBusniess(mapper);
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Promocione
        /// </summary>
        /// <returns>List-PromocioneResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<PromocioneResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            //int a = 0, b=5, c=6;

            //sabemos que no puede haber una división entre ==> 0
            //c = b / a;


            return Ok(_PromocioneBusniess.GetAll());
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>PromocioneResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PromocioneResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_PromocioneBusniess.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Promocione
        /// </summary>
        /// <param name="request">PromocioneRequest</param>
        /// <returns>PromocioneResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PromocioneResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] PromocioneRequest request)
        {
            return Ok(_PromocioneBusniess.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA Promocione EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost("filter")]
        //public IActionResult GetByFilter([FromBody] GenericFilterRequest request)
        //{
        //    GenericFilterResponse<PromocioneResponse> res = _PromocioneBusniess.GetByFilter(request);

        //    return Ok(res);
        //}

        /// <summary>
        /// RETORNA LA TABLA Promocione EN BASE A PAGINACIÓN Y FIILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<PromocioneRequest> request)
        {
            List<PromocioneResponse> res = _PromocioneBusniess.CreateMultiple(request);

            return Ok(res);
        }




        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Promocione
        /// </summary>
        /// <param name="request">PromocioneRequest</param>
        /// <returns>PromocioneResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PromocioneResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] PromocioneRequest request)
        {
            return Ok(_PromocioneBusniess.Update(request));
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
            return Ok(_PromocioneBusniess.Delete(id));
        }
        #endregion CRUD METHODS


    }

}
