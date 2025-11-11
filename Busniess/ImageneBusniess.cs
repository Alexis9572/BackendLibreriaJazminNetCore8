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
    public class ImageneBusniess : IImageneBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IImageneRepository _ImageneRepository;
            private readonly IMapper _mapper;
            public ImageneBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _ImageneRepository = new ImageneRepository();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<ImageneResponse> GetAll()
            {
                List<Imagene> Imagenes = _ImageneRepository.GetAll();
                List<ImageneResponse> lstResponse = _mapper.Map<List<ImageneResponse>>(Imagenes);
                return lstResponse;
            }

         public ImageneResponse GetById(int id)
            {
                Imagene Imagene = _ImageneRepository.GetById(id);
                ImageneResponse resul = _mapper.Map<ImageneResponse>(Imagene);
                return resul;
            }

         public ImageneResponse Create(ImageneRequest entity)
            {
                Imagene Imagene = _mapper.Map<Imagene>(entity);
                Imagene = _ImageneRepository.Create(Imagene);
                ImageneResponse result = _mapper.Map<ImageneResponse>(Imagene);
                return result;
            }
         public List<ImageneResponse> CreateMultiple(List<ImageneRequest> lista)
            {
                List<Imagene> Imagenes = _mapper.Map<List<Imagene>>(lista);
                Imagenes = _ImageneRepository.CreateMultiple(Imagenes);
                List<ImageneResponse> result = _mapper.Map<List<ImageneResponse>>(Imagenes);
                return result;
            }

         public ImageneResponse Update(ImageneRequest entity)
            {
                Imagene Imagene = _mapper.Map<Imagene>(entity);
                Imagene = _ImageneRepository.Update(Imagene);
                ImageneResponse result = _mapper.Map<ImageneResponse>(Imagene);
                return result;
            }

         public List<ImageneResponse> UpdateMultiple(List<ImageneRequest> lista)
            {
                List<Imagene> Imagenes = _mapper.Map<List<Imagene>>(lista);
                Imagenes = _ImageneRepository.UpdateMultiple(Imagenes);
                List<ImageneResponse> result = _mapper.Map<List<ImageneResponse>>(Imagenes);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _ImageneRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<ImageneRequest> lista)
            {
                List<Imagene> Imagenes = _mapper.Map<List<Imagene>>(lista);
                int cantidad = _ImageneRepository.DeleteMultipleItems(Imagenes);
                return cantidad;
            }

         //GenericFilterResponse<ImageneResponse> ICRUDBusniess<ImageneRequest, ImageneResponse>.GetByFilter(GenericFilterRequest request)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion END CRUD METHODS
    }
}