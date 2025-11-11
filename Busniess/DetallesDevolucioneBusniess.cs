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
    public class DetallesDevolucioneBusniess : IDetallesDevolucioneBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IDetallesDevolucioneRepository _DetallesDevolucioneRepository;
            private readonly IMapper _mapper;
            public DetallesDevolucioneBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _DetallesDevolucioneRepository = new DetallesDevolucioneRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<DetallesDevolucioneResponse> GetAll()
            {
                List<DetallesDevolucione> DetallesDevoluciones = _DetallesDevolucioneRepository.GetAll();
                List<DetallesDevolucioneResponse> lstResponse = _mapper.Map<List<DetallesDevolucioneResponse>>(DetallesDevoluciones);
                return lstResponse;
            }

         public DetallesDevolucioneResponse GetById(int id)
            {
                DetallesDevolucione DetallesDevolucione = _DetallesDevolucioneRepository.GetById(id);
                DetallesDevolucioneResponse resul = _mapper.Map<DetallesDevolucioneResponse>(DetallesDevolucione);
                return resul;
            }

         public DetallesDevolucioneResponse Create(DetallesDevolucioneRequest entity)
            {
                DetallesDevolucione DetallesDevolucione = _mapper.Map<DetallesDevolucione>(entity);
                DetallesDevolucione = _DetallesDevolucioneRepository.Create(DetallesDevolucione);
                DetallesDevolucioneResponse result = _mapper.Map<DetallesDevolucioneResponse>(DetallesDevolucione);
                return result;
            }
         public List<DetallesDevolucioneResponse> CreateMultiple(List<DetallesDevolucioneRequest> lista)
            {
                List<DetallesDevolucione> DetallesDevoluciones = _mapper.Map<List<DetallesDevolucione>>(lista);
                DetallesDevoluciones = _DetallesDevolucioneRepository.CreateMultiple(DetallesDevoluciones);
                List<DetallesDevolucioneResponse> result = _mapper.Map<List<DetallesDevolucioneResponse>>(DetallesDevoluciones);
                return result;
            }

         public DetallesDevolucioneResponse Update(DetallesDevolucioneRequest entity)
            {
                DetallesDevolucione DetallesDevolucione = _mapper.Map<DetallesDevolucione>(entity);
                DetallesDevolucione = _DetallesDevolucioneRepository.Update(DetallesDevolucione);
                DetallesDevolucioneResponse result = _mapper.Map<DetallesDevolucioneResponse>(DetallesDevolucione);
                return result;
            }

         public List<DetallesDevolucioneResponse> UpdateMultiple(List<DetallesDevolucioneRequest> lista)
            {
                List<DetallesDevolucione> DetallesDevoluciones = _mapper.Map<List<DetallesDevolucione>>(lista);
                DetallesDevoluciones = _DetallesDevolucioneRepository.UpdateMultiple(DetallesDevoluciones);
                List<DetallesDevolucioneResponse> result = _mapper.Map<List<DetallesDevolucioneResponse>>(DetallesDevoluciones);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _DetallesDevolucioneRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<DetallesDevolucioneRequest> lista)
            {
                List<DetallesDevolucione> DetallesDevoluciones = _mapper.Map<List<DetallesDevolucione>>(lista);
                int cantidad = _DetallesDevolucioneRepository.DeleteMultipleItems(DetallesDevoluciones);
                return cantidad;
            }

         //GenericFilterResponse<DetallesDevolucioneResponse> ICRUDBusniess<DetallesDevolucioneRequest, DetallesDevolucioneResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}