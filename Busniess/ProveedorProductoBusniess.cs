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
    public class ProveedorProductoBusniess : IProveedorProductoBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IProveedorProductoRepository _ProveedorProductoRepository;
            private readonly IMapper _mapper;
            public ProveedorProductoBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _ProveedorProductoRepository = new ProveedorProductoRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<ProveedorProductoResponse> GetAll()
            {
                List<ProveedorProducto> ProveedorProductos = _ProveedorProductoRepository.GetAll();
                List<ProveedorProductoResponse> lstResponse = _mapper.Map<List<ProveedorProductoResponse>>(ProveedorProductos);
                return lstResponse;
            }

         public ProveedorProductoResponse GetById(int id)
            {
                ProveedorProducto ProveedorProducto = _ProveedorProductoRepository.GetById(id);
                ProveedorProductoResponse resul = _mapper.Map<ProveedorProductoResponse>(ProveedorProducto);
                return resul;
            }

         public ProveedorProductoResponse Create(ProveedorProductoRequest entity)
            {
                ProveedorProducto ProveedorProducto = _mapper.Map<ProveedorProducto>(entity);
                ProveedorProducto = _ProveedorProductoRepository.Create(ProveedorProducto);
                ProveedorProductoResponse result = _mapper.Map<ProveedorProductoResponse>(ProveedorProducto);
                return result;
            }
         public List<ProveedorProductoResponse> CreateMultiple(List<ProveedorProductoRequest> lista)
            {
                List<ProveedorProducto> ProveedorProductos = _mapper.Map<List<ProveedorProducto>>(lista);
                ProveedorProductos = _ProveedorProductoRepository.CreateMultiple(ProveedorProductos);
                List<ProveedorProductoResponse> result = _mapper.Map<List<ProveedorProductoResponse>>(ProveedorProductos);
                return result;
            }

         public ProveedorProductoResponse Update(ProveedorProductoRequest entity)
            {
                ProveedorProducto ProveedorProducto = _mapper.Map<ProveedorProducto>(entity);
                ProveedorProducto = _ProveedorProductoRepository.Update(ProveedorProducto);
                ProveedorProductoResponse result = _mapper.Map<ProveedorProductoResponse>(ProveedorProducto);
                return result;
            }

         public List<ProveedorProductoResponse> UpdateMultiple(List<ProveedorProductoRequest> lista)
            {
                List<ProveedorProducto> ProveedorProductos = _mapper.Map<List<ProveedorProducto>>(lista);
                ProveedorProductos = _ProveedorProductoRepository.UpdateMultiple(ProveedorProductos);
                List<ProveedorProductoResponse> result = _mapper.Map<List<ProveedorProductoResponse>>(ProveedorProductos);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _ProveedorProductoRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<ProveedorProductoRequest> lista)
            {
                List<ProveedorProducto> ProveedorProductos = _mapper.Map<List<ProveedorProducto>>(lista);
                int cantidad = _ProveedorProductoRepository.DeleteMultipleItems(ProveedorProductos);
                return cantidad;
            }

         //GenericFilterResponse<ProveedorProductoResponse> ICRUDBusniess<ProveedorProductoRequest, ProveedorProductoResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}