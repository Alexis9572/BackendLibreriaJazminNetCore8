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
    public class EnvioBusniess : IEnvioBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IEnvioRepository _EnvioRepository;
            private readonly IMapper _mapper;
            public EnvioBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _EnvioRepository = new EnvioRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<EnvioResponse> GetAll()
            {
                List<Envio> Envios = _EnvioRepository.GetAll();
                List<EnvioResponse> lstResponse = _mapper.Map<List<EnvioResponse>>(Envios);
                return lstResponse;
            }

         public EnvioResponse GetById(int id)
            {
                Envio Envio = _EnvioRepository.GetById(id);
                EnvioResponse resul = _mapper.Map<EnvioResponse>(Envio);
                return resul;
            }

         public EnvioResponse Create(EnvioRequest entity)
            {
                Envio Envio = _mapper.Map<Envio>(entity);
                Envio = _EnvioRepository.Create(Envio);
                EnvioResponse result = _mapper.Map<EnvioResponse>(Envio);
                return result;
            }
         public List<EnvioResponse> CreateMultiple(List<EnvioRequest> lista)
            {
                List<Envio> Envios = _mapper.Map<List<Envio>>(lista);
                Envios = _EnvioRepository.CreateMultiple(Envios);
                List<EnvioResponse> result = _mapper.Map<List<EnvioResponse>>(Envios);
                return result;
            }

         public EnvioResponse Update(EnvioRequest entity)
            {
                Envio Envio = _mapper.Map<Envio>(entity);
                Envio = _EnvioRepository.Update(Envio);
                EnvioResponse result = _mapper.Map<EnvioResponse>(Envio);
                return result;
            }

         public List<EnvioResponse> UpdateMultiple(List<EnvioRequest> lista)
            {
                List<Envio> Envios = _mapper.Map<List<Envio>>(lista);
                Envios = _EnvioRepository.UpdateMultiple(Envios);
                List<EnvioResponse> result = _mapper.Map<List<EnvioResponse>>(Envios);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _EnvioRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<EnvioRequest> lista)
            {
                List<Envio> Envios = _mapper.Map<List<Envio>>(lista);
                int cantidad = _EnvioRepository.DeleteMultipleItems(Envios);
                return cantidad;
            }

         //GenericFilterResponse<EnvioResponse> ICRUDBusniess<EnvioRequest, EnvioResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}