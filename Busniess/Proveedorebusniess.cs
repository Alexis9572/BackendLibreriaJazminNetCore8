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
    public class ProveedoreBusniess : IProveedoreBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IProveedoreRepository _ProveedoreRepository;
            private readonly IMapper _mapper;
            public ProveedoreBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _ProveedoreRepository = new ProveedoreRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<ProveedoreResponse> GetAll()
            {
                List<Proveedore> Proveedores = _ProveedoreRepository.GetAll();
                List<ProveedoreResponse> lstResponse = _mapper.Map<List<ProveedoreResponse>>(Proveedores);
                return lstResponse;
            }

         public ProveedoreResponse GetById(int id)
            {
                Proveedore Proveedore = _ProveedoreRepository.GetById(id);
                ProveedoreResponse resul = _mapper.Map<ProveedoreResponse>(Proveedore);
                return resul;
            }

         public ProveedoreResponse Create(ProveedoreRequest entity)
            {
                Proveedore Proveedore = _mapper.Map<Proveedore>(entity);
                Proveedore = _ProveedoreRepository.Create(Proveedore);
                ProveedoreResponse result = _mapper.Map<ProveedoreResponse>(Proveedore);
                return result;
            }
         public List<ProveedoreResponse> CreateMultiple(List<ProveedoreRequest> lista)
            {
                List<Proveedore> Proveedores = _mapper.Map<List<Proveedore>>(lista);
                Proveedores = _ProveedoreRepository.CreateMultiple(Proveedores);
                List<ProveedoreResponse> result = _mapper.Map<List<ProveedoreResponse>>(Proveedores);
                return result;
            }

         public ProveedoreResponse Update(ProveedoreRequest entity)
            {
                Proveedore Proveedore = _mapper.Map<Proveedore>(entity);
                Proveedore = _ProveedoreRepository.Update(Proveedore);
                ProveedoreResponse result = _mapper.Map<ProveedoreResponse>(Proveedore);
                return result;
            }

         public List<ProveedoreResponse> UpdateMultiple(List<ProveedoreRequest> lista)
            {
                List<Proveedore> Proveedores = _mapper.Map<List<Proveedore>>(lista);
                Proveedores = _ProveedoreRepository.UpdateMultiple(Proveedores);
                List<ProveedoreResponse> result = _mapper.Map<List<ProveedoreResponse>>(Proveedores);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _ProveedoreRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<ProveedoreRequest> lista)
            {
                List<Proveedore> Proveedores = _mapper.Map<List<Proveedore>>(lista);
                int cantidad = _ProveedoreRepository.DeleteMultipleItems(Proveedores);
                return cantidad;
            }

         //GenericFilterResponse<ProveedoreResponse> ICRUDBusniess<ProveedoreRequest, ProveedoreResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}