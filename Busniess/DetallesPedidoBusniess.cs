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
    public class DetallesPedidoBusniess : IDetallesPedidoBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IDetallesPedidoRepository _DetallesPedidoRepository;
            private readonly IMapper _mapper;
            public DetallesPedidoBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _DetallesPedidoRepository = new DetallesPedidoRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<DetallesPedidoResponse> GetAll()
            {
                List<DetallesPedido> DetallesPedidos = _DetallesPedidoRepository.GetAll();
                List<DetallesPedidoResponse> lstResponse = _mapper.Map<List<DetallesPedidoResponse>>(DetallesPedidos);
                return lstResponse;
            }

         public DetallesPedidoResponse GetById(int id)
            {
                DetallesPedido DetallesPedido = _DetallesPedidoRepository.GetById(id);
                DetallesPedidoResponse resul = _mapper.Map<DetallesPedidoResponse>(DetallesPedido);
                return resul;
            }

         public DetallesPedidoResponse Create(DetallesPedidoRequest entity)
            {
                DetallesPedido DetallesPedido = _mapper.Map<DetallesPedido>(entity);
                DetallesPedido = _DetallesPedidoRepository.Create(DetallesPedido);
                DetallesPedidoResponse result = _mapper.Map<DetallesPedidoResponse>(DetallesPedido);
                return result;
            }
         public List<DetallesPedidoResponse> CreateMultiple(List<DetallesPedidoRequest> lista)
            {
                List<DetallesPedido> DetallesPedidos = _mapper.Map<List<DetallesPedido>>(lista);
                DetallesPedidos = _DetallesPedidoRepository.CreateMultiple(DetallesPedidos);
                List<DetallesPedidoResponse> result = _mapper.Map<List<DetallesPedidoResponse>>(DetallesPedidos);
                return result;
            }

         public DetallesPedidoResponse Update(DetallesPedidoRequest entity)
            {
                DetallesPedido DetallesPedido = _mapper.Map<DetallesPedido>(entity);
                DetallesPedido = _DetallesPedidoRepository.Update(DetallesPedido);
                DetallesPedidoResponse result = _mapper.Map<DetallesPedidoResponse>(DetallesPedido);
                return result;
            }

         public List<DetallesPedidoResponse> UpdateMultiple(List<DetallesPedidoRequest> lista)
            {
                List<DetallesPedido> DetallesPedidos = _mapper.Map<List<DetallesPedido>>(lista);
                DetallesPedidos = _DetallesPedidoRepository.UpdateMultiple(DetallesPedidos);
                List<DetallesPedidoResponse> result = _mapper.Map<List<DetallesPedidoResponse>>(DetallesPedidos);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _DetallesPedidoRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<DetallesPedidoRequest> lista)
            {
                List<DetallesPedido> DetallesPedidos = _mapper.Map<List<DetallesPedido>>(lista);
                int cantidad = _DetallesPedidoRepository.DeleteMultipleItems(DetallesPedidos);
                return cantidad;
            }

         //GenericFilterResponse<DetallesPedidoResponse> ICRUDBusniess<DetallesPedidoRequest, DetallesPedidoResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}