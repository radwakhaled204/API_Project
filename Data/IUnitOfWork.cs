
using API_PRO.Data.Models;

namespace API_PRO.Data
{//add it 
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
       IDataRepository<Category> categories{ get; }
        int CommitChanges();
    }
}
