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
    public class PromocioneBusniess : IPromocioneBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IPromocioneRepository _PromocioneRepository;
            private readonly IMapper _mapper;
            public PromocioneBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _PromocioneRepository = new PromocioneRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<PromocioneResponse> GetAll()
            {
                List<Promocione> Promociones = _PromocioneRepository.GetAll();
                List<PromocioneResponse> lstResponse = _mapper.Map<List<PromocioneResponse>>(Promociones);
                return lstResponse;
            }

         public PromocioneResponse GetById(int id)
            {
                Promocione Promocione = _PromocioneRepository.GetById(id);
                PromocioneResponse resul = _mapper.Map<PromocioneResponse>(Promocione);
                return resul;
            }

         public PromocioneResponse Create(PromocioneRequest entity)
            {
                Promocione Promocione = _mapper.Map<Promocione>(entity);
                Promocione = _PromocioneRepository.Create(Promocione);
                PromocioneResponse result = _mapper.Map<PromocioneResponse>(Promocione);
                return result;
            }
         public List<PromocioneResponse> CreateMultiple(List<PromocioneRequest> lista)
            {
                List<Promocione> Promociones = _mapper.Map<List<Promocione>>(lista);
                Promociones = _PromocioneRepository.CreateMultiple(Promociones);
                List<PromocioneResponse> result = _mapper.Map<List<PromocioneResponse>>(Promociones);
                return result;
            }

         public PromocioneResponse Update(PromocioneRequest entity)
            {
                Promocione Promocione = _mapper.Map<Promocione>(entity);
                Promocione = _PromocioneRepository.Update(Promocione);
                PromocioneResponse result = _mapper.Map<PromocioneResponse>(Promocione);
                return result;
            }

         public List<PromocioneResponse> UpdateMultiple(List<PromocioneRequest> lista)
            {
                List<Promocione> Promociones = _mapper.Map<List<Promocione>>(lista);
                Promociones = _PromocioneRepository.UpdateMultiple(Promociones);
                List<PromocioneResponse> result = _mapper.Map<List<PromocioneResponse>>(Promociones);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _PromocioneRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<PromocioneRequest> lista)
            {
                List<Promocione> Promociones = _mapper.Map<List<Promocione>>(lista);
                int cantidad = _PromocioneRepository.DeleteMultipleItems(Promociones);
                return cantidad;
            }

         //GenericFilterResponse<PromocioneResponse> ICRUDBusniess<PromocioneRequest, PromocioneResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}