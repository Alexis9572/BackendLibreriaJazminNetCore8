using AutoMapper;
using DBLibreria.DBLibreria;
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
    public class PersonaBusniess : IPersonaBusniess
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IPersonaRepository _PersonaRepository;
        private readonly IMapper _mapper;
        public PersonaBusniess(IMapper mapper)
        {
            _mapper = mapper;
            _PersonaRepository = new PersonaRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<PersonaResponse> GetAll()
        {
            List<Persona> Personas = _PersonaRepository.GetAll();
            List<PersonaResponse> lstResponse = _mapper.Map<List<PersonaResponse>>(Personas);
            return lstResponse;
        }

        public PersonaResponse GetById(int id)
        {
            Persona Persona = _PersonaRepository.GetById(id);
            PersonaResponse resul = _mapper.Map<PersonaResponse>(Persona);
            return resul;
        }

        public PersonaResponse Create(PersonaRequest entity)
        {
            Persona Persona = _mapper.Map<Persona>(entity);
            Persona = _PersonaRepository.Create(Persona);
            PersonaResponse result = _mapper.Map<PersonaResponse>(Persona);
            return result;
        }
        public List<PersonaResponse> CreateMultiple(List<PersonaRequest> lista)
        {
            List<Persona> Personas = _mapper.Map<List<Persona>>(lista);
            Personas = _PersonaRepository.CreateMultiple(Personas);
            List<PersonaResponse> result = _mapper.Map<List<PersonaResponse>>(Personas);
            return result;
        }

        public PersonaResponse Update(PersonaRequest entity)
        {
            Persona Persona = _mapper.Map<Persona>(entity);
            Persona = _PersonaRepository.Update(Persona);
            PersonaResponse result = _mapper.Map<PersonaResponse>(Persona);
            return result;
        }

        public List<PersonaResponse> UpdateMultiple(List<PersonaRequest> lista)
        {
            List<Persona> Personas = _mapper.Map<List<Persona>>(lista);
            Personas = _PersonaRepository.UpdateMultiple(Personas);
            List<PersonaResponse> result = _mapper.Map<List<PersonaResponse>>(Personas);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _PersonaRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<PersonaRequest> lista)
        {
            List<Persona> Personas = _mapper.Map<List<Persona>>(lista);
            int cantidad = _PersonaRepository.DeleteMultipleItems(Personas);
            return cantidad;
        }

        //GenericFilterResponse<PersonaResponse> ICRUDBusniess<PersonaRequest, PersonaResponse>.GetByFilter(GenericFilterRequest request)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion END CRUD METHODS
    }
}