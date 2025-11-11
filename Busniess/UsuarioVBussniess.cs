using AutoMapper;
using IBusniess;
using IRepository;
using Repository;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busniess
{
    public class UsuarioVBussniess : IUsuarioVBussniess
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IUsuarioBusniess _usuarioBussniess;
        private readonly IPersonaBusniess _personaBussniess;
        private readonly IRolBusniess _rolBussniess;
        private readonly ITipoDocumentoBusniess _tipoDocumentoBussniess;
        private readonly IMapper _mapper;
        public UsuarioVBussniess(IMapper mapper)
        {
            _usuarioBussniess = new UsuarioBusniess(mapper);
            _personaBussniess = new PersonaBusniess (mapper);
            _rolBussniess = new RolBusniess(mapper);
            _tipoDocumentoBussniess = new TipoDocumentoBusniess(mapper);
            _mapper = mapper;
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        public UsuarioVResponse Create(UsuarioVRequest entity)
        {
            PersonaResponse personaResponse = new PersonaResponse();
            //Creacion de persona

            PersonaRequest personaRequest = _mapper.Map<PersonaRequest>(entity);
            personaResponse = _personaBussniess.Create(personaRequest);


            throw new NotImplementedException();
        }

        public List<UsuarioVResponse> CreateMultiple(List<UsuarioVRequest> lista)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteMultipleItems(List<UsuarioVRequest> lista)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<UsuarioVResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioVResponse GetById(int id)
        {
            //Obtengo el id del sesion store

            //Busco en la base de datos y me devuelve la lista del usuario

            //Despues de obtener la vista con el persona_id busco la lista y me devuelve la lista de su persona 

            //Despues de obtener la vista con el rol_Id busco la lista y me devuelve la lista de su rol 

            //Despues lo alamaceno en UsuarioVResponse
            

            throw new NotImplementedException();
        }

        public UsuarioVResponse Update(UsuarioVRequest entity)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioVResponse> UpdateMultiple(List<UsuarioVRequest> lista)
        {
            throw new NotImplementedException();
        }
    }
}
