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
    public class CalificacioneBusniess : ICalificacioneBusniess
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly ICalificacioneRepository _CalificacioneRepository;
        private readonly IMapper _mapper;
        public CalificacioneBusniess(IMapper mapper)
        {
            _mapper = mapper;
            _CalificacioneRepository = new CalificacioneRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
        public List<CalificacioneResponse> GetAll()
        {
            List<Calificacione> Calificaciones = _CalificacioneRepository.GetAll();
            List<CalificacioneResponse> lstResponse = _mapper.Map<List<CalificacioneResponse>>(Calificaciones);
            return lstResponse;
        }

        public CalificacioneResponse GetById(int id)
        {
            Calificacione Calificacione = _CalificacioneRepository.GetById(id);
            CalificacioneResponse resul = _mapper.Map<CalificacioneResponse>(Calificacione);
            return resul;
        }

        public CalificacioneResponse Create(CalificacioneRequest entity)
        {
            Calificacione Calificacione = _mapper.Map<Calificacione>(entity);
            Calificacione = _CalificacioneRepository.Create(Calificacione);
            CalificacioneResponse result = _mapper.Map<CalificacioneResponse>(Calificacione);
            return result;
        }
        public List<CalificacioneResponse> CreateMultiple(List<CalificacioneRequest> lista)
        {
            List<Calificacione> Calificaciones = _mapper.Map<List<Calificacione>>(lista);
            Calificaciones = _CalificacioneRepository.CreateMultiple(Calificaciones);
            List<CalificacioneResponse> result = _mapper.Map<List<CalificacioneResponse>>(Calificaciones);
            return result;
        }

        public CalificacioneResponse Update(CalificacioneRequest entity)
        {
            Calificacione Calificacione = _mapper.Map<Calificacione>(entity);
            Calificacione = _CalificacioneRepository.Update(Calificacione);
            CalificacioneResponse result = _mapper.Map<CalificacioneResponse>(Calificacione);
            return result;
        }

        public List<CalificacioneResponse> UpdateMultiple(List<CalificacioneRequest> lista)
        {
            List<Calificacione> Calificaciones = _mapper.Map<List<Calificacione>>(lista);
            Calificaciones = _CalificacioneRepository.UpdateMultiple(Calificaciones);
            List<CalificacioneResponse> result = _mapper.Map<List<CalificacioneResponse>>(Calificaciones);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _CalificacioneRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<CalificacioneRequest> lista)
        {
            List<Calificacione> Calificaciones = _mapper.Map<List<Calificacione>>(lista);
            int cantidad = _CalificacioneRepository.DeleteMultipleItems(Calificaciones);
            return cantidad;
        }

        //GenericFilterResponse<CalificacioneResponse> ICRUDBusniess<CalificacioneRequest, CalificacioneResponse>.GetByFilter(GenericFilterRequest request)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion END CRUD METHODS
    }
}