using DBLibreria;
using DBLibreria.DBLibreria;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    /*
   ESTA CLASE ES UN CLARO EJEMPLO DE POLIMORFISMO
      TENEMOS UNA SUPER CLASE o CLASE MAESTRA
      QUE AL PASAR UN PARAMETROS DIFERENTES (Cargo, Persona, Usuario, ....)
      TENEMOS RESULTADOS DISTINTOS
          HACE LAS MISMAS OPERACIONES ==> PERO AFECTA A TABLAS DISTINTAS
   */
    public class CRUDRepository<TEntity> where TEntity : class//, ICRUDRepository<TEntity>
    {

        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        internal _dbLibreriaContext db;
        //DBSET EN EL ALGUN MOMENTO SERÁ CARGO, PERSONA, COLABORADOR
        internal DbSet<TEntity> dbSet;

        public CRUDRepository()
        {
            db = new _dbLibreriaContext();
            dbSet = db.Set<TEntity>();
        }

        #endregion DECLARACIÓN DE VARIABLES


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TEntity Create(TEntity entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public List<TEntity> CreateMultiple(List<TEntity> lista)
        {
            dbSet.AddRange(lista);
            db.SaveChanges();
            return lista;
        }

        //object puede ser entero, shor, string (tipo de dato primario)
        public int Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
            return db.SaveChanges();
        }

        public int DeleteMultipleItems(List<TEntity> lista)
        {
            throw new NotImplementedException();
        }



        public List<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            dbSet.Update(entity);
            db.SaveChanges();
            return entity;
        }

        public List<TEntity> UpdateMultiple(List<TEntity> lista)
        {
            dbSet.UpdateRange(lista);
            db.SaveChanges();
            return lista;
        }
    }

}
