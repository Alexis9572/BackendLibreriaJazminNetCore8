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
    public class TipoDocumentoBusniess : ITipoDocumentoBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly ITipoDocumentoRepository _TipoDocumentoRepository;
            private readonly IMapper _mapper;
            public TipoDocumentoBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _TipoDocumentoRepository = new TipoDocumentoRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<TipoDocumentoResponse> GetAll()
            {
                List<TipoDocumento> TipoDocumentos = _TipoDocumentoRepository.GetAll();
                List<TipoDocumentoResponse> lstResponse = _mapper.Map<List<TipoDocumentoResponse>>(TipoDocumentos);
                return lstResponse;
            }

         public TipoDocumentoResponse GetById(int id)
            {
                TipoDocumento TipoDocumento = _TipoDocumentoRepository.GetById(id);
                TipoDocumentoResponse resul = _mapper.Map<TipoDocumentoResponse>(TipoDocumento);
                return resul;
            }

         public TipoDocumentoResponse Create(TipoDocumentoRequest entity)
            {
                TipoDocumento TipoDocumento = _mapper.Map<TipoDocumento>(entity);
                TipoDocumento = _TipoDocumentoRepository.Create(TipoDocumento);
                TipoDocumentoResponse result = _mapper.Map<TipoDocumentoResponse>(TipoDocumento);
                return result;
            }
         public List<TipoDocumentoResponse> CreateMultiple(List<TipoDocumentoRequest> lista)
            {
                List<TipoDocumento> TipoDocumentos = _mapper.Map<List<TipoDocumento>>(lista);
                TipoDocumentos = _TipoDocumentoRepository.CreateMultiple(TipoDocumentos);
                List<TipoDocumentoResponse> result = _mapper.Map<List<TipoDocumentoResponse>>(TipoDocumentos);
                return result;
            }

         public TipoDocumentoResponse Update(TipoDocumentoRequest entity)
            {
                TipoDocumento TipoDocumento = _mapper.Map<TipoDocumento>(entity);
                TipoDocumento = _TipoDocumentoRepository.Update(TipoDocumento);
                TipoDocumentoResponse result = _mapper.Map<TipoDocumentoResponse>(TipoDocumento);
                return result;
            }

         public List<TipoDocumentoResponse> UpdateMultiple(List<TipoDocumentoRequest> lista)
            {
                List<TipoDocumento> TipoDocumentos = _mapper.Map<List<TipoDocumento>>(lista);
                TipoDocumentos = _TipoDocumentoRepository.UpdateMultiple(TipoDocumentos);
                List<TipoDocumentoResponse> result = _mapper.Map<List<TipoDocumentoResponse>>(TipoDocumentos);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _TipoDocumentoRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<TipoDocumentoRequest> lista)
            {
                List<TipoDocumento> TipoDocumentos = _mapper.Map<List<TipoDocumento>>(lista);
                int cantidad = _TipoDocumentoRepository.DeleteMultipleItems(TipoDocumentos);
                return cantidad;
            }

         //GenericFilterResponse<TipoDocumentoResponse> ICRUDBusniess<TipoDocumentoRequest, TipoDocumentoResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}