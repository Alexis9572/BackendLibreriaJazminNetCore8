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
    public class DetallesReembolsoBusniess : IDetallesReembolsoBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IDetallesReembolsoRepository _DetallesReembolsoRepository;
            private readonly IMapper _mapper;
            public DetallesReembolsoBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _DetallesReembolsoRepository = new DetallesReembolsoRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<DetallesReembolsoResponse> GetAll()
            {
                List<DetallesReembolso> DetallesReembolsos = _DetallesReembolsoRepository.GetAll();
                List<DetallesReembolsoResponse> lstResponse = _mapper.Map<List<DetallesReembolsoResponse>>(DetallesReembolsos);
                return lstResponse;
            }

         public DetallesReembolsoResponse GetById(int id)
            {
                DetallesReembolso DetallesReembolso = _DetallesReembolsoRepository.GetById(id);
                DetallesReembolsoResponse resul = _mapper.Map<DetallesReembolsoResponse>(DetallesReembolso);
                return resul;
            }

         public DetallesReembolsoResponse Create(DetallesReembolsoRequest entity)
            {
                DetallesReembolso DetallesReembolso = _mapper.Map<DetallesReembolso>(entity);
                DetallesReembolso = _DetallesReembolsoRepository.Create(DetallesReembolso);
                DetallesReembolsoResponse result = _mapper.Map<DetallesReembolsoResponse>(DetallesReembolso);
                return result;
            }
         public List<DetallesReembolsoResponse> CreateMultiple(List<DetallesReembolsoRequest> lista)
            {
                List<DetallesReembolso> DetallesReembolsos = _mapper.Map<List<DetallesReembolso>>(lista);
                DetallesReembolsos = _DetallesReembolsoRepository.CreateMultiple(DetallesReembolsos);
                List<DetallesReembolsoResponse> result = _mapper.Map<List<DetallesReembolsoResponse>>(DetallesReembolsos);
                return result;
            }

         public DetallesReembolsoResponse Update(DetallesReembolsoRequest entity)
            {
                DetallesReembolso DetallesReembolso = _mapper.Map<DetallesReembolso>(entity);
                DetallesReembolso = _DetallesReembolsoRepository.Update(DetallesReembolso);
                DetallesReembolsoResponse result = _mapper.Map<DetallesReembolsoResponse>(DetallesReembolso);
                return result;
            }

         public List<DetallesReembolsoResponse> UpdateMultiple(List<DetallesReembolsoRequest> lista)
            {
                List<DetallesReembolso> DetallesReembolsos = _mapper.Map<List<DetallesReembolso>>(lista);
                DetallesReembolsos = _DetallesReembolsoRepository.UpdateMultiple(DetallesReembolsos);
                List<DetallesReembolsoResponse> result = _mapper.Map<List<DetallesReembolsoResponse>>(DetallesReembolsos);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _DetallesReembolsoRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<DetallesReembolsoRequest> lista)
            {
                List<DetallesReembolso> DetallesReembolsos = _mapper.Map<List<DetallesReembolso>>(lista);
                int cantidad = _DetallesReembolsoRepository.DeleteMultipleItems(DetallesReembolsos);
                return cantidad;
            }

         //GenericFilterResponse<DetallesReembolsoResponse> ICRUDBusniess<DetallesReembolsoRequest, DetallesReembolsoResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}