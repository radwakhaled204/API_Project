
namespace API_PRO.Data
{
    public interface IUnitOfWork : IDisposable
    {
      //  IDataRepository repo{ get; }
        int CommitChanges();
    }
}
