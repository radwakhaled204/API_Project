namespace API_PRO.Data
{
    public interface IDataRepository<T> where T : class
    {
        //public Task<List<ComplaintsDTO>> GetAll();
        //public Task<ComplaintsDTO> GetById(int id);
        //public Task<int> Create(ComplaintsDTO complaintDto);
        //public Task<ComplaintsDTO> Update(int id, ComplaintsDTO complaintDto);
        //public Task<int> Delete(int id);

        Task<IEnumerable<T>> GetAllFun();
        Task<T> GetByIdFun(int id);
        Task AddFun(T entity);
        Task UpdateFun(T entity);
        Task DeleteFun(int id);
    }
}
