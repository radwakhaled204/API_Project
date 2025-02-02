namespace API_PRO.Data
{
    public interface IDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllFun();
        Task<T> GetByIdFun(int id);
        Task AddFun(T entity);
        Task UpdateFun(T entity);
        Task DeleteFun(int id);
    }
}
