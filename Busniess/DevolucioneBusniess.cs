using AutoMapper;
using DBLibreria;
using DBLibreria.DBLibreria;
using IBusniess;
using IRepository;
using Microsoft.EntityFrameworkCore;
using Repository;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Busniess
{
    public class DevolucioneBusniess : IDevolucioneBusniess
    {
       /*INYECCIÓN DE DEPENDECIAS*/
       #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
            private readonly IDevolucioneRepository _DevolucioneRepository;
            private readonly IMapper _mapper;
            internal _dbLibreriaContext db;
            //DBSET EN EL ALGUN MOMENTO SERÁ CARGO, PERSONA, COLABORADOR
            internal DbSet<VwDevolucione> dbSet;
        public DevolucioneBusniess(IMapper mapper)
            {
                _mapper = mapper;
                _DevolucioneRepository = new DevolucioneRepository();
                db = new _dbLibreriaContext();
                dbSet = db.Set<VwDevolucione>();
        }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region START CRUD METHODS
         public List<DevolucioneResponse> GetAll()
            {
                List<Devolucione> Devoluciones = _DevolucioneRepository.GetAll();
                List<DevolucioneResponse> lstResponse = _mapper.Map<List<DevolucioneResponse>>(Devoluciones);
                return lstResponse;
            }

         public DevolucioneResponse GetById(int id)
            {
                Devolucione Devolucione = _DevolucioneRepository.GetById(id);
                DevolucioneResponse resul = _mapper.Map<DevolucioneResponse>(Devolucione);
                return resul;
            }

         public DevolucioneResponse Create(DevolucioneRequest entity)
            {
                Devolucione Devolucione = _mapper.Map<Devolucione>(entity);
                Devolucione = _DevolucioneRepository.Create(Devolucione);
                DevolucioneResponse result = _mapper.Map<DevolucioneResponse>(Devolucione);
                return result;
            }
         public List<DevolucioneResponse> CreateMultiple(List<DevolucioneRequest> lista)
            {
                List<Devolucione> Devoluciones = _mapper.Map<List<Devolucione>>(lista);
                Devoluciones = _DevolucioneRepository.CreateMultiple(Devoluciones);
                List<DevolucioneResponse> result = _mapper.Map<List<DevolucioneResponse>>(Devoluciones);
                return result;
            }

         public DevolucioneResponse Update(DevolucioneRequest entity)
            {
                Devolucione Devolucione = _mapper.Map<Devolucione>(entity);
                Devolucione = _DevolucioneRepository.Update(Devolucione);
                DevolucioneResponse result = _mapper.Map<DevolucioneResponse>(Devolucione);
                return result;
            }

         public List<DevolucioneResponse> UpdateMultiple(List<DevolucioneRequest> lista)
            {
                List<Devolucione> Devoluciones = _mapper.Map<List<Devolucione>>(lista);
                Devoluciones = _DevolucioneRepository.UpdateMultiple(Devoluciones);
                List<DevolucioneResponse> result = _mapper.Map<List<DevolucioneResponse>>(Devoluciones);
                return result;
            }

         public int Delete(int id)
            {
                int cantidad = _DevolucioneRepository.Delete(id);
                return cantidad;
            }

         public int DeleteMultipleItems(List<DevolucioneRequest> lista)
            {
                List<Devolucione> Devoluciones = _mapper.Map<List<Devolucione>>(lista);
                int cantidad = _DevolucioneRepository.DeleteMultipleItems(Devoluciones);
                return cantidad;
            }

        public List<VwDevolucione> listaDevoluciones()
        {
            IQueryable<VwDevolucione> query = dbSet;
            return query.ToList();
        }

        //GenericFilterResponse<DevolucioneResponse> ICRUDBusniess<DevolucioneRequest, DevolucioneResponse>.GetByFilter(GenericFilterRequest request)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion END CRUD METHODS
    }
}