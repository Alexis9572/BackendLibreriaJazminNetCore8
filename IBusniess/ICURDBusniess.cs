namespace IBusniess
{
    public interface ICRUDbusniess<T, Y> : IDisposable
    {
        List<Y> GetAll();
        Y GetById(int id);
        Y Create(T entity);
        Y Update(T entity);
        int Delete(int id);
        int DeleteMultipleItems(List<T> lista);
        List<Y> CreateMultiple(List<T> lista);
        List<Y> UpdateMultiple(List<T> lista);
        //GenericFilterResponse<Y> GetByFilter(GenericFilterRequest request);

    }

}
