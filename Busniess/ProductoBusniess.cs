using AutoMapper;
using DBLibreria;
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
    public class ProductoBusniess : IProductoBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IProductoRepository _ProductoRepository;
            private readonly IProductoVWRepository _ProductoVWRepository;
            private readonly IMapper _mapper;
            public ProductoBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _ProductoRepository = new ProductoRepository();
                _ProductoVWRepository = new ProductoVWRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<ProductoResponse> GetAll()
            {
                //Traigo la lista desde la tabla
                List<Producto> Productos = _ProductoRepository.GetAll();
                //Traigo la lista desde la vista 
                List<VwProducto> vistaProducto = _ProductoVWRepository.GetAll();

                //List<ProductoResponse> lstResponse = _mapper.Map<List<ProductoResponse>>(Productos);

                List<ProductoResponse> lstvistaResponse = _mapper.Map<List<ProductoResponse>>(vistaProducto);
                
                return lstvistaResponse;
            }

         public ProductoResponse GetById(int id)
         {
                Producto Producto = _ProductoRepository.GetById(id);
                ProductoResponse resul = _mapper.Map<ProductoResponse>(Producto);
                VwProducto vistaProducto = _ProductoVWRepository.obtenerListaProducto(resul.Nombre);
                ProductoResponse productoResponse = _mapper.Map<ProductoResponse>(vistaProducto);
                
                return productoResponse;
         }

         public ProductoResponse Create(ProductoRequest entity)
            {
                Producto Producto = _mapper.Map<Producto>(entity);
                Producto = _ProductoRepository.Create(Producto);
                ProductoResponse result = _mapper.Map<ProductoResponse>(Producto);
                return result;
            }
         public List<ProductoResponse> CreateMultiple(List<ProductoRequest> lista)
            {
                List<Producto> Productos = _mapper.Map<List<Producto>>(lista);
                Productos = _ProductoRepository.CreateMultiple(Productos);
                List<ProductoResponse> result = _mapper.Map<List<ProductoResponse>>(Productos);
                return result;
            }

         public ProductoResponse Update(ProductoRequest entity)
            {
                Producto Producto = _mapper.Map<Producto>(entity);
                Producto = _ProductoRepository.Update(Producto);
                ProductoResponse result = _mapper.Map<ProductoResponse>(Producto);
                return result;
            }

         public List<ProductoResponse> UpdateMultiple(List<ProductoRequest> lista)
            {
                List<Producto> Productos = _mapper.Map<List<Producto>>(lista);
                Productos = _ProductoRepository.UpdateMultiple(Productos);
                List<ProductoResponse> result = _mapper.Map<List<ProductoResponse>>(Productos);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _ProductoRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<ProductoRequest> lista)
            {
                List<Producto> Productos = _mapper.Map<List<Producto>>(lista);
                int cantidad = _ProductoRepository.DeleteMultipleItems(Productos);
                return cantidad;
            }

         //GenericFilterResponse<ProductoResponse> ICRUDBusniess<ProductoRequest, ProductoResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}