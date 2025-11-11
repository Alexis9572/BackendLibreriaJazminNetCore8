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
    public class DetallesPromocioneBusniess : IDetallesPromocioneBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IDetallesPromocioneRepository _DetallesPromocioneRepository;
            private readonly IMapper _mapper;
            public DetallesPromocioneBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _DetallesPromocioneRepository = new DetallesPromocioneRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<DetallesPromocioneResponse> GetAll()
            {
                List<DetallesPromocione> DetallesPromociones = _DetallesPromocioneRepository.GetAll();
                List<DetallesPromocioneResponse> lstResponse = _mapper.Map<List<DetallesPromocioneResponse>>(DetallesPromociones);
                return lstResponse;
            }

         public DetallesPromocioneResponse GetById(int id)
            {
                DetallesPromocione DetallesPromocione = _DetallesPromocioneRepository.GetById(id);
                DetallesPromocioneResponse resul = _mapper.Map<DetallesPromocioneResponse>(DetallesPromocione);
                return resul;
            }

         public DetallesPromocioneResponse Create(DetallesPromocioneRequest entity)
            {
                DetallesPromocione DetallesPromocione = _mapper.Map<DetallesPromocione>(entity);
                DetallesPromocione = _DetallesPromocioneRepository.Create(DetallesPromocione);
                DetallesPromocioneResponse result = _mapper.Map<DetallesPromocioneResponse>(DetallesPromocione);
                return result;
            }
         public List<DetallesPromocioneResponse> CreateMultiple(List<DetallesPromocioneRequest> lista)
            {
                List<DetallesPromocione> DetallesPromociones = _mapper.Map<List<DetallesPromocione>>(lista);
                DetallesPromociones = _DetallesPromocioneRepository.CreateMultiple(DetallesPromociones);
                List<DetallesPromocioneResponse> result = _mapper.Map<List<DetallesPromocioneResponse>>(DetallesPromociones);
                return result;
            }

         public DetallesPromocioneResponse Update(DetallesPromocioneRequest entity)
            {
                DetallesPromocione DetallesPromocione = _mapper.Map<DetallesPromocione>(entity);
                DetallesPromocione = _DetallesPromocioneRepository.Update(DetallesPromocione);
                DetallesPromocioneResponse result = _mapper.Map<DetallesPromocioneResponse>(DetallesPromocione);
                return result;
            }

         public List<DetallesPromocioneResponse> UpdateMultiple(List<DetallesPromocioneRequest> lista)
            {
                List<DetallesPromocione> DetallesPromociones = _mapper.Map<List<DetallesPromocione>>(lista);
                DetallesPromociones = _DetallesPromocioneRepository.UpdateMultiple(DetallesPromociones);
                List<DetallesPromocioneResponse> result = _mapper.Map<List<DetallesPromocioneResponse>>(DetallesPromociones);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _DetallesPromocioneRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<DetallesPromocioneRequest> lista)
            {
                List<DetallesPromocione> DetallesPromociones = _mapper.Map<List<DetallesPromocione>>(lista);
                int cantidad = _DetallesPromocioneRepository.DeleteMultipleItems(DetallesPromociones);
                return cantidad;
            }

         //GenericFilterResponse<DetallesPromocioneResponse> ICRUDBusniess<DetallesPromocioneRequest, DetallesPromocioneResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}